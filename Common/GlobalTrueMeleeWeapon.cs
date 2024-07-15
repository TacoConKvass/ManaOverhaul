using ManaOverhaul.Components;
using ManaOverhaul.DataStructures;
using Terraria;
using Terraria.ModLoader;

namespace ManaOverhaul.Common;

public class GlobalTrueMeleeWeapon : GlobalItem {
	public override bool AppliesToEntity(Item entity, bool lateInstantiation) 
		=> lateInstantiation && entity.CountsAsClass(DamageClass.Melee) && !entity.noMelee && (entity.ModItem == null || entity.ModItem?.Mod != Mod);

	public override void SetDefaults(Item entity) {
		ChangeScaleWithManaItem changeScaleGlobal = entity.GetGlobalItem<ChangeScaleWithManaItem>();
		changeScaleGlobal.Enabled = true;
		changeScaleGlobal.Data = ComponentDataLibrary.ChangeScaleWithManaItem.TryGetValue(entity.type, out ChangeScaleWithManaItem.ComponentData value) ? value : new ChangeScaleWithManaItem.ComponentData() {
			Thresholds = [.5f],
			ScaleBoosts = [.3f]
		};
	}
}