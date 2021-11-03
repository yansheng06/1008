using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1008.Services
{
	class DataService
	{
		private string _connectionString = @"Server=.;Database=NKUST;Trusted_Connection=True";


	public void GetHospitals()
	{
			SqlConnection cn = new SqlConnection(_connectionString);

			cn.Open();

			SqlCommand command = new SqlCommand("Select * from hospital1", cn);

			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				var id = reader["id"];
				var tencode = reader["tencode"];
				var name = reader["name"];
				var district = reader["district"];
				var address = reader["address"];
				var phone = reader["phone"];
			}
			cn.Close();
	}
}
	}
	
