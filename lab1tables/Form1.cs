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
		Algorithms algorithms = new Algorithms();
		public Form1()
		{
			InitializeComponent();
		}
		public void Start()
		{
			algorithms.StartMethod();
			Graphics graphic = this.CreateGraphics();
			Point[] points = new Point[algorithms.mas1q1q2.Length/2];
			Pen pen = new Pen(Color.Black);
			for(int i=0;i< algorithms.mas1q1q2.Length/2;i++)
			{
				points[i].X = algorithms.mas1q1q2[i, 0];
				points[i].Y = algorithms.mas1q1q2[i, 1];
				graphic.DrawRectangle(pen,points[i].X*100,points[i].Y*50,10,10);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Start();
		}
	}
}
