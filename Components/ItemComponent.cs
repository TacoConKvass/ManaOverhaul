using Terraria.ModLoader;

namespace ManaOverhaul.Components;

public class ItemComponent : GlobalItem {
	public override bool InstancePerEntity { get; } = true;
	
	public bool Enabled { get; set; } = false;
}