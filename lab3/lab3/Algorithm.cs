using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace lab3
{
	enum Mounths
	{
		January,
		February,
		March,
		April,
		May,
		June,
		Jule,
		August,
		September,
		October,
		November,
		December

	}
	class Algorithm
	{
		int set=0;
		int[] temperatures = new int[] { -11, -11, -6, -1, 4, 10, 13, 11, 7, 1, -5, -9 };
		int costs = 0;
		SqlCommand sqlCommand;
		SqlConnection connection;
		SqlConnection connection2;
		SqlConnection connection3;
		SqlConnection connection4;
		SqlConnection connection5;
		string command;
		SqlDataReader reader;
		SqlDataReader reader2;
		SqlDataReader reader3;
		string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
		public void Run()
		{
			command = "SELECT Hat,Outerwear,Gloves,Trousers,Footwear,Weight FROM SetsOfClothes";
			connection = new SqlConnection(connectionString);
			connection2 = new SqlConnection(connectionString);
			connection3 = new SqlConnection(connectionString);
			connection4 = new SqlConnection(connectionString);
			connection5 = new SqlConnection(connectionString);
			connection.Open();
			sqlCommand = new SqlCommand(command, connection);
			reader = sqlCommand.ExecuteReader();
			while (reader.Read())
			{
				set++;
				connection5.Open();
				command = $"UPDATE ResultFirst SET WeightCost={Convert.ToDouble(reader.GetValue(5))*10} WHERE SetNumber = {set}";
				sqlCommand = new SqlCommand(command, connection5);
				sqlCommand.ExecuteNonQuery();
				connection5.Close();
				for (int i =0; i<temperatures.Length;i++)
				{
					costs = 0;
					connection2.Open();
					command = $"SELECT TOP 1 Hat,Outerwear,Gloves,Trousers,Footwear FROM SetsOfClothes WHERE Temperature>={temperatures[i]}";
					sqlCommand = new SqlCommand(command, connection2);
					reader2 = sqlCommand.ExecuteReader();
					reader2.Read();
					for (int y=0;y<5;y++)
					{
						Console.Write(reader.GetValue(y)+" ");
						Console.WriteLine(reader2.GetValue(y));
						try
						{
							if ((string)reader.GetValue(y) != (string)reader2.GetValue(y))
							{
								connection3.Open();
								command = $"SELECT Price FROM ClothingItems WHERE ClothingItem = '{reader2.GetValue(y)}'";
								sqlCommand = new SqlCommand(command, connection3);
								reader3 = sqlCommand.ExecuteReader();
								reader3.Read();
								costs += (int)reader3.GetValue(0) + 2;
								connection3.Close();
							}
						}
						catch (Exception) { }
						
					}
					connection4.Open();
					command = $"UPDATE ResultFirst SET [{i+1}]={costs} WHERE SetNumber = {set}";
					sqlCommand = new SqlCommand(command, connection4);
					sqlCommand.ExecuteNonQuery();
					connection2.Close();
					connection4.Close();
				}
			}
			
		}
	}
}
