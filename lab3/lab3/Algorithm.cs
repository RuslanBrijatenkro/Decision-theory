using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace lab3
{
	class Algorithm
	{
		int set=0;
		int minimalExpenses;
		int minimalExpensesSet;
		int setExpenceses;
		int[] temperatures = new int[] { -11, -11, -6, -1, 4, 10, 13, 11, 7, 1, -5, -9 };
		int costs = 0;

		SqlCommand sqlCommand;

		SqlConnection connection;
		SqlConnection connection2;
		SqlConnection connection3;
		SqlConnection executeQueryConnection;

		string command;

		SqlDataReader reader;
		SqlDataReader reader2;
		SqlDataReader reader3;

		string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
		string tableName;

		public void Run()
		{
			connection = new SqlConnection(connectionString);
			connection2 = new SqlConnection(connectionString);
			connection3 = new SqlConnection(connectionString);
			executeQueryConnection = new SqlConnection(connectionString);
			tableName=Console.ReadLine();
			FillResultTable();

		}
		void FillResultTable()
		{
			reader = ExecuteReader("SELECT Hat,Outerwear,Gloves,Trousers,Footwear,Weight FROM SetsOfClothes", connection);

			ExecuteQuery($"CREATE TABLE {tableName}(SetNumber nvarchar(50), WeightCost float);");

			for (int i = 0; i < temperatures.Length; i++)
			{
				ExecuteQuery($"ALTER TABLE {tableName} ADD [{i + 1}] int");
			}

			while (reader.Read())
			{
				set++;

				ExecuteQuery($"INSERT INTO {tableName}(SetNumber) VALUES ({set});");
				ExecuteQuery($"UPDATE {tableName} SET WeightCost={Convert.ToDouble(reader.GetValue(5)) * 10} WHERE SetNumber = {set}");

				for (int i = 0; i < temperatures.Length; i++)
				{
					costs = 0;
					reader2 = ExecuteReader($"SELECT TOP 1 Hat,Outerwear,Gloves,Trousers,Footwear FROM SetsOfClothes WHERE Temperature>={temperatures[i]}", connection2);
					reader2.Read();
					for (int y = 0; y < 5; y++)
					{
						Console.Write(reader.GetValue(y) + " ");
						Console.WriteLine(reader2.GetValue(y));
						try
						{
							if ((string)reader.GetValue(y) != (string)reader2.GetValue(y))
							{
								reader3 = ExecuteReader($"SELECT Price FROM ClothingItems WHERE ClothingItem = '{reader2.GetValue(y)}'", connection3);
								reader3.Read();
								costs += (int)reader3.GetValue(0) + 2;
								connection3.Close();
							}
						}
						catch (Exception) { }

					}
					ExecuteQuery($"UPDATE {tableName} SET [{i + 1}]={costs} WHERE SetNumber = {set}");
					connection2.Close();
				}
			}
			reader.Close();
			set = 0;
			command =	$"SELECT * INTO #TemporaryTable FROM {tableName} " +
						$"ALTER TABLE #TemporaryTable " +
						$"DROP COLUMN SetNumber " +
						$"SELECT* FROM #TemporaryTable " +
						$"DROP TABLE #TemporaryTable ";
			sqlCommand = new SqlCommand(command, connection);
			reader = sqlCommand.ExecuteReader();

			Console.WriteLine();

			while(reader.Read())
			{
				set++;
				for(int i=0;i<reader.VisibleFieldCount;i++)
				{
					setExpenceses+=Convert.ToInt32(reader.GetValue(i));
				}
				if(setExpenceses<minimalExpenses||set==1)
				{
					minimalExpenses = setExpenceses;
					minimalExpensesSet = set;
				}
			}
			Console.WriteLine($"Minimal Expenceses: {minimalExpenses}, Set: {minimalExpensesSet}");
			connection.Close();
		}
		SqlDataReader ExecuteReader(string command, SqlConnection connection)
		{
			connection.Open();
			sqlCommand = new SqlCommand(command, connection);
			return sqlCommand.ExecuteReader();
		}
		void ExecuteQuery(string command)
		{
			executeQueryConnection.Open();
			sqlCommand = new SqlCommand(command, executeQueryConnection);
			sqlCommand.ExecuteNonQuery();
			executeQueryConnection.Close();
		}
	}
}
