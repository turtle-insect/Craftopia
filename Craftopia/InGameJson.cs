using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Craftopia
{
	internal class InGameJson
	{
		[JsonPropertyName("inventorySaveData")]
		public InGameinventorySaveDataJson Inventory { get; set; }

		[JsonExtensionData]
		public IDictionary<String, JsonElement>? ExtensionData { get; set; }
	}

	internal class InGameinventorySaveDataJson
	{
		[JsonPropertyName("equipmentList")]
		public List<InGameItemBoxListJson> Equipments { get; set; }

		[JsonPropertyName("buildingList")]
		public List<InGameItemBoxListJson> Buildings { get; set; }

		[JsonExtensionData]
		public IDictionary<String, JsonElement>? ExtensionData { get; set; }
	}

	internal class InGameItemBoxListJson
	{
		[JsonPropertyName("itemInBox")]
		public List<InGameItemBoxJson> ItemBoxs { get; set; }
		[JsonExtensionData]
		public IDictionary<String, JsonElement>? ExtensionData { get; set; }
	}

	internal class InGameItemBoxJson
	{
		[JsonPropertyName("item")]
		public InGameItemJson Item { get; set; }
		[JsonExtensionData]
		public IDictionary<String, JsonElement>? ExtensionData { get; set; }
	}

	internal class InGameItemJson
	{
		[JsonPropertyName("itemId")]
		public uint ID { get; set; }

		[JsonPropertyName("itemLevel")]
		public uint Level { get; set; }

		[JsonPropertyName("enchantIds")]
		public List<uint> Enchants { get; set; }

		[JsonExtensionData]
		public IDictionary<String, JsonElement>? ExtensionData { get; set; }
	}
}
