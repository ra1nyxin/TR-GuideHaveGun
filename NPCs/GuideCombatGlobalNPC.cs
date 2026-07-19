using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GuideHaveGun.NPCs;

public sealed class GuideCombatGlobalNPC : GlobalNPC
{
	private const int GuideDangerDetectRange = 600;
	private const int GuideShotDamage = 28;
	private const float GuideShotKnockback = 4f;
	private const int GuideCooldownBase = 4;
	private const int GuideCooldownRandom = 4;
	private const int GuideProjectileType = ProjectileID.Bullet;
	private const int GuideProjectileDelay = 1;
	private const float GuideProjectileSpeed = 16f;
	private const float GuideProjectileSpread = 1.5f;
	private const int GuideWeaponType = ItemID.TacticalShotgun;

	public override void SetStaticDefaults()
	{
		NPCID.Sets.DangerDetectRange[NPCID.Guide] = GuideDangerDetectRange;
	}

	public override void TownNPCAttackStrength(NPC npc, ref int damage, ref float knockback)
	{
		if (npc.type != NPCID.Guide) {
			return;
		}

		damage = GuideShotDamage;
		knockback = GuideShotKnockback;
	}

	public override void TownNPCAttackCooldown(NPC npc, ref int cooldown, ref int randExtraCooldown)
	{
		if (npc.type != NPCID.Guide) {
			return;
		}

		cooldown = GuideCooldownBase;
		randExtraCooldown = GuideCooldownRandom;
	}

	public override void TownNPCAttackProj(NPC npc, ref int projType, ref int attackDelay)
	{
		if (npc.type != NPCID.Guide) {
			return;
		}

		projType = GuideProjectileType;
		attackDelay = GuideProjectileDelay;
	}

	public override void TownNPCAttackProjSpeed(NPC npc, ref float multiplier, ref float gravityCorrection, ref float randomOffset)
	{
		if (npc.type != NPCID.Guide) {
			return;
		}

		multiplier = GuideProjectileSpeed;
		gravityCorrection = 0f;
		randomOffset = GuideProjectileSpread;
	}

	public override void DrawTownAttackGun(NPC npc, ref Texture2D item, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset)
	{
		if (npc.type != NPCID.Guide) {
			return;
		}

		Main.GetItemDrawFrame(GuideWeaponType, out item, out itemFrame);
		scale = 1f;
		horizontalHoldoutOffset = (int)Main.DrawPlayerItemPos(scale, GuideWeaponType).X - 6;
	}
}
