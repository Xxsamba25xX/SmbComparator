using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace SmbComparator
{
	class Program
	{
		static void Main(string[] args)
		{
			Envelope aux = new XmlSerializer().DeserializeObject<Envelope>(File.ReadAllText("File/file.xml"));
			Envelope aux2 = new XmlSerializer().DeserializeObject<Envelope>(File.ReadAllText("File/file2.xml"));

			var c = new Comparer<Envelope>(aux, aux2);

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
