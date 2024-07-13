using ManaOverhaul.DataStructures;
using Terraria;

namespace ManaOverhaul.Components

public class ManaGeneratorProjectile : ProjectileComponent {
	 public struct ManaGenerationData {
	 	public Range Variation { get; set; } = new();
	 	public int BaseManaGeneration { get; set }
	 	public int ManaGeneration => BaseManaGeneration * (Variation.Upper == Variation.Lower ? 1f : Variation.Random);
	 }
	 
	 public ManaGenerationData Data = new();
	 
	 public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone) {
	 	if (!Enabled) {
	 		return;
	 	}
	 	
	 	Main.player[projectile.owner].healMana(Data.ManaGeneration);
	 }
}