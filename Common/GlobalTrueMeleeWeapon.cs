using ManaOverhaul.Components;
using Terraria.ModLoader;

namespace ManaOverhaul.Common;

public class GlobalTrueMeleeWeapon : GlobalItem {
	public override bool AppliesToEntity(TEntity entity, bool lateInstantiation) 
		=> lateInstantiation && entity.CountsAsClass(DamageType.Melee) && !entity.noMelee;
}