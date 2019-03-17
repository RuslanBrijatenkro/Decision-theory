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
		SqlCommand sqlCommand;
		SqlConnection connection;
		string command;
		SqlDataReader reader;
		string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
		public void Run()
		{
			connection = new SqlConnection();
			command = "SELECT * FROM StartData";
			sqlCommand = new SqlCommand(command, connection);
			reader = sqlCommand.ExecuteReader();
		}
	}
}
