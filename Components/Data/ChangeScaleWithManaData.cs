namespace ManaOverhaul.Components;

/// <summary>
/// Data for changing scale on mana thresholds
/// </summary
public class ChangeScaleWithManaData() {
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

	public static ChangeScaleWithManaData Default = new ChangeScaleWithManaData() { 
		Thresholds = [.5f], 
		ScaleBoosts = [.3f]
	};
}