using Newtonsoft.Json.Linq;
using ManaOverhaul.DataStructures;
using ManaOverhaul.Components;
using System.IO;
using System.Linq;
using Terraria.ModLoader;

namespace ManaOverhaul.Utils;

public class ComponentDataLoader : ModSystem {
	public override void Load() {
		LoadAmbienceTracksFromMod(Mod);
	}

	public static void LoadAmbienceTracksFromMod(Mod mod) {
		var assets = mod.GetFileNames();
		mod.Logger.Warn(assets.Count);

		foreach (string fullFilePath in assets.Where(t => t.EndsWith(".prefab"))) {
			using Stream stream = mod.GetFileStream(fullFilePath);
			using StreamReader streamReader = new StreamReader(stream);

			string hjsonText = streamReader.ReadToEnd();
			string jsonText = Hjson.HjsonValue.Parse(hjsonText).ToString(Hjson.Stringify.Plain);
			JToken json = JToken.Parse(jsonText);

			foreach (JToken rootToken in json) {
				if (rootToken is not JProperty { Name: string entityName, Value: JObject entityJson }) {
					mod.Logger.Warn(rootToken.Path.Split(".").Last());
					continue;
				}

				if (entityJson["ChangeScaleWithManaItem"] is JObject ChangeScaleWithManaItemJson) {
					ComponentDataLibrary.ChangeScaleWithManaItem.Add(
						int.Parse(entityName), 
						ChangeScaleWithManaItemJson.ToObject<ChangeScaleWithManaItem.ComponentData>()
					);
				}

				if (entityJson["OnHitManaGeneratorItem"] is JObject OnHitManaGeneratorItemJson) {
					ComponentDataLibrary.OnHitManaGeneratorItem.Add(
						int.Parse(entityName),
						OnHitManaGeneratorItemJson.ToObject<OnHitManaGeneratorItem.ComponentData>()
					);
				}

				if (entityJson["OnHitManaGeneratorProjectile"] is JObject OnHitManaGeneratorProjectileJson) {
					ComponentDataLibrary.OnHitManaGeneratorProjectile.Add(
						int.Parse(entityName),
						OnHitManaGeneratorProjectileJson.ToObject<OnHitManaGeneratorProjectile.ComponentData>()
					);
				}
			}
		}
	}
}