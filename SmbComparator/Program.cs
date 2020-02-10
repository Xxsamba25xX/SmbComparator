using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace SmbComparator
{
	class Program
	{
		static void Main(string[] args)
		{
			Envelope aux = new XmlSerializer().DeserializeObject<Envelope>(File.ReadAllText("File/file.xml"));
			Envelope aux2 = new XmlSerializer().DeserializeObject<Envelope>(File.ReadAllText("File/file2.xml"));

			var nana = "asda";
			var nono = "asdasda";
			StringBuilder sb = new StringBuilder();
			var c = new Comparer<String>(nana, nono);
			sb.AppendLine(c.GetTypeInfo(typeof(String)));
			sb.AppendLine(c.GetTypeInfo(typeof(string)));
			sb.AppendLine(c.GetTypeInfo(typeof(int)));
			sb.AppendLine(c.GetTypeInfo(typeof(long)));
			sb.AppendLine(c.GetTypeInfo(typeof(bool)));
			sb.AppendLine(c.GetTypeInfo(typeof(Object)));
			sb.AppendLine(c.GetTypeInfo((new string[] { "", "asda" }).GetType()));
			sb.AppendLine(c.GetTypeInfo(typeof(Envelope)));

			File.WriteAllText("log.txt", sb.ToString());
			c.Compare();

			Console.ReadKey();

			//foreach (var item in a.GetType().GetProperties())
			//{
			//	Debug.WriteLine(item.Name);
			//	foreach (var subItem in item.PropertyType.GetType().GetProperties())
			//	{
			//		if (subItem.PropertyType.IsGenericType)
			//		{
			//			Debug.WriteLine("\t" + subItem.Name + " = '" + subItem.GetValue(item.PropertyType, null) + "'");
			//		}
			//		else
			//		{
			//			Debug.WriteLine("\t" + subItem.Name);
			//		}
			//	}
			//}
		}



	}
}
