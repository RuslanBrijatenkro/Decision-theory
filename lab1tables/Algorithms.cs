using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1tables
{
	class Algorithms
	{
		public static int[] mas1 = new int[] { 40  , 29 , 31 , 17 , 97 , 71 , 81 , 75 , 09 , 27 , 67 , 56 , 97 , 53 , 86 , 65 , 06 , 83 , 19 , 24 ,28 ,  71 , 32 , 29 , 03 , 19 , 70 , 68 ,
			08 , 15 , 40 , 49 , 96 , 23 , 18 , 45 , 46 , 51 , 21 , 55 ,79 ,  88 , 64 , 28 , 41 , 50 , 93 , 51 , 34 , 64 , 24 , 14 , 87 , 56 ,
			43 , 91  ,27  ,65  ,59  ,36 };
		public int[,] mas1q1q2 = new int[mas1.Length, 2];
		public List<int[]> decisionPareto = new List<int[]>();
		public List<int[]> decisionSlayter = new List<int[]>();
		public void StartMethod()
		{
			CreateAlternative();
			SlayterAlgorithm();
			ParetoAlgorithm();
		}
		public void ParetoAlgorithm()
		{
			int i = 0, j = 1;
			goto Two;
		Two:
			{
				if (mas1q1q2[i, 0] >= mas1q1q2[j, 0] && mas1q1q2[i, 1] >= mas1q1q2[j, 1])
					goto Three;
				else
					goto Five;
			}
		Three:
			{
				decisionPareto.RemoveAt(j);
				decisionPareto.Insert(j, null);
				goto Four;
			}
		Four:
			{
				if (j < decisionPareto.Count - 1)
				{
					j++;
					goto Two;
				}
				else
					goto Seven;
			}
		Five:
			{
				if (mas1q1q2[i, 0] <= mas1q1q2[j, 0] && mas1q1q2[i, 1] <= mas1q1q2[j, 1])
					goto Six;
				else
					goto Four;

			}
		Six:
			{
				decisionPareto.RemoveAt(i);
				decisionPareto.Insert(i, null);
				goto Seven;
			}
		Seven:
			{
				if (i < decisionPareto.Count - 2)
				{
					i++;
					j = i + 1;
					goto Two;
				}
				else
					goto End;
			}
		End:
			{
				foreach (int[] element in decisionPareto)
				{
					try
					{
						Console.Write(element[0] + " ");
						Console.WriteLine(element[1]);
					}
					catch (Exception) { }
				}
			}
		}
		public void SlayterAlgorithm()
		{
			int i = 0, j = 1;
			goto Two;
		Two:
			{
				if (mas1q1q2[i, 0] > mas1q1q2[j, 0] && mas1q1q2[i, 1] > mas1q1q2[j, 1])
					goto Three;
				else
					goto Five;
			}
		Three:
			{
				decisionSlayter.RemoveAt(j);
				decisionSlayter.Insert(j, null);
				goto Four;
			}
		Four:
			{
				if (j < decisionPareto.Count - 1)
				{
					j++;
					goto Two;
				}
				else
					goto Seven;
			}
		Five:
			{
				if (mas1q1q2[i, 0] < mas1q1q2[j, 0] && mas1q1q2[i, 1] < mas1q1q2[j, 1])
					goto Six;
				else
					goto Four;

			}
		Six:
			{
				decisionSlayter.RemoveAt(i);
				decisionSlayter.Insert(i, null);
				goto Seven;
			}
		Seven:
			{
				if (i < decisionPareto.Count - 2)
				{
					i++;
					j = i + 1;
					goto Two;
				}
				else
					goto End;
			}
		End:
			{
				foreach (int[] element in decisionSlayter)
				{
					try
					{
						Console.Write(element[0] + " ");
						Console.WriteLine(element[1]);
					}
					catch (Exception) { }
				}
			}
		}
		public void CreateAlternative()
		{
			for (int i = 0; i < mas1.Length; i++)
			{
				mas1q1q2[i, 0] = mas1[i] / 10;
				mas1q1q2[i, 1] = mas1[i] % 10;
				decisionPareto.Add(new int[] { mas1q1q2[i, 0], mas1q1q2[i, 1] });
				decisionSlayter.Add(new int[] { mas1q1q2[i, 0], mas1q1q2[i, 1] });
			}
		}
	}
}
