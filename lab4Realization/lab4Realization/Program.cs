using System;
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
			Console.WriteLine("Bord");
			Bord();
			Console.WriteLine("Coplend");
			Coplend();
			Console.WriteLine("Parallel");
			Parallel();
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
				string message = null;
				int max=0;
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
							Console.WriteLine($"{candidates[i]}: {IScores} > {candidates[j]}: {JScores}");
							scores[candidates[i]]++;
							scores[candidates[j]]--;
						}
						else
						{
							Console.WriteLine($"{candidates[i]}: {IScores} < {candidates[j]}: {JScores}");
							scores[candidates[j]]++;
							scores[candidates[i]]--;
						}
					}
				}
				foreach (var item in scores)
				{
					if (item.Value > max)
					{
						max = item.Value;
						message = $"Winner! {item.Key} score:{item.Value}";
					}
					Console.WriteLine($"{item.Key} score:{item.Value}");
				}
				Console.WriteLine(message);
			}
		}
		void Parallel()
		{
			Dictionary<string, int> result = new Dictionary<string, int>();
			using (lab4Context context = new lab4Context())
			{
				var list = context.GetVotes.ToList();
				List<string> candidates = new List<string> {list[0].First, list[0].Second, list[0].Third , list[0].Fourth };
				foreach(var item in candidates)
				{
					result.Add(item, 0);
				}
				while(result.Count!=1)
				{
					int value;
					for (int i = 0; i < result.Count; i++)
					{
						if(result.TryGetValue(candidates[i],out value))
						{
							result[candidates[i]] = 0;
						}
					}
					for (int i = 0; i < candidates.Count;)
					{
						try
						{
							Comparison(candidates[i], candidates[++i]);
						}
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
							break;
						}
					}
				}
				foreach (var item in result)
				{
					Console.WriteLine("Winner - "+item.Key+":"+item.Value);
				}
				Console.ReadKey();
				void Comparison(string first, string second)
				{
					foreach (var item in list)
					{
						string[] brrrrr = new string[] { item.First, item.Second, item.Third, item.Fourth };
						for (int i = 0; i < brrrrr.Length; i++)
						{
							if(first==brrrrr[i])
							{
								result[first] += item.VotesCount;
								break;
							}
							else if(second==brrrrr[i])
							{
								result[second] += item.VotesCount;
								break;
							}
						}
					}
					if(result[first]>result[second])
					{
						Console.WriteLine(second+":"+result[second]+" < "+first+":"+result[first]);
						Console.WriteLine(second+":"+result[second]+" deleted");
						candidates.Remove(second);
						result.Remove(second);
					}
					else
					{
						Console.WriteLine(first + ":" + result[first] + " < " + second + ":" + result[second]);
						Console.WriteLine(first + ":" + result[first] + " deleted");
						candidates.Remove(first);
						result.Remove(first);
					}
				}
			}

		}
	}
}
