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
			Algorithm algorithm = new Algorithm();
			algorithm.Run();
			Console.ReadKey();
		}
	}
}
