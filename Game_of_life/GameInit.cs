using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace Game_of_life
{
	class GameInit
	{
		public BufferedGraphicsContext context;
		public static BufferedGraphics buffer;
		public int Width { get; set; }
		public int Height { get; set; }
		public int universeSize = 75;

        Colony colony;

		public GameInit(Form form)
		{
            #region Graphics rendering
            Graphics graphics;
			context = BufferedGraphicsManager.Current;
			graphics = form.CreateGraphics();
			Width = form.ClientSize.Width;
			Height = form.ClientSize.Height;
			buffer = context.Allocate(graphics, new Rectangle(0, 0, Width, Height));
			Timer timer = new Timer { Interval = 500};
			timer.Start();
			timer.Tick += Timer_tick;
            #endregion

            colony = new Colony(universeSize);
            UI ui = new UI(form, timer, universeSize, colony);
		}

		public void Timer_tick (object sender, EventArgs e)
		{
			Debug.WriteLine("Event Timer_tick!");
			DrawAll(colony);
			buffer.Render();
		}

        public void DrawAll(Colony colony)
        {
            colony.Check();
            colony.Draw();
            colony.Update();
        }
    }
}
