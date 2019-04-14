﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace lab4Realization
{
	class Program
	{
		static void Main(string[] args)
		{
			Algorithms algorithms = new Algorithms();
			algorithms.Run();
			Console.ReadKey();
		}
	}
	class Algorithms
	{
		public void Run()
		{
			//Bord();
			Coplend();
		}
		void Bord()
		{
			Dictionary<string, int> result = new Dictionary<string, int>();
			using (lab4Context context = new lab4Context())
			{
				var list = context.GetVotes.ToList();
				foreach (var item in list)
				{
					string[] candidates = new string[] { item.Fourth, item.Third, item.Second, item.First };
					int value;
					for (int i = 0; i < candidates.Length; i++)
					{
						if (result.TryGetValue(candidates[i], out value))
						{
							value += item.VotesCount * i;
							result[candidates[i]] = value;
						}
						else
						{
							value = item.VotesCount * i;
							result.Add(candidates[i], value);
						}
					}
				}
			}
			string message = null;
			int max = 0;
			foreach (var item in result)
			{
				Console.WriteLine($"{item.Key}-{item.Value}");
				if (item.Value > max)
				{
					max = item.Value;
					message = $"Winner! Candidate: {item.Key} Scores: {item.Value}";
				}
				else if (item.Value == max)
				{
					message = "Need more data for correct result";
				}
			}
			Console.WriteLine(message);
		}
		void Coplend()
		{
			Dictionary<string, int> scores = new Dictionary<string, int>();
			using (lab4Context context = new lab4Context())
			{
				var list = context.GetVotes.ToList();
				string[] candidates = new string[] {"a","b","c","d"};
				foreach (var item in candidates)
				{
					scores.Add(item, 0);
				}
				for (int i = 0; i < candidates.Length; i++)
				{
					for (int j = i+1; j <candidates.Length ; j++)
					{
						int IScores = 0;
						int JScores = 0;
						foreach(var item in list)
						{
							string[] brrrrr = new string[] { item.First, item.Second, item.Third, item.Fourth };
							for(int q=0;q<brrrrr.Length;q++)
							{
								if(candidates[i]==brrrrr[q])
								{
									IScores += item.VotesCount;
									break;
								}
								else if(candidates[j]==brrrrr[q])
								{
									JScores += item.VotesCount;
									break;
								}
							}
						}
						if (IScores > JScores)
						{
							scores[candidates[i]]++;
							scores[candidates[j]]--;
						}
						else
						{
							scores[candidates[j]]++;
							scores[candidates[i]]--;
						}
					}
				}
				foreach (var item in scores)
				{
					Console.WriteLine($"{item.Key}-{item.Value}");
				}
			}
		}
	}
}
