using ManaOverhaul.Components;
using System.Collections.Generic;

namespace ManaOverhaul.Common;

public static class ComponentLibrary {
	public static class Item {
		public static Dictionary<int, ChangeScaleWithManaData> ChangeScaleWithMana = [];
	}

	public static class Projectile {
		public static Dictionary<int, ChangeScaleWithManaData> ChangeScaleWithMana = [];
	}

	public static void Unload() {
		Item.ChangeScaleWithMana = null;
		Projectile.ChangeScaleWithMana = null;
	}
}