using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
	public partial class Form1 : Form
	{
		public List<int[]> list = new List<int[]>(4);
		public List<List<int>> containers;
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

					NFA(listOfGoods[i]);
					FFA(listOfGoods[i]);
					WFA(listOfGoods[i]);
					BFA(listOfGoods[i]);


					for(int q=0;q<list.Count;q++)
					{
						results[q + 1] = list[q][0];
						difficults[q + 1] = list[q][1];
					}
					dataGridViews[y].Rows.Add(results);
					dataGridViews[y+3].Rows.Add(difficults);
					list.Clear();
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

		public void NFA(int[] goods)
		{
			int difficult = 0;
			int count = 0;
			containers = new List<List<int>>();
			containers.Add(new List<int>());
			count = 1;
			foreach (var item in goods)
			{
				difficult++;
				if (containers[count - 1].Sum() + item <= 100)
				{
					containers[count - 1].Add(item);
				}
				else
				{
					count++;
					containers.Add(new List<int>());
					containers[count - 1].Add(item);
				}
			}
			list.Add(new int[] { count, difficult });
		}
		public void FFA(int[] goods)
		{
			int difficult = 0;
			int count = 0;
			containers = new List<List<int>>();
			containers.Add(new List<int>());
			count++;
			foreach (var item in goods)
			{
				difficult++;
				if (containers[count - 1].Sum() + item <= 100)
				{
					containers[count - 1].Add(item);
				}
				else
				{
					for (int i = containers.Count; i > 0; i--)
					{
						difficult++;
						if (containers[i - 1].Sum() + item <= 100)
						{
							containers[i - 1].Add(item);
							break;
						}
						else if (i == 1)
						{
							count++;
							containers.Add(new List<int>());
							containers[count - 1].Add(item);
							break;
						}
					}
				}
			}
			list.Add(new int[] { count, difficult });
		}
		public void WFA(int[] goods)
		{
			int difficult = 0;
			int count = 0;
			int containerWithMinWeight;
			containers = new List<List<int>>();
			containers.Add(new List<int>());
			count++;
			foreach (var item in goods)
			{
				difficult++;
				if (containers[count - 1].Sum() + item <= 100)
					containers[count - 1].Add(item);
				else
				{
					containerWithMinWeight = containers.Count - 1;
					foreach (var container in containers)
					{
						difficult++;
						if (container.Sum() <= containers[containerWithMinWeight].Sum())
							containerWithMinWeight = containers.IndexOf(container);
					}
					difficult++;
					if (containers[containerWithMinWeight].Sum() + item <= 100)
						containers[containerWithMinWeight].Add(item);
					else
					{
						containers.Add(new List<int>());
						count++;
						containers[count - 1].Add(item);
					}
				}
			}
			list.Add(new int[] { count, difficult });
		}
		public void BFA(int[] goods)
		{
			int difficult = 0;
			int count = 0;
			int containerWithMinFree;
			containers = new List<List<int>>();
			containers.Add(new List<int>());
			count++;
			foreach (var item in goods)
			{
				difficult++;
				if (containers[count - 1].Sum() + item <= 100)
					containers[count - 1].Add(item);
				else
				{
					containerWithMinFree = -1;
					foreach (var container in containers)
					{
						difficult++;
						if (item <= 100 - container.Sum())
						{
							try
							{
								difficult++;
								if (100 - container.Sum() <= 100 - containers[containerWithMinFree].Sum())
									containerWithMinFree = containers.IndexOf(container);
							}
							catch (Exception)
							{
								containerWithMinFree = containers.IndexOf(container);
							}
						}
					}
					try
					{
						difficult++;
						if (100 - containers[containerWithMinFree].Sum() >= item)
							containers[containerWithMinFree].Add(item);
					}
					catch (Exception)
					{
						containers.Add(new List<int>());
						count++;
						containers[count - 1].Add(item);
					}
				}
			}
			list.Add(new int[] { count, difficult });
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
