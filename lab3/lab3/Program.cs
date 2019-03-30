using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
namespace lab3
{
	class Program
	{
		static SqlCommand sqlCommand;
		static void Main(string[] args)
		{
			double f = 31d / 366;
			double s = 30d / 366;
			double t = 29d / 366;
			Algorithm algorithm = new Algorithm();
			algorithm.Run();
			Console.WriteLine(154d*f+154d*t+116d*f+84d*s+84d*f+30d*s+30d*f+84d*f+84d*s+116d*f+116d*s+116d*f);
			Console.ReadKey();
		}
	}
}
