using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO.Compression;
using System.IO;

namespace Craftopia
{
	class SaveData
	{
		private static SaveData mThis;
		public JObject Root { get; private set; }
		private string mFileName;

		public static SaveData Instance()
		{
			if (mThis == null) mThis = new SaveData();
			return mThis;
		}

		private SaveData() { }

		public bool Open(String filename, bool force)
		{
			if (System.IO.File.Exists(filename) == false) return false;

			Root = null;
			mFileName = filename;
			Byte[] tmp = System.IO.File.ReadAllBytes(filename);

			using(var ms = new MemoryStream())
			{
				using(var gzip = new GZipStream(new MemoryStream(tmp), CompressionMode.Decompress))
				{
					gzip.CopyTo(ms);
					Byte[] buffer = ms.GetBuffer();
					String json = System.Text.Encoding.UTF8.GetString(buffer);
					Root = JObject.Parse(json);
					Backup();
				}
			}
			
			return true;
		}

		public void Save()
		{
			if (String.IsNullOrEmpty(mFileName) || Root == null) return;

			Byte[] tmp = System.Text.Encoding.UTF8.GetBytes(Root.ToString());
			using (var ms = new MemoryStream(tmp))
			{
				using(var fs = System.IO.File.Open(mFileName, FileMode.OpenOrCreate))
				{
					using (var gzip = new GZipStream(fs, CompressionMode.Compress))
					{
						ms.CopyTo(gzip);
					}
				}
			}
		}

		public void SaveAs(String filename)
		{
			if (Root == null) return;
			mFileName = filename;
			Save();
		}

		public void Export(String filename)
		{
			if (String.IsNullOrEmpty(mFileName)) return;

			System.IO.File.WriteAllText(filename, Root.ToString());
		}

		public void Import(String filename)
		{
			Root = JObject.Parse(System.IO.File.ReadAllText(filename));
		}

		private void Backup()
		{
			DateTime now = DateTime.Now;
			String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			path = System.IO.Path.Combine(path, "backup");
			if (!System.IO.Directory.Exists(path))
			{
				System.IO.Directory.CreateDirectory(path);
			}
			path = System.IO.Path.Combine(path,
				String.Format("{0:0000}-{1:00}-{2:00} {3:00}-{4:00}", now.Year, now.Month, now.Day, now.Hour, now.Minute));
			System.IO.File.Copy(mFileName, path, true);
		}
	}
}
