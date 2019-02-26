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
		public static Button playButton = new Button();
		public static Button stopButton = new Button();
		public static Button speedUpButton = new Button();
		public static Button speedDownButton = new Button();
		public static Label speedLabel = new Label();
		Timer _timer;
		int intervalCounter = 20;
		Label label = new Label();
		int _universeSize;

		public UI(Form form, Timer timer, int universeSize)
		{
			_universeSize = universeSize;
			_timer = timer;
			SolidBrush backgroundBrush = new SolidBrush(Color.LightGreen);
			GameInit.buffer.Graphics.FillRectangle(backgroundBrush, new Rectangle(0, 0, 1000, 800));
			AddPlayButton(form);
			AddStopButton(form);
			AddSpeedUpButton(form);
			AddSpeedDownButton(form);
			AddSpeedLabel(form);
			form.MouseClick += Form_MouseClick;
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
		
		private void Form_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Location.X < _universeSize * 10 && e.Location.Y < _universeSize * 10)
			{
				_timer.Stop();
				int X = (e.Location.X - e.Location.X % 10) / 10;
				int Y = (e.Location.Y - e.Location.Y % 10) / 10;

				label.Size = new Size(10, 10);
				label.BackColor = Color.Red;
				label.Location = new Point(X * 10, Y * 10);
				Form.ActiveForm.Controls.Add(label);
				Colony.currentColony[X, Y].isAlive = true;
				Debug.WriteLine(e.Location.X + " " + e.Location.Y);
			}
		}
	}
}
