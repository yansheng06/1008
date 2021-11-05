using _1008.Models;
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


	public List<Hospital> GetHospitals()
	{
			var result = new List<Hospital>();
			SqlConnection cn = new SqlConnection(_connectionString);

			cn.Open();

			SqlCommand command = new SqlCommand("Select * from hospital1", cn);
			
			var indexer = command.ExecuteReader();
			while (indexer.Read())
			{
				var id = indexer["id"];
				var tencode = indexer["tencode"];
				var name = indexer["name"];
				var district = indexer["district"];
				var address = indexer["address"];
				var phone = indexer["phone"];
				var item = new Hospital()
				{ 
					 十碼章=tencode.ToString(),
					 醫院名稱=name.ToString(),
					 行政區=district.ToString(),
					 地址=address.ToString(),
					 連絡電話=phone.ToString(),
					 //Id=long.Parse(id.ToString())
				};
				result.Add(item);
			}
			cn.Close();
			return result;
	}
	public void Insert(Hospital hospital) 
		{
			var commandString = @"
			INSERT INTO [dbo].[hospital1]([tencode],[name],[district],[address],[phone])
			VALUES(@十碼章,@醫院名稱,@行政區,@地址,@連絡電話)";

			SqlConnection cn = new SqlConnection(_connectionString);

			cn.Open();
			SqlCommand command = new SqlCommand(commandString, cn);

			
			command.Parameters.Add(new SqlParameter("十碼章", hospital.十碼章));
			command.Parameters.Add(new SqlParameter("醫院名稱", hospital.醫院名稱));
			command.Parameters.Add(new SqlParameter("行政區", hospital.行政區));
			command.Parameters.Add(new SqlParameter("地址", hospital.地址));
			command.Parameters.Add(new SqlParameter("連絡電話", hospital.連絡電話));
			var count=command.ExecuteNonQuery();
			cn.Close();
		}
}
	}
	
