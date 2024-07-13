using ManaOverhaul.DataStructures;
using Terraria;

namespace ManaOverhaul.Components;

public class OnHitManaGeneratorItem : ItemComponent {
	public record struct OnHitManaGenerationData {
		public OnHitManaGenerationData() { }
		
		public Range Variation { get; set; } = new();
		public int BaseManaGeneration { get; set } = 0;
		public int ManaGeneration => BaseManaGeneration * (Variation.Upper == Variation.Lower ? 1f : Variation.Random);
	}
	 
	public OnHitManaGenerationData Data = new();
	 
	public override void OnHitNPC(Item item, Player player, NPC target, NPC.HitInfo hit, int damageDone) {
		if (!Enabled) {
	 		return;
	 	}
	 	
	 	player.healMana(Data.ManaGeneration);
	}
}