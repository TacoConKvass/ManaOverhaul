using ManaOverhaul.DataStructures;
using Terraria;

namespace ManaOverhaul.Components;

public class OnHitManaGeneratorItem : ItemComponent {
	/// <summary>
	/// Data for on hit mana regeneration
	/// </summary>
	public record struct OnHitManaGenerationData {
		public OnHitManaGenerationData() { }
		
		/// <summary>
		/// Determines the variation range of amount of mana regenerated
		/// </summary>
		public Range Variation { get; set; } = new();
		/// <summary>
		/// Base amount of mana regenerated
		/// </summary>
		public int BaseManaGeneration { get; set; } = 0;
		/// <summary>
		/// The amount of mana the hot will actually generate
		/// </summary>
		public int ManaGeneration => (int)(BaseManaGeneration * (Variation.Upper == Variation.Lower ? 1f : Variation.Random));
	}
	 
	/// <inheritdoc cref="OnHitManaGenerationData"/>
	public OnHitManaGenerationData Data = new();
	 
	public override void OnHitNPC(Item item, Player player, NPC target, NPC.HitInfo hit, int damageDone) {
		if (!Enabled) {
	 		return;
	 	}
	 	
	 	player.healMana(Data.ManaGeneration);
	}
}