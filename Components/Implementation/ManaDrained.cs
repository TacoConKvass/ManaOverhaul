using ManaOverhaul.Common;
using System;
using Terraria;

namespace ManaOverhaul.Components;

public class ManaDrained_NPC : NPCComponent {
	public ManaDrainData[] ManaDrainPerPlayer = null;
	public int[] Timers = new int[Main.maxPlayers];
	public float Resistance = 0f;

	public override void SetDefaults(NPC entity) {
		if (ComponentLibrary.NPC.Resistance.TryGetValue(entity.type, out var resistances))
			if (resistances.TryGetValue("ManaDrain", out var value)) Resistance = value;

		Enabled = Resistance < 1f;
		if (!Enabled) return;

		ManaDrainPerPlayer = new ManaDrainData[Main.maxPlayers];
		Array.Fill(ManaDrainPerPlayer, new ManaDrainData() { Interval = 0, ManaPerInterval = 0, Ticks = 0 });
	}

	public override bool PreAI(NPC npc) {
		if (!Enabled) return true;

		foreach (Player player in Main.ActivePlayers) {
			int ID = player.whoAmI;
			ManaDrainData data = ManaDrainPerPlayer[ID];

			if (data.Ticks == 0) continue;
			if (Timers[ID] > data.Interval) {
				Timers[ID] = 0;
				data.Ticks--;
				player.statMana = Math.Min(player.statMana + (data.ManaPerInterval /*- (int)(data.ManaPerInterval * Resistance)*/), player.statManaMax2);
			}

			Timers[ID]++;
		}
		return true;
	}
}