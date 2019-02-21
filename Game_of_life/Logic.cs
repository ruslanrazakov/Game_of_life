using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace Game_of_life
{
	class Logic
	{
		public static List<Bacteria> colony = new List<Bacteria>();

		public static void SetColony ()
		{
			for (int raws = 0; raws <= 10; raws++)
			{
				for (int columns = 0; columns <= 10; columns++)
				{
					Bacteria bacteria = new Bacteria(columns*10, raws*10);
					colony.Add(bacteria);
				}
			}
		}

		

		public static void DrawColony ()
		{


			colony[11].isAlive = false;
			foreach (var bacteria in colony)
			{
				
				bacteria.DrawBacteria();
			}
		}
	}
}
