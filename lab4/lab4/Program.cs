using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Linq;

namespace lab4
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			using (AppContext context = new AppContext())
			{
				var list = context.GetVotes.ToList();
				foreach (var item in list)
				{
					Console.WriteLine($"{item.VotesCount} {item.First} {item.Second} {item.Third} {item.Fourth}");
				}
			}
			Console.ReadKey();
		}
	}
	class Votes
	{
		public int Id { get; set; }
		public int VotesCount { get; set; }
		public string First { get; set; }
		public string Second { get; set; }
		public string Third { get; set; }
		public string Fourth { get; set; }
	}
	class AppContext: DbContext
	{
		public DbSet<Votes> GetVotes { get; set; }
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-OSOHBHJ; Database=lab4; Trusted_Connection=true;");
		}
	}
}
