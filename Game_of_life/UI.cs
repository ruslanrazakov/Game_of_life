using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace Game_of_life
{
	class UI
	{
		public UI(Form form, Timer timer, int universeSize)
		{
			timer.Stop();
			timer.Start();
			universeSize = 50;
			Colony colony = new Colony(universeSize);
		}
	}
}
