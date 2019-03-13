using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
	public partial class Form1 : Form
	{
		object[] results = new object[5];
		public Form1()
		{
			InitializeComponent();
		}
		void Start()
		{
			int[] goods1 = new int[] { 40, 29, 31, 17, 97, 71, 81, 75, 09, 27, 67, 56, 97, 53, 86, 65, 06, 83, 19, 24 };
			int[] goods2 = new int[] { 28,71, 32, 29, 03, 19, 70, 68, 08, 15, 40, 49, 96, 23, 18, 45, 46, 51, 21, 55 };
			int[] goods3 = new int[] { 79, 88, 64, 28, 41, 50, 93, 51, 34, 64, 24, 14, 87, 56, 43, 91, 27, 65, 59, 36 };
			Algorithms algorithms = new Algorithms();
			DataGridView dataGridView = dataGridView1;
			dataGridView.Columns.Add("Data", "Data");
			dataGridView.Columns.Add("NFA", "NFA");
			dataGridView.Columns.Add("FFA", "FFA");
			dataGridView.Columns.Add("WFA", "WFA");
			dataGridView.Columns.Add("BFA", "BFA");
			dataGridView.Columns["Data"].Width = 50;
			dataGridView.Columns["NFA"].Width = 50;
			dataGridView.Columns["FFA"].Width = 50;
			dataGridView.Columns["WFA"].Width = 50;
			dataGridView.Columns["BFA"].Width = 50;

			results[0] = "1";
			algorithms.NFA(goods1);
			results[1] = algorithms.count;
			algorithms.FFA(goods1);
			results[2] = algorithms.count;
			algorithms.WFA(goods1);
			results[3] = algorithms.count;
			algorithms.BFA(goods1);
			results[4] = algorithms.count;
			dataGridView.Rows.Add(results);

			results[0] = "2";
			algorithms.NFA(goods2);
			results[1] = algorithms.count;
			algorithms.FFA(goods2);
			results[2] = algorithms.count;
			algorithms.WFA(goods2);
			results[3] = algorithms.count;
			algorithms.BFA(goods2);
			results[4] = algorithms.count;
			dataGridView.Rows.Add(results);

			results[0] = "3";
			algorithms.NFA(goods3);
			results[1] = algorithms.count;
			algorithms.FFA(goods3);
			results[2] = algorithms.count;
			algorithms.WFA(goods3);
			results[3] = algorithms.count;
			algorithms.BFA(goods3);
			results[4] = algorithms.count;
			dataGridView.Rows.Add(results);
		}

		private void textbox_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Start();
		}
	}
}
