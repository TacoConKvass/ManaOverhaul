using Terraria;

namespace ManaOverhaul.Components;

public class ChangeScaleWithManaItem : ItemComponent {
	public record struct ChangeScaleWithManaData {
		public ChangeScaleWithManaData() { }
		
		public float[] Thresholds { get; set; } = [0f];
		public float[] ScaleBoosts { get; set; } = [0f];
	}
	
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