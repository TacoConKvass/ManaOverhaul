using ManaOverhaul.Common;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraria;

namespace ManaOverhaul.Components;

public class ManaDrainData() {
	/// <summary>
	/// How many times mana is regenerated
	/// </summary>
	public int Ticks { get; set; }
	
	/// <summary>
	/// How often mana drain ticks are procced
	/// </summary>
	public int Interval { get; set; }

	/// <summary>
	/// How much mana per interval is regained
	/// </summary>
	public int ManaPerInterval { get; set; }

	public static void DeserializeFor<T>(int ID, JObject data) {
		Dictionary<int, ManaDrainData> dictionary = [];

		if (typeof(T) == typeof(Item)) dictionary = ComponentLibrary.Item.AppliesManaDrain;
		if (typeof(T) == typeof(Projectile)) dictionary = ComponentLibrary.Projectile.AppliesManaDrain;
		if (typeof(T) == typeof(NPC)) dictionary = ComponentLibrary.NPC.AppliesManaDrain;

		ManaDrainData value = data.ToObject<ManaDrainData>();

		if (dictionary.TryAdd(ID, value)) return;
		else dictionary[ID] = value;
	}
}