using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Craftopia
{
	internal class PlayerSaveJson
	{
		[JsonPropertyName("plStatusSaveData")]
		public PlayerSaveplStatusSaveDataJson Status { get; set; }

		[JsonExtensionData]
		public IDictionary<String, JsonElement>? ExtensionData { get; set; }
	}

	internal class PlayerSaveplStatusSaveDataJson
	{
		public uint Level { get; set; }

		public uint Exp { get; set; }

		public Double Health { get; set; }

		public Double Mana { get; set; }

		public uint SkillPoint { get; set; }

		public uint Money { get; set; }

		[JsonExtensionData]
		public IDictionary<String, JsonElement>? ExtensionData { get; set; }
	}
}
