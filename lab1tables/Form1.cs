using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1tables
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		public void Start()
		{
			Algorithms algorithms = new Algorithms();
			algorithms.StartMethod();
			Graphics paretoGraphic = Pareto.CreateGraphics();
			Graphics slayterGraphic = Slayter.CreateGraphics();
			Point[] points = new Point[algorithms.mas1q1q2.Length / 2];
			Pen pen = new Pen(Color.Black,5);
			Pen pen1 = new Pen(Color.Black);
			Pen pen2 = new Pen(Color.Red,5);
			//graphic.DrawLine(pen, 100, 100, 100, 200);
			paretoGraphic.DrawLine(pen1,0,0,0,Pareto.Height);
			//graphic.DrawRectangle(pen1, 100, 100, 200, 200);
			for(int i=0;i<10;i++)
			{
				paretoGraphic.DrawLine(pen1, 0, Pareto.Height - (Pareto.Height / 10) * i, 10, Pareto.Height - (Pareto.Height / 10) * i);
			}
			paretoGraphic.DrawLine(pen1, 0, Pareto.Height-1, Pareto.Width, Pareto.Height-1);
			for (int i = 0; i < 10; i++)
			{
				paretoGraphic.DrawLine(pen1, i * (Pareto.Width / 10), Pareto.Height, i * (Pareto.Width / 10), Pareto.Height - 10);
			}
			for (int i = 0; i < algorithms.mas1q1q2.Length / 2; i++)
			{
				points[i].X = algorithms.mas1q1q2[i, 0];
				points[i].Y = algorithms.mas1q1q2[i, 1];
				paretoGraphic.DrawRectangle(pen, points[i].X * 50-3, Pareto.Height -3 - points[i].Y * 50, 6, 6);
			}
			foreach(int[] item in algorithms.decisionPareto)
			{
				try
				{
					Point point = new Point();
					point.X = item[0];
					point.Y = item[1];
					paretoGraphic.DrawRectangle(pen2, point.X * 50 - 3, Pareto.Height - 3 - point.Y * 50, 6, 6);
				}
				catch (Exception) { }
			}

			slayterGraphic.DrawLine(pen1, 0, 0, 0, Slayter.Height);
			for (int i = 0; i < 10; i++)
			{
				slayterGraphic.DrawLine(pen1, 0, Slayter.Height - (Slayter.Height / 10) * i, 10, Slayter.Height - (Slayter.Height / 10) * i);
			}
			slayterGraphic.DrawLine(pen1, 0, Slayter.Height - 1, Slayter.Width, Slayter.Height - 1);
			for (int i = 0; i < 10; i++)
			{
				slayterGraphic.DrawLine(pen1, i * (Slayter.Width / 10), Slayter.Height, i * (Slayter.Width / 10), Slayter.Height - 10);
			}
			for (int i = 0; i < algorithms.mas1q1q2.Length / 2; i++)
			{
				points[i].X = algorithms.mas1q1q2[i, 0];
				points[i].Y = algorithms.mas1q1q2[i, 1];
				slayterGraphic.DrawRectangle(pen, points[i].X * 50 - 3, Slayter.Height - 3 - points[i].Y * 50, 6, 6);
			}
			foreach (int[] item in algorithms.decisionSlayter)
			{
				try
				{
					Point point = new Point();
					point.X = item[0];
					point.Y = item[1];
					slayterGraphic.DrawRectangle(pen2, point.X * 50 - 3, Slayter.Height - 3 - point.Y * 50, 6, 6);
				}
				catch (Exception) { }
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Start();
			button1.Hide();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}
	}
}
