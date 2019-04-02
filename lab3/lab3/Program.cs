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
			//double a = 1/6d;
			//double b = 1/18d;

			Algorithm algorithm = new Algorithm();
			algorithm.Run();
			//Console.WriteLine(154d*a+154d*a+116d*b+116d*b+84d*b+84d*b+30d*b+30d*b+84d*b+84d*b+116d*b+116d*a);//Task44

			Console.ReadKey();
		}
	}
}
