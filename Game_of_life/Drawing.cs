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

		public static void DrawAll  ()
		{
			
			Colony.DrawColony();
			Colony.ColonyUpdate();
		}
	}
}
