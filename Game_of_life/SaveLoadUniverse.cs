﻿using System;
using System.IO;
using System.Diagnostics;

namespace Game_of_life
{
	class SaveLoadUniverse
	{
		public  Colony colony;
		public int universeSize;

		public SaveLoadUniverse(Colony _colony, int _universeSize)
		{
			this.colony = _colony;
			this.universeSize = _universeSize;
		}

		public void Save(string fileName)
		{
			string universeState = String.Empty;
			foreach (Bacteria bacteria in colony.currentColony)
			{
				if (bacteria.isAlive) universeState += "1";
				else universeState += "0";
			}
			StreamWriter sw = new StreamWriter(fileName);
			sw.Write(universeState);
			sw.Close();
		}

		public void Load (string fileText)
		{
			int i = 0;
			for (int raws = 0; raws < universeSize; raws++)
			{
				for (int columns = 0; columns < universeSize; columns++)
				{

					if (fileText[i] == '1')
					{
						colony.currentColony[raws, columns].isAlive = true;
					}
					else
					{
						colony.currentColony[raws, columns].isAlive = false;
					}
					colony.currentColony[raws, columns].DrawBacteria();
					i++;
				}
			}
		}
	}
}
