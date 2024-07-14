using Terraria;

namespace ManaOverhaul.Components;

public class ChangeScaleWithManaItem : ItemComponent {
	/// <summary
	/// Data for changing scale on mana thresholds
	/// </summary>
	public record struct ChangeScaleWithManaData {
		public ChangeScaleWithManaData() { }
		
		/// <summary
		/// Thresholds for changing item scale
		/// </summary>
		public float[] Thresholds { get; set; } = [0f];
		/// <summary
		/// Items scale boosts activated at thresholds at thier index
		/// </summary>
		/// <remarks>
		/// The boosts are additive with eachother
		/// </remarks>
		public float[] ScaleBoosts { get; set; } = [0f];
	}
	
	/// <inheritdoc cref="ChangeScaleWithManaData"/>
	ChangeScaleWithManaData Data = new();
	
	public override ModifyItemScale(Item item, Player player, ref float scale) {
		if (!Enabled) {
			return;
		}
		
		foreach (int index = 0; index < Data.Thresholds.Length) {
			if (player.mana < player.statMana * Data.Thresholds[index]) {
				scale += Data.ScaleBoosts[index];
			}
		}
	}
}