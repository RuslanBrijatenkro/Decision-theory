using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
	class Algorithms
	{
		public List<int[]> list = new List<int[]>(4);
		public List<List<int>> containers;
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
	}
}
