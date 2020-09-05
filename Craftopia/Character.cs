using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Craftopia
{
	class Character
	{
		private readonly JObject mMake;
		private readonly JObject mStatus;

		public Character(JObject json)
		{
			mMake = (JObject)json["charaMakeData"];
			mStatus = (JObject)json["plStatusSaveData"];
		}

		public String Name
		{
			get { return (String)mMake["name"]; }
			set { mMake["name"] = value; }
		}

		public int Money
		{
			get { return (int)mStatus["Money"]; }
			set { mStatus["Money"] = value; }
		}

		public int SkillPoint
		{
			get { return (int)mStatus["SkillPoint"]; }
			set { mStatus["SkillPoint"] = value; }
		}

		public int Level
		{
			get { return (int)mStatus["Level"]; }
			set { mStatus["Level"] = value; }
		}

		public int Exp
		{
			get { return (int)mStatus["Exp"]; }
			set { mStatus["Exp"] = value; }
		}
	}
}
