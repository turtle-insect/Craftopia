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

		public int DurabilityValue
		{
			get { return (int)mThis["item"]["durabilityValue"]; }
			set { mThis["item"]["durabilityValue"] = value; }
		}

		public int DurabilityMax
		{
			get { return (int)mThis["item"]["durabilityMax"]; }
			set { mThis["item"]["durabilityMax"] = value; }
		}
	}
}
