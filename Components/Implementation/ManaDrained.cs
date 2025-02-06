using ManaOverhaul.Common;
using System;
using System.Collections.Generic;
using Terraria;

namespace ManaOverhaul.Components;

public class ManaDrained_NPC : NPCComponent {
	public Dictionary<int, ManaDrainData> ManaDrainPerPlayer = [];
	public Dictionary<int, int> Timers = [];
	public float Resistance = 0f;

	public override void SetDefaults(NPC entity) {
		if (ComponentLibrary.NPC.Resistance.TryGetValue(entity.type, out var resistances))
			if (resistances.TryGetValue("ManaDrain", out var value)) Resistance = value;

		Enabled = Resistance < 1f;
		if (!Enabled) return;
	}

	public override bool PreAI(NPC npc) {
		if (!Enabled) return true;

		List<int> toRemove = [];
		foreach (int playerId in ManaDrainPerPlayer.Keys) {
			ManaDrainData data = ManaDrainPerPlayer[playerId];
			Player player = Main.player[playerId];

			if (!player.active || player.dead || data.Ticks == 0) {
				toRemove.Add(playerId);
				continue;
			}
			if (Timers[playerId] > data.Interval) {
				Timers[playerId] = 0;
				data.Ticks--;
				player.statMana = Math.Min(player.statMana + (data.ManaPerInterval /*- (int)(data.ManaPerInterval * Resistance)*/), player.statManaMax2);
			}

			Timers[playerId]++;
		}

		foreach (int playerId in toRemove) { 
			ManaDrainPerPlayer.Remove(playerId);
		}

		return true;
	}
}