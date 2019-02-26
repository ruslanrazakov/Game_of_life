using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_life
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Form form = new Form
			{
				Width = 1000,
				Height = 800
			};
			GameInit gameInit = new GameInit(form);
			form.Show();
			form.Text = "Game Of Life";
			Application.Run(form);
		}
	}
}
