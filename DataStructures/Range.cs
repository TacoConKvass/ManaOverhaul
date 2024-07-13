namespace ManaOverhaul.DataStructures;

public record struct Range {
	/// <summary> 
	/// Bottom limit of the range, inclusive
	/// </summary> 
	public float Lower { get; set; } = 1f;
	/// <summary>
	/// Upper limit of the range, exclusive
	/// </summary> 
	public float Upper { get; set; } = 1f;
	/// <summary>
	/// Returns a random value from within the bounds
	/// </summary>
	public float Random => Main.rand.NextFloat(Lower, Upper);
}