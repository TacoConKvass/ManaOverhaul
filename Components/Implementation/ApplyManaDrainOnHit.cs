using Humanizer;
using ManaOverhaul.Common;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ManaOverhaul.Components;

public class ApplyManaDrainOnHit_Item : ItemComponent {
	public ManaDrainData Data = default;
	
	public override void SetDefaults(Item entity) {
		if (ComponentLibrary.Item.AppliesManaDrain.TryGetValue(entity.type, out var value)) Data = value;

		Enabled = Data != null;
	}

	public override void OnHitNPC(Item item, Player player, NPC target, NPC.HitInfo hit, int damageDone) {
		if (!Enabled) return;
		Mod.Logger.Info(player.whoAmI);
		Mod.Logger.Info(Data.Interval);
		target.GetGlobalNPC<ManaDrained_NPC>().ManaDrainPerPlayer[player.whoAmI] = new ManaDrainData() { Interval = Data.Interval, ManaPerInterval = Data.ManaPerInterval, Ticks = Data.Ticks };
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
		if (!Enabled) return;

		int manaPerInterval = Data.ManaPerInterval;
		float seconds = MathF.Round(Data.Interval / 60f, 3);
		int ticks = Data.Ticks;

		tooltips.Add(new TooltipLine(
			Mod, "AppliesManaDrain",
			Language.GetTextValue("Mods.ManaOverhaul.AppliesManaDrain").FormatWith(manaPerInterval, $"{seconds} second{(seconds > 1 ? "s" : "")}", ticks)
		));
	}
}

public class ApplyManaDrainOnHit_Projectile : ProjectileComponent {
	public ManaDrainData Data = default;

	public override void SetDefaults(Projectile entity) {
		if (ComponentLibrary.Projectile.AppliesManaDrain.TryGetValue(entity.type, out var value)) Data = value;
		Enabled = Data != null;
	}

	public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone) {
		if (!Enabled) return;
		target.GetGlobalNPC<ManaDrained_NPC>().ManaDrainPerPlayer[projectile.owner] = new ManaDrainData() { Interval = Data.Interval, ManaPerInterval = Data.ManaPerInterval, Ticks = Data.Ticks };
	}
}