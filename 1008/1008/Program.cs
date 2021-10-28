using _1008.Utils;
using System;
using System.Linq;

namespace _1008
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello World!");
			var/*string*/ fullFilename = FilePath.GetFullPath("fluvaccine.csv");
			var csvService = new ConsoleApp.Services.ImportCsvService();
			var csvDatas = csvService.LoadFormFile("fluvaccine.csv");

			Console.WriteLine(string.Format("分析完成，共有{0}筆資料", csvDatas.Count));
			var groupDatas = csvDatas.GroupBy(x => x.行政區, y => y).ToList();
			csvDatas.ForEach(x=>
			{
				Console.WriteLine($"十碼章 : {x.十碼章} 醫院: {x.醫院名稱} 行政區: {x.行政區} 地址:{x.地址} 連絡電話:{x.連絡電話} 座標緯度 : {x.座標緯度} 座標經度 : {x.座標經度}");
			})
	     Console.ReadKey();
		}
	}
}
