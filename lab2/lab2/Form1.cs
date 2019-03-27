using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lab2
{
	public partial class Form1 : Form
	{
		object[] results = new object[5];
		object[] difficults = new object[5];
		List<int[]> listOfGoods = new List<int[]>();
		List<DataGridView> dataGridViews = new List<DataGridView>();
		int temp;
		public Form1()
		{
			InitializeComponent();
		}
		void Start()
		{
			Algorithms algorithms = new Algorithms();
			listOfGoods.Add(new int[] { 40, 29, 31, 17, 97, 71, 81, 75, 09, 27, 67, 56, 97, 53, 86, 65, 06, 83, 19, 24 });
			listOfGoods.Add(new int[] { 28, 71, 32, 29, 03, 19, 70, 68, 08, 15, 40, 49, 96, 23, 18, 45, 46, 51, 21, 55 });
			listOfGoods.Add(new int[] { 79, 88, 64, 28, 41, 50, 93, 51, 34, 64, 24, 14, 87, 56, 43, 91, 27, 65, 59, 36 });
			listOfGoods.Add(new int[] { 40, 29, 31, 17, 97, 71, 81, 75, 09, 27, 67, 56, 97, 53, 86, 65, 06, 83, 19, 24,
										28, 71, 32, 29, 03, 19, 70, 68, 08, 15, 40, 49, 96, 23, 18, 45, 46, 51, 21, 55,
										79, 88, 64, 28, 41, 50, 93, 51, 34, 64, 24, 14, 87, 56, 43, 91, 27, 65, 59, 36 });
			dataGridViews.Add(dataGridView1);
			dataGridViews.Add(dataGridView2);
			dataGridViews.Add(dataGridView3);
			dataGridViews.Add(dataGridView4);
			dataGridViews.Add(dataGridView5);
			dataGridViews.Add(dataGridView6);

			foreach(var dataGridView in dataGridViews)
			{
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
			}

			for(int y=0;y<3;y++)
			{
				for (int i = 0; i < listOfGoods.Count; i++)
				{
					if(i==3)
					{
						results[0] = "1+2+3";
						difficults[0] = "1+2+3";
					}
					else
					{
						results[0] = i + 1;
						difficults[0] = i + 1;
					}

					algorithms.NFA(listOfGoods[i]);
					algorithms.FFA(listOfGoods[i]);
					algorithms.WFA(listOfGoods[i]);
					algorithms.BFA(listOfGoods[i]);


					for(int q=0;q< algorithms.list.Count;q++)
					{
						results[q + 1] = algorithms.list[q][0];
						difficults[q + 1] = algorithms.list[q][1];
					}
					dataGridViews[y].Rows.Add(results);
					dataGridViews[y+3].Rows.Add(difficults);
					algorithms.list.Clear();
				}
				if (y == 1)
					sortByRecession();
				if (y == 0)
					sortByAscending();
			}
		}
		void sortByRecession()
		{
			foreach (var good in listOfGoods)
			{
				for (int i = 0; i < good.Length - 1; i++)
				{
					for (int j = i + 1; j < good.Length; j++)
					{
						if (good[i] < good[j])
						{
							temp = good[i];
							good[i] = good[j];
							good[j] = temp;
						}
					}
				}
			}
		}
		void sortByAscending()
		{
			foreach (var good in listOfGoods)
			{
				for (int i = 0; i < good.Length - 1; i++)
				{
					for (int j = i + 1; j < good.Length; j++)
					{
						if (good[i] > good[j])
						{
							temp = good[i];
							good[i] = good[j];
							good[j] = temp;
						}
					}
				}
			}
			
		}

		

		private void textbox_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Start();
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
