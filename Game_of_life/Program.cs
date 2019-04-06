using System;
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
				Height = 840
			};
			GameInit gameInit = new GameInit(form);
			form.Show();
			form.Text = "Game Of Life";
			Application.Run(form);
		}
	}
}
