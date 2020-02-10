using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmbComparator
{
	public class Comparer<T>
		where T : class
	{
		public Comparer(T original, T modified)
		{
			Original = original;
			Modified = modified;
		}

		public string Report { get; set; }
		private T Original { get; set; }
		private T Modified { get; set; }
		Queue<(Type type, object val1, object val2)> queue { get; set; } = new Queue<(Type type, object val1, object val2)>();

		public void Compare()
		{
			var type = Original.GetType();
			queue.Enqueue((type, Original, Modified));
			//Recorrer todas las propiedades.
			while (queue.Count > 0)
			{
				var queueItem = queue.Dequeue();
				type = queueItem.type;
				var val1 = queueItem.val1;
				var val2 = queueItem.val2;
				foreach (var item in type.GetProperties())
				{
					var itmType = item.PropertyType;
					Console.WriteLine(JsonConvert.SerializeObject(type));
					Console.WriteLine($"Type: '{itmType.Name}'[ Class: {itmType.IsClass}, Public: {itmType.IsPublic}, Value: {itmType.IsValueType} ]");
					if (itmType.IsClass && itmType.IsPublic && !itmType.IsValueType)
					{
						queue.Enqueue((itmType, item.GetValue(val1), item.GetValue(val2)));
					}
					else
					{
						var asdasd = item.GetIndexParameters()[0];
						var auxa = item.GetValue(val1, new object[] { 1 });

						Console.WriteLine($"{item.GetValue(val1)} || {item.GetValue(val2)}");
					}
				}
			}
			//Si encuentro una propiedad compuesta meterlo a la cola de procesamiento
			//Al terminar de recorrer todas las propiedades Comenzar a recorrer la cola
			//Asi hasta terminar...
		}


		public string GetTypeInfo(Type type)
		{
			var aux = typeof(Type).GetProperties();
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("{");
			sb.AppendLine($"\"Name\":\"{type.Name}\",");
			sb.AppendLine($"\"Info\":[");
			foreach (var item in aux)
			{
				sb.AppendLine("{");
				sb.AppendLine($"\"Name\": \"{item.Name}\",");
				sb.AppendLine($"\"Type\": \"{item.PropertyType.Name}\",");
				try
				{
					sb.AppendLine($"\"Value\": \"{item.GetValue(type)}\"");
				}
				catch (Exception ex)
				{
					sb.AppendLine($"\"Value\": \"{$"No se pudo leer propiedad: {ex.Message}"}\"");
				}
				sb.AppendLine("},");
			}
			sb.AppendLine("]");
			sb.AppendLine("}");
			return sb.ToString();
		}
	}
}
