using Terraria.ModLoader;

namespace ManaOverhaul.Components;

public class ProjectileComponent : GlobalProjectile {
	public override bool InstancePerEntity { get; } = true;
	
	public bool Enabled { get; set; } = false;
}