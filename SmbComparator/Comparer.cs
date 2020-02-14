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
		Queue<(Type type, List<string> path, object val1, object val2)> queue { get; set; } = new Queue<(Type type, List<string> path, object val1, object val2)>();

		public void Compare()
		{
			var type = Original.GetType();
			queue.Enqueue((type, new List<string>(), Original, Modified));
			//Recorrer todas las propiedades.
			while (queue.Count > 0)
			{
				var queueItem = queue.Dequeue();
				type = queueItem.type;
				var currentPath = queueItem.path;
				var val1 = queueItem.val1;
				var val2 = queueItem.val2;

				if (type.IsValueType)
				{
					if (type.IsPrimitive)
					{
						Console.WriteLine($"({type.Name}){String.Join('\\', currentPath)}= {val1} || {val2}");
					}
					else if (type.FullName.StartsWith("System."))
					{
						foreach (var field in type.GetFields())
						{
							var newPath = new List<string>(currentPath);
							newPath.Add($"{field.Name}");
							queue.Enqueue((field.FieldType, newPath, field.GetValue(val1), field.GetValue(val2)));
						}
					}
				}
				else
				{
					if (type.FullName == "System.String")
					{
						Console.WriteLine($"({type.Name}){String.Join('\\', currentPath)}= {val1} || {val2}");
					}
					else
					{
						var properties = type.GetProperties();
						if (properties.Length > 0)
						{
							foreach (var item in properties)
							{
								var newPath = new List<string>(currentPath);
								newPath.Add($"{item.Name}");
								queue.Enqueue((item.PropertyType, newPath, item.GetValue(val1), item.GetValue(val2)));
							}
						}
						else
						{
							Console.WriteLine($"({type.Name}){String.Join('\\', currentPath)}= ObjectId({val1.GetHashCode()}) || ObjectId({val2.GetHashCode()})");
						}
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
			foreach (var item in aux.OrderBy(x => x.Name))
			{
				if (item.PropertyType.Name != "Boolean") continue;
				var auxiliar = item.GetValue(type).ToString();
				if (auxiliar == "False") continue;

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
