using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		public int universeSize = 5;

		public GameInit(Form form)
		{
			Graphics graphics;
			context = BufferedGraphicsManager.Current;
			graphics = form.CreateGraphics();
			Width = form.ClientSize.Width;
			Height = form.ClientSize.Height;
			buffer = context.Allocate(graphics, new Rectangle(0, 0, 300, 300));
			Colony colony = new Colony(universeSize);
			Timer timer = new Timer { Interval = 1000};
			timer.Start();
			timer.Tick += Timer_tick;
		}

		public void Timer_tick (object sender, EventArgs e)
		{
			Debug.WriteLine("Event Timer_tick!");
			Drawing.DrawAll ();
			buffer.Render();
		}
	}
}
