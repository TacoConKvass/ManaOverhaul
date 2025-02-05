	using Newtonsoft.Json.Linq;
using ManaOverhaul.Common;
using ManaOverhaul.Components;
using System.IO;
using System.Linq;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace ManaOverhaul.Utils;

public class PrefabLoader : ModSystem {
	public override void PostSetupContent() {
		LoadPrefabsFromMod(Mod);
	}

	public static void LoadPrefabsFromMod(Mod mod) {
		var assets = mod.GetFileNames().Where(t => t.EndsWith(".mana-overhaul"));
		mod.Logger.Debug("Started loading Mana Overhaul prefabs");
		mod.Logger.Debug("Prefab files found: " + assets.Count().ToString());

		foreach (string fullFilePath in assets) {
			using Stream stream = mod.GetFileStream(fullFilePath);
			using StreamReader streamReader = new StreamReader(stream);
			string hjsonText = streamReader.ReadToEnd();
			string jsonText = Hjson.HjsonValue.Parse(hjsonText).ToString(Hjson.Stringify.Plain);
			JToken json = JToken.Parse(jsonText);

			if (json["Items"] is JContainer items) {
				foreach (JToken itemToken in items) {
					if (itemToken is not JProperty { Name: string itemName, Value: JObject components}) {
						continue;
					}

					if (components["ChangeScaleWithMana"] is	JObject data) {
						int ID = ItemID.Search.GetId(itemName);
						ChangeScaleWithManaData value = data.ToObject<ChangeScaleWithManaData>();

						if (ComponentLibrary.Item.ChangeScaleWithMana.TryAdd(ID, value)) continue;
						else ComponentLibrary.Item.ChangeScaleWithMana[ID] = value;
					}
				}
			}
			
			if (json["Projectiles"] is JContainer projectiles) {
				foreach (JToken projectileToken in projectiles) {
					if (projectileToken is not JProperty { Name: string projectilesName, Value: JObject components }) {
						continue;
					}

					if (components["ChangeScaleWithMana"] is JObject data) {
						int ID = ProjectileID.Search.GetId(projectilesName);
						ChangeScaleWithManaData value = data.ToObject<ChangeScaleWithManaData>();

						if (ComponentLibrary.Projectile.ChangeScaleWithMana.TryAdd(ID, value)) continue;
						else ComponentLibrary.Projectile.ChangeScaleWithMana[ID] = value;
					}
				}
			}
		}
	}
}