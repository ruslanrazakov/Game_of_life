using System.Drawing;
using System.Diagnostics;

namespace Game_of_life
{
	class Bacteria
	{
		public Point position;
		public bool isAlive = false;
		SolidBrush solidBrush;

		public Bacteria(int positionX, int positionY)
		{
			position.X = positionX;
			position.Y = positionY;
		}

		public void DrawBacteria()
		{
			if (isAlive)
				solidBrush = new SolidBrush(Color.Red);
			else
				solidBrush = new SolidBrush(Color.LightBlue);

			GameInit.buffer.Graphics.FillRectangle(solidBrush, new Rectangle(position.X, position.Y, 10, 10));
			GameInit.buffer.Graphics.DrawRectangle(Pens.White, position.X, position.Y, 10, 10);
		}
	}
}
