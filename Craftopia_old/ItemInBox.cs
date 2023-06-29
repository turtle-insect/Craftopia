using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;

namespace Craftopia
{
	class ItemInBox
	{
		public ObservableCollection<Item> Item { get; set; } = new ObservableCollection<Item>();

		public ItemInBox(JObject json)
		{
			foreach(var item in (JArray)json["itemInBox"])
			{
				Item.Add(new Item((JObject)item));
			}
		}
	}
}
