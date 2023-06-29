using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Craftopia
{
	internal class SaveData
	{
		public Dictionary<String, String> Open(String filename)
		{
			var result = new Dictionary<String, String>();
			if (!File.Exists(filename)) return result;

			using (var connection = new SQLiteConnection($"Data Source = {filename}"))
			{
				connection.Open();
				
				using(var command = connection.CreateCommand())
				{
					command.CommandText = "select * from Entity";
					using(var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							result[reader["id"].ToString()] = reader["value"].ToString();
						}
					}
				}
			}

			return result;
		}

		public void Save(String filename, Dictionary<String, String> dictionary)
		{
			if (!File.Exists(filename)) return;

			using (var connection = new SQLiteConnection($"Data Source = {filename}"))
			{
				connection.Open();

				foreach (var page in dictionary)
				{
					using (var command = connection.CreateCommand())
					{
						command.CommandText = $"update Entity set value = @value where id = @id";
						command.Parameters.Add(new SQLiteParameter("@id", page.Key));
						command.Parameters.Add(new SQLiteParameter("@value", page.Value));
						command.ExecuteNonQuery();
					}
				}
			}
		}
	}
}
