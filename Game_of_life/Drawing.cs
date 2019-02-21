using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game_of_life
{
	class Drawing
	{
		public static void DrawBackgournd()
		{
			GameInit.buffer.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), new Rectangle(0, 0, 100, 100));
			DrawGrid();
		}

		public static void DrawGrid()
		{
			for (int raws = 0; raws <= 10; raws++)
			{
				for (int columns = 0; columns <= 10; columns++)
				{
					GameInit.buffer.Graphics.DrawRectangle(Pens.White, raws * 10, columns * 10, 10, 10);
				}
			}
		}

		public static void DrawAll  ()
		{
			DrawBackgournd();
			Logic.DrawColony();
			GameInit.buffer.Render();
		}
	}
}
