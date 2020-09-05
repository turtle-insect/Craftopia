using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;

namespace Craftopia
{
	class ViewModel
	{
		public Character Character { get; set; }
		public ObservableCollection<ItemInBox> Equipment { get; set; } = new ObservableCollection<ItemInBox>();
		public ObservableCollection<ItemInBox> Building { get; set; } = new ObservableCollection<ItemInBox>();
		public ObservableCollection<ItemInBox> Consumption { get; set; } = new ObservableCollection<ItemInBox>();
		public ObservableCollection<ItemInBox> Material { get; set; } = new ObservableCollection<ItemInBox>();

		public ViewModel()
		{
			if (SaveData.Instance().Root == null) return;

			JObject character = (JObject)SaveData.Instance().Root["CharacterListSave"]["value"][0];
			Character = new Character(character);

			var dic = new Dictionary<String, ObservableCollection<ItemInBox>>
			{
				{"equipmentList",  Equipment},
				{ "buildingList", Building},
				{ "consumptionList", Consumption},
				{ "materialList", Material},
			};

			
			foreach (var key in dic.Keys)
			{
				JArray arr = (JArray)character["inventorySaveData"][key];
				foreach (var obj in arr)
				{
					dic[key].Add(new ItemInBox((JObject)obj));
				}
			}
		}
	}
}
