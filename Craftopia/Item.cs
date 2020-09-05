using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Craftopia
{
	class Item
	{
		private readonly JObject mThis;
		public Item(JObject json)
		{
			mThis = json;
		}

		public int ID
		{
			get { return (int)mThis["item"]["itemId"]; }
			set { mThis["item"]["itemId"] = value; }
		}

		public int Level
		{
			get { return (int)mThis["item"]["itemLevel"]; }
			set { mThis["item"]["itemLevel"] = value; }
		}

		public int Count
		{
			get { return (int)mThis["count"]; }
			set { mThis["count"] = value; }
		}
	}
}
