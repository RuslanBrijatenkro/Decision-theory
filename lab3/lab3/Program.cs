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
			Console.ReadKey()
			string commandText1 = "SELECT Temperature FROM StartData";
			string commandText2 = "SELECT Temperature FROM SetsOfClothing";
			string commandText3 = "SELECT Hat,Outerear,Gloves,Trousers,Footwear FROM SetsOfClothing";
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				sqlCommand = new SqlCommand(commandText1, connection);

				SqlDataReader startTemperature = sqlCommand.ExecuteReader();
				sqlCommand = new SqlCommand(commandText2, connection);
				SqlDataReader clothingSetsTemperature = sqlCommand.ExecuteReader();
				sqlCommand = new SqlCommand(commandText3, connection);
				SqlDataReader clothingSetsItems = sqlCommand.ExecuteReader();

			}
			Console.ReadKey();
		}
		void Start()
		{

		}
	}
}
