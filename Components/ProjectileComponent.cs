using Terraria.ModLoader;

namespace ManaOverhaul.Components;

public class ProjectileComponent : GlobalProjectile {
	public override bool InstancePerEntity { get; } = true;
	
	/// <summary>
	/// Determines whether this component is enabled
	/// </summary>
	public bool Enabled { get; set; } = false;
}