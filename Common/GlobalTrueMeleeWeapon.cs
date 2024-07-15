using ManaOverhaul.Components;
using Terraria;
using Terraria.ModLoader;

namespace ManaOverhaul.Common;

public class GlobalTrueMeleeWeapon : GlobalItem {
	public override bool AppliesToEntity(Item entity, bool lateInstantiation) 
		=> lateInstantiation && entity.CountsAsClass(DamageClass.Melee) && !entity.noMelee;
}