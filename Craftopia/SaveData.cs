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
		private string mFilename;

		public static SaveData Instance()
		{
			if (mThis == null) mThis = new SaveData();
			return mThis;
		}

		private SaveData() { }

		public bool Open(string filename, bool force)
		{
			if (System.IO.File.Exists(filename) == false) return false;

			Byte[] tmp = System.IO.File.ReadAllBytes(filename);

			using(var ms = new MemoryStream())
			{
				using(var gzip = new GZipStream(new MemoryStream(tmp), CompressionMode.Decompress))
				{
					gzip.CopyTo(ms);
					Byte[] buffer = ms.GetBuffer();
					String json = System.Text.Encoding.UTF8.GetString(buffer);
					Root = JObject.Parse(json);
				}
			}
			
			mFilename = filename;
			return true;
		}

		public void Save()
		{
			if (String.IsNullOrEmpty(mFilename)) return;

			Byte[] tmp = System.Text.Encoding.UTF8.GetBytes(Root.ToString());
			using (var ms = new MemoryStream(tmp))
			{
				using(var fs = System.IO.File.Open(mFilename, FileMode.OpenOrCreate))
				{
					using (var gzip = new GZipStream(fs, CompressionMode.Compress))
					{
						ms.CopyTo(gzip);
					}
				}
			}
		}
	}
}
