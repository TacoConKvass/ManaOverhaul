```TODO:

var assets = mod.GetFileNames();

foreach (string fullFilePath in assets.Where(t => t.EndsWith(".prefab.hjson"))) {
using var stream = mod.GetFileStream(fullFilePath);
using var streamReader = new StreamReader(stream);

string hjsonText = streamReader.ReadToEnd();
JsonObject jsonObject = JsonNode.Parse(hjsonText).AsObject();

Console.WriteLine(jsonObject.TryGetPropertyValue("test2", out JsonNode node));
Console.WriteLine(node.Deserialize<tets>());```