using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ManaOverhaul.Common;

internal class GlobalManaPickup : GlobalItem {
	public override bool AppliesToEntity(Item entity, bool lateInstantiation) {
		return lateInstantiation && ItemID.Sets.IsAPickup[entity.type] && entity.healMana != 0;
	}
}
