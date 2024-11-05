using Newtonsoft.Json.Linq;
using ManaOverhaul.DataStructures;
using ManaOverhaul.Components;
using System.IO;
using System.Linq;
using Terraria.ID;
using Terraria.ModLoader;

namespace ManaOverhaul.Utils;

public class ComponentDataLoader : ModSystem {
	public override void Load() {
		LoadPrefabsFromMod(Mod);
	}

	public static void LoadPrefabsFromMod(Mod mod) {
		var assets = mod.GetFileNames();

		foreach (string fullFilePath in assets.Where(t => t.EndsWith(".mana-overhaul"))) {
			using Stream stream = mod.GetFileStream(fullFilePath);
			using StreamReader streamReader = new StreamReader(stream);

			string hjsonText = streamReader.ReadToEnd();
			string jsonText = Hjson.HjsonValue.Parse(hjsonText).ToString(Hjson.Stringify.Plain);
			JToken json = JToken.Parse(jsonText);

			foreach (JToken rootToken in json) {
				if (rootToken is not JProperty { Name: string entityName, Value: JObject entityJson }) {
					continue;
				}

				if (entityJson["ChangeScaleWithManaItem"] is JObject ChangeScaleWithManaItemJson) {
					ComponentDataLibrary.ChangeScaleWithManaItem.Add(
						ItemID.Search.GetId(entityName),
						ChangeScaleWithManaItemJson.ToObject<ChangeScaleWithManaItem.ComponentData>()
					);
				}

				if (entityJson["OnHitManaGeneratorItem"] is JObject OnHitManaGeneratorItemJson) {
					ComponentDataLibrary.OnHitManaGeneratorItem.Add(
						ItemID.Search.GetId(entityName),
						OnHitManaGeneratorItemJson.ToObject<OnHitManaGeneratorItem.ComponentData>()
					);
				}

				if (entityJson["OnHitManaGeneratorProjectile"] is JObject OnHitManaGeneratorProjectileJson) {
					ComponentDataLibrary.OnHitManaGeneratorProjectile.Add(
						ProjectileID.Search.GetId(entityName),
						OnHitManaGeneratorProjectileJson.ToObject<OnHitManaGeneratorProjectile.ComponentData>()
					);
				}
			}
		}
	}
}