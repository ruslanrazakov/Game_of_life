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

			//Рисуем каравай
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
			currentColony[9, 17].isAlive = true;


		}

		public static void CountColony ()
		{
			int lifeCounter = 0;
			for (int raws = 0; raws < _universeSize; raws++)
			{
				for (int columns = 0; columns < _universeSize; columns++)
				{
					if (currentColony[raws, columns].position.X == 0 && currentColony[raws, columns].position.Y == 0)
					{
						if (currentColony[raws + 1, columns].isAlive)
							lifeCounter++;
						if (currentColony[raws, columns + 1].isAlive)
							lifeCounter++;
						if (currentColony[raws + 1, columns + 1].isAlive)
							lifeCounter++;

					}
					else if (currentColony[raws, columns].position.X == _universeSize * 10 - 10 && currentColony[raws, columns].position.Y == 0)
					{
						if (currentColony[raws - 1, columns].isAlive)
							lifeCounter++;
						if (currentColony[raws - 1, columns + 1].isAlive)
							lifeCounter++;
						if (currentColony[raws, columns + 1].isAlive)
							lifeCounter++;
					}
					else if (currentColony[raws, columns].position.X == 0 && currentColony[raws, columns].position.Y == _universeSize * 10 - 10)
					{
						if (currentColony[raws, columns - 1].isAlive)
							lifeCounter++;
						if (currentColony[raws + 1, columns - 1].isAlive)
							lifeCounter++;
						if (currentColony[raws + 1, columns].isAlive)
							lifeCounter++;
					}
					else if (currentColony[raws, columns].position.X == _universeSize * 10 - 10 && currentColony[raws, columns].position.Y == _universeSize * 10 - 10)
					{
						if (currentColony[raws - 1, columns - 1].isAlive)
							lifeCounter++;
						if (currentColony[raws, columns - 1].isAlive)
							lifeCounter++;
						if (currentColony[raws - 1, columns].isAlive)
							lifeCounter++;
					}
					else if (currentColony[raws, columns].position.Y == 0)
					{
						if (currentColony[raws - 1, columns].isAlive)
							lifeCounter++;
						if (currentColony[raws + 1, columns].isAlive)
							lifeCounter++;
						if (currentColony[raws - 1, columns + 1].isAlive)
							lifeCounter++;
						if (currentColony[raws, columns + 1].isAlive)
							lifeCounter++;
						if (currentColony[raws + 1, columns + 1].isAlive)
							lifeCounter++;
					}
					else if (currentColony[raws, columns].position.X == 0)
					{
						if (currentColony[raws, columns - 1].isAlive)
							lifeCounter++;
						if (currentColony[raws + 1, columns - 1].isAlive)
							lifeCounter++;
						if (currentColony[raws + 1, columns].isAlive)
							lifeCounter++;
						if (currentColony[raws, columns + 1].isAlive)
							lifeCounter++;
						if (currentColony[raws + 1, columns + 1].isAlive)
							lifeCounter++;
					}
					else if (currentColony[raws, columns].position.X == _universeSize * 10 - 10)
					{
						if (currentColony[raws - 1, columns - 1].isAlive)
							lifeCounter++;
						if (currentColony[raws, columns - 1].isAlive)
							lifeCounter++;
						if (currentColony[raws - 1, columns].isAlive)
							lifeCounter++;
						if (currentColony[raws - 1, columns + 1].isAlive)
							lifeCounter++;
						if (currentColony[raws, columns + 1].isAlive)
							lifeCounter++;
					}
					else if (currentColony[raws, columns].position.Y == _universeSize * 10 - 10)
					{
						if (currentColony[raws - 1, columns - 1].isAlive)
							lifeCounter++;
						if (currentColony[raws, columns - 1].isAlive)
							lifeCounter++;
						if (currentColony[raws + 1, columns - 1].isAlive)
							lifeCounter++;
						if (currentColony[raws - 1, columns].isAlive)
							lifeCounter++;
						if (currentColony[raws + 1, columns].isAlive)
							lifeCounter++;
					}
					else
					{
						if (currentColony[raws - 1, columns - 1].isAlive)
							lifeCounter++;
						if (currentColony[raws, columns - 1].isAlive)
							lifeCounter++;
						if (currentColony[raws + 1, columns - 1].isAlive)
							lifeCounter++;
						if (currentColony[raws - 1, columns].isAlive)
							lifeCounter++;
						if (currentColony[raws + 1, columns].isAlive)
							lifeCounter++;
						if (currentColony[raws - 1, columns + 1].isAlive)
							lifeCounter++;
						if (currentColony[raws, columns + 1].isAlive)
							lifeCounter++;
						if (currentColony[raws + 1, columns + 1].isAlive)
							lifeCounter++;
					}

					Debug.WriteLine(lifeCounter);
					if (currentColony[raws, columns].isAlive==false && lifeCounter == 3)
					{
						nextColony[raws, columns].isAlive = true;
					}
					else if (currentColony[raws, columns].isAlive==true && (lifeCounter==2 || lifeCounter ==3))
					{
						nextColony[raws, columns].isAlive = true;
					}
					else
					{
						nextColony[raws, columns].isAlive = false;
					}
					lifeCounter = 0;
				}
			}
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
