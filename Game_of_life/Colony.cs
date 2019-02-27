using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace Game_of_life
{
	class Colony
	{
		public static  int _universeSize;
		public static Bacteria [,] currentColony;
		public static Bacteria[,] nextColony;

		public Colony(int universeSize)
		{
			
			_universeSize = universeSize;
			currentColony = new Bacteria[universeSize,universeSize];
			nextColony = new Bacteria[universeSize, universeSize];
			for (int raws = 0; raws < universeSize; raws++)
			{
				for (int columns = 0; columns < universeSize; columns++ )
				{
					currentColony[raws, columns] = new Bacteria(raws*10, columns*10);
				}
			}
			for (int raws = 0; raws < universeSize; raws++)
			{
				for (int columns = 0; columns < universeSize; columns++)
				{
					nextColony[raws, columns] = new Bacteria(raws * 10, columns * 10);
				}
			}

			//Рисуем планер
			currentColony[2, 0].isAlive = true;
			currentColony[0, 1].isAlive = true;
			currentColony[2, 1].isAlive = true;
			currentColony[1, 2].isAlive = true;
			currentColony[2, 2].isAlive = true;

			/*//Рисуем каравай
			currentColony[16, 4].isAlive = true;
			currentColony[17, 3].isAlive = true;
			currentColony[18, 2].isAlive = true;
			currentColony[17, 5].isAlive = true;
			currentColony[18, 5].isAlive = true;
			currentColony[19, 4].isAlive = true;
			currentColony[19, 3].isAlive = true;
			
			//Рисуем ружье
			currentColony[5, 16].isAlive = true;
			currentColony[6, 16].isAlive = true;
			currentColony[7, 16].isAlive = true;
			currentColony[8, 16].isAlive = true;
			currentColony[4, 17].isAlive = true;
			currentColony[4, 18].isAlive = true;
			currentColony[4, 19].isAlive = true;
			currentColony[4, 20].isAlive = true;
			currentColony[5, 21].isAlive = true;
			currentColony[6, 21].isAlive = true;
			currentColony[7, 21].isAlive = true;
			currentColony[8, 21].isAlive = true;
			currentColony[9, 20].isAlive = true;
			currentColony[9, 19].isAlive = true;
			currentColony[9, 18].isAlive = true;
			currentColony[9, 17].isAlive = true;*/
		}


		public static void ColonyCheck()
		{
			for (int raws = 0; raws < _universeSize; raws++)
			{
				for (int columns = 0; columns < _universeSize; columns++)
				{
					int lifeCounter = CountSquare(raws, columns);
					if (currentColony[raws, columns].isAlive == false && lifeCounter == 3 )
					{
						nextColony[raws, columns].isAlive = true;
					}
					else if (currentColony[raws, columns].isAlive == true && (lifeCounter == 2 || lifeCounter == 3))
					{
						nextColony[raws, columns].isAlive = true;
					}
					else
					{
						nextColony[raws, columns].isAlive = false;
					}
				}
			}
		}

		public static int CountSquare (int raws, int columns)
		{
			int lifeCounter = 0;
			
			if (CheckSquare(raws-1, columns-1) && currentColony[raws - 1, columns - 1].isAlive)
				lifeCounter++;
			if (CheckSquare(raws, columns - 1) && currentColony[raws, columns - 1].isAlive)
				lifeCounter++;
			if (CheckSquare(raws + 1, columns - 1) && currentColony[raws + 1, columns - 1].isAlive)
				lifeCounter++;
			if (CheckSquare(raws - 1, columns) && currentColony[raws - 1, columns].isAlive)
				lifeCounter++;
			if (CheckSquare(raws + 1, columns) && currentColony[raws + 1, columns].isAlive)
				lifeCounter++;
			if (CheckSquare(raws - 1, columns + 1) && currentColony[raws - 1, columns + 1].isAlive)
				lifeCounter++;
			if (CheckSquare(raws, columns + 1) && currentColony[raws, columns + 1].isAlive)
				lifeCounter++;
			if (CheckSquare(raws + 1, columns + 1) && currentColony[raws + 1, columns + 1].isAlive)
				lifeCounter++;

			return lifeCounter;
		}

		public static bool CheckSquare (int x, int y)
		{
			return (x >= 0 && x <= _universeSize - 1) && (y >= 0 && y <= _universeSize - 1);
		}

		public static void DrawColony()
		{
			foreach (var bacteria in nextColony)
				bacteria.DrawBacteria();
		}

		public static void UpdateColony ()
		{
			for (int raws = 0; raws < _universeSize; raws++)
			{
				for (int columns = 0; columns < _universeSize; columns++)
				{
					currentColony[raws, columns] = nextColony[raws, columns];
				}
			}
			for (int raws = 0; raws < _universeSize; raws++)
			{
				for (int columns = 0; columns < _universeSize; columns++)
				{
					nextColony[raws, columns] = new Bacteria(raws * 10, columns * 10);
				}
			}
			
		}

	}
}
