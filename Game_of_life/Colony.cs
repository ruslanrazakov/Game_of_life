namespace Game_of_life
{
	class Colony
	{
		public static  int _universeSize;
		public Bacteria [,] currentColony;
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


		public  void Check()
		{
			for (int raws = 0; raws < _universeSize; raws++)
			{
				for (int columns = 0; columns < _universeSize; columns++)
				{
					int lifeCounter = CountSquare(raws, columns);
					/*
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
					*/
					if (lifeCounter <= 1 || lifeCounter >= 4) nextColony[raws, columns].isAlive = false;
					else if (lifeCounter == 3) nextColony[raws, columns].isAlive = true;
					else nextColony[raws, columns].isAlive = currentColony[raws, columns].isAlive;
					// 0-1 гибнет
					// 2 не меняется
					// 3 живет
					// 4-8 гибнет
				}
			}
		}

		public  int CountSquare (int raws, int columns)
		{
			int lifeCounter = 0;

			int i, j;

			for (i = 0; i < 3; i++)
			{
				for (j = 0; j < 3; j++)
				{
					if (IsCellAlive(raws - 1 + i, columns - 1 + j)) lifeCounter++;
				}
			}

			if (IsCellAlive(raws, columns)) lifeCounter--;

			return lifeCounter;
		}

		public bool IsCellAlive (int i, int j)
		{
			/* 
			// Версия 1
			if (i < 0 || i >= _universeSize || j < 0 || j >= _universeSize)
			{
				return (false);
			}
			else
			{
				return (currentColony[i, j].isAlive);
			}
			*/

			// Версия 2
			return (currentColony [(i + _universeSize)% _universeSize, (j + _universeSize) % _universeSize].isAlive);
		}

		public void Draw()
		{
			foreach (var bacteria in nextColony)
				bacteria.DrawBacteria();
		}

		public void Update()
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
