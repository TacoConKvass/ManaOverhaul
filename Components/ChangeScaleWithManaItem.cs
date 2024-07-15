using Terraria;

namespace ManaOverhaul.Components;

public class ChangeScaleWithManaItem : ItemComponent {
	/// <summary>
	/// Data for changing scale on mana thresholds
	/// </summary>
	public record struct ComponentData {
		public ComponentData() { }
		
		/// <summary>
		/// Thresholds for changing item scale
		/// </summary>
		public float[] Thresholds { get; set; } = [0f];
		/// <summary>
		/// Items scale boosts activated at thresholds at thier index
		/// </summary>
		/// <remarks>
		/// The boosts are additive with eachother
		/// </remarks>
		public float[] ScaleBoosts { get; set; } = [0f];
	}
	
	/// <inheritdoc cref="ComponentData"/>
	public ComponentData Data = new();
	
	public override void ModifyItemScale(Item item, Player player, ref float scale) {
		if (!Enabled) {
			return;
		}

		for (int index = 0; index < Data.Thresholds.Length; index++) {
			if (player.statMana < player.statManaMax2 * Data.Thresholds[index]) {
				scale += Data.ScaleBoosts[index];
			}
		}
	}
}