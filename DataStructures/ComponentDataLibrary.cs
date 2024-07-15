using ManaOverhaul.Components;
using System.Collections.Generic;

namespace ManaOverhaul.DataStructures;

public static class ComponentDataLibrary {
	public static Dictionary<int, ChangeScaleWithManaItem.ComponentData> ChangeScaleWithManaItem = [];
	public static Dictionary<int, OnHitManaGeneratorItem.ComponentData> OnHitManaGeneratorItem = [];
	public static Dictionary<int, OnHitManaGeneratorProjectile.ComponentData> OnHitManaGeneratorProjectile = [];

	public static void Unload() {
		ChangeScaleWithManaItem = null;
		OnHitManaGeneratorItem = null;
		OnHitManaGeneratorProjectile = null;
	}
}