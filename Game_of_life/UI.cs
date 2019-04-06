﻿using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace Game_of_life
{
	class UI
	{
		public static Button playButton = new Button();
		public static Button stopButton = new Button();
		public static Button speedUpButton = new Button();
		public static Button speedDownButton = new Button();
		public static Button clearButton = new Button();
		public static Label speedLabel = new Label();
		public static Label infoLabel = new Label();
		public static Button saveButton = new Button();
		public static Button loadButton = new Button();
		Timer _timer;
		int intervalCounter = 20;
		Label label = new Label();
		public static int _universeSize;

		private Form my_form;

		public UI(Form form, Timer timer, int universeSize)
		{
			my_form = form;

			_universeSize = universeSize;
			_timer = timer;
			SolidBrush backgroundBrush = new SolidBrush(Color.LightGreen);
			GameInit.buffer.Graphics.FillRectangle(backgroundBrush, new Rectangle(0, 0, 1000, 800));
			AddPlayButton(form);
			AddStopButton(form);
			AddSpeedUpButton(form);
			AddSpeedDownButton(form);
			AddClearButton(form);
			AddSpeedLabel(form);
			AddInfoLabel(form);
			AddSaveButton(form);
			AddLoadButton(form);
			form.MouseClick += Form_MouseClick;

			form.Paint += Form_Paint;
		}

		private void AddPlayButton(Form form)
		{
			playButton.Click += new EventHandler(PlayButton_Click);
			playButton.Size = new Size(150, 25);
			playButton.Location = new Point(800, 20);
			playButton.Font = new Font("Courier", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
			playButton.Name = "PlayButton";
			playButton.TabIndex = 0;
			playButton.Text = "Play";
			playButton.BackColor = Color.FromArgb(50, 0, 0, 0);
			form.Controls.Add(playButton);
		}

		private void PlayButton_Click(object sender, EventArgs e)
		{
			Debug.WriteLine("Play!");
			_timer.Start();
			Form.ActiveForm.Controls.Remove(label);
		}

		private void AddStopButton(Form form)
		{
			stopButton.Click += new EventHandler(StopButton_Click);
			stopButton.Size = new Size(150, 25);
			stopButton.Location = new Point(800, 50);
			stopButton.Font = new Font("Courier", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
			stopButton.Name = "StopButton";
			stopButton.TabIndex = 1;
			stopButton.Text = "Stop";
			stopButton.BackColor = Color.FromArgb(50, 0, 0, 0);
			form.Controls.Add(stopButton);
		}

		private void StopButton_Click(object sender, EventArgs e)
		{
			Debug.WriteLine("Stop!");
			_timer.Stop();
		}

		private void AddSpeedUpButton(Form form)
		{
			speedUpButton.Click += new EventHandler(SpeedUpButton_Click);
			speedUpButton.Size = new Size(150, 25);
			speedUpButton.Location = new Point(800, 80);
			speedUpButton.Font = new Font("Courier", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
			speedUpButton.Name = "SpeedUpButton";
			speedUpButton.TabIndex = 2;
			speedUpButton.Text = "Speed + ";
			speedUpButton.BackColor = Color.FromArgb(50, 0, 0, 0);
			form.Controls.Add(speedUpButton);
		}

		private void SpeedUpButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (intervalCounter != 30) intervalCounter++;
				_timer.Interval -= 50;
				speedLabel.Text = "Speed: " + intervalCounter;
			}
			catch
			{
				_timer.Interval = 50;
			}
			Debug.WriteLine(_timer.Interval.ToString());
		}

		private void AddSpeedDownButton(Form form)
		{
			speedDownButton.Click += new EventHandler(SpeedDownButton_Click);
			speedDownButton.Size = new Size(150, 25);
			speedDownButton.Location = new Point(800, 110);
			speedDownButton.Font = new Font("Courier", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
			speedDownButton.Name = "SpeedDownButton";
			speedDownButton.TabIndex = 3;
			speedDownButton.Text = "Speed - ";
			speedDownButton.BackColor = Color.FromArgb(50, 0, 0, 0);
			form.Controls.Add(speedDownButton);
		}

		private void SpeedDownButton_Click(object sender, EventArgs e)
		{
			if (_timer.Interval != 1500)
			{
				_timer.Interval += 50;
				intervalCounter--;
				speedLabel.Text = "Speed: " + intervalCounter;
			}
			Debug.WriteLine(_timer.Interval.ToString());
		}

		private void AddClearButton(Form form)
		{
			clearButton.Click += new EventHandler(ClearButton_Click);
			clearButton.Size = new Size(150, 25);
			clearButton.Location = new Point(800, 170);
			clearButton.Font = new Font("Courier", 14F, FontStyle.Bold, GraphicsUnit.Point);
			clearButton.Name = "ClearButton";
			clearButton.TabIndex = 4 ;
			clearButton.Text = "Clear";
			clearButton.BackColor = Color.Red;
			form.Controls.Add(clearButton);
		}

		private void ClearButton_Click(object sender, EventArgs e)
		{
			for (int raws = 0; raws < _universeSize; raws++)
			{
				for (int columns = 0; columns < _universeSize; columns++)
				{
					Colony.currentColony[raws, columns] = new Bacteria(raws * 10, columns * 10);
					Colony.currentColony[raws, columns].DrawBacteria();
					my_form.Invalidate();
				}
			}
		}

		private void AddSpeedLabel(Form form)
		{
			speedLabel.Size = new Size(150, 25);
			speedLabel.Location = new Point(800, 140);
			speedLabel.Font = new Font("Courier", 14F, FontStyle.Italic, GraphicsUnit.Point);
			speedLabel.Name = "SpeedLabel";
			speedLabel.Text = "Speed: " + 20;
			speedLabel.BackColor = Color.LightGreen;
			form.Controls.Add(speedLabel);
		}

		private void AddInfoLabel(Form form)
		{
			infoLabel.Size = new Size(1000, 15);
			infoLabel.Location = new Point(5, 780);
			infoLabel.Font = new Font("Courier", 10F, FontStyle.Italic, GraphicsUnit.Point);
			infoLabel.Name = "InfoLabel";
			infoLabel.Text = "Press left mouse button to put a cell in the universe; press right mouse button to destroy a cell.";
			infoLabel.BackColor = Color.LightGreen;
			form.Controls.Add(infoLabel);
		}

		private void AddSaveButton(Form form)
		{
			saveButton.Click += new EventHandler(SaveButton_Click);
			saveButton.Size = new Size(150, 25);
			saveButton.Location = new Point(800, 200);
			saveButton.Font = new Font("Courier", 14F, FontStyle.Bold, GraphicsUnit.Point);
			saveButton.Name = "SaveButton";
			saveButton.TabIndex = 4;
			saveButton.Text = "Save";
			saveButton.BackColor = Color.Red;
			form.Controls.Add(saveButton);
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			_timer.Stop();
			string fileName = Microsoft.VisualBasic.Interaction.InputBox("Name your figure:");
			SaveLoadUniverse saveLoadUniverse = new SaveLoadUniverse(Colony.currentColony, _universeSize);
			saveLoadUniverse.Save(fileName + ".txt");
		}

		public void AddLoadButton(Form form)
		{
			loadButton.Click += new EventHandler(LoadButton_Click);
			loadButton.Size = new Size(150, 25);
			loadButton.Location = new Point(800, 230);
			loadButton.Font = new Font("Courier", 14F, FontStyle.Bold, GraphicsUnit.Point);
			loadButton.Name = "LoadButton";
			loadButton.TabIndex = 4;
			loadButton.Text = "Load";
			loadButton.BackColor = Color.Red;
			form.Controls.Add(loadButton);
		}

		private void LoadButton_Click(object sender, EventArgs e)
		{
			_timer.Stop();
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				DefaultExt = ".txt",
				Filter = "Text documents (.txt)|*.txt"
			};
			openFileDialog.ShowDialog();
			string fileText = String.Empty;
			string fileName = openFileDialog.FileName;
			bool noFile = false;
			try
			{
				fileText = File.ReadAllText(fileName);
			}
			catch
			{
				noFile = true;
			}
			if (!noFile)
			{
				SaveLoadUniverse saveLoadUniverse = new SaveLoadUniverse(Colony.currentColony, _universeSize);
				saveLoadUniverse.Load(fileText);
				Debug.WriteLine(fileText);
			}
			my_form.Invalidate();

		}

		private void Form_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (e.Location.X < _universeSize * 10 && e.Location.Y < _universeSize * 10)
				{
					BacteriaRevive(true, e, Color.Green);
				}
			}
			else
			{
				BacteriaRevive(false, e, Color.LightBlue);
			}
		}
		
		private void Form_Paint (object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Debug.WriteLine("Form_Paint!");
			GameInit.buffer.Render();
		}

		void BacteriaRevive (bool alive, MouseEventArgs e, Color color)
		{
			_timer.Stop();
			int X = (e.Location.X - e.Location.X % 10) / 10;
			int Y = (e.Location.Y - e.Location.Y % 10) / 10;

			Colony.currentColony[X, Y].isAlive = alive;
			Colony.currentColony[X, Y].DrawBacteria();

			my_form.Invalidate();

			Debug.WriteLine(e.Location.X + " " + e.Location.Y);
		}
	}
}
