using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GuideHaveGun.NPCs;

public sealed class GuideCombatGlobalNPC : GlobalNPC
{
	private const int GuideLifeMax = 1000;
	private const int GuideDangerDetectRange = 1200;
	private const int GuideAttackStartRange = 1200;
	private const float GuideStandGroundRange = 240f;
	private const int GuideShotDamage = 28;
	private const float GuideShotKnockback = 4f;
	private const int GuideCooldownBase = 1;
	private const int GuideCooldownRandom = 1;
	private const int GuideProjectileType = ProjectileID.Bullet;
	private const int GuideProjectileDelay = 1;
	private const float GuideProjectileSpeed = 16f;
	private const float GuideProjectileSpread = 1.5f;
	private const int GuideWeaponType = ItemID.TacticalShotgun;

	public override void SetStaticDefaults()
	{
		NPCID.Sets.DangerDetectRange[NPCID.Guide] = GuideDangerDetectRange;
		NPCID.Sets.PrettySafe[NPCID.Guide] = GuideAttackStartRange;
	}

	public override void AI(NPC npc)
	{
		if (npc.type != NPCID.Guide) {
			return;
		}

		NPC target = FindNearestHostile(npc, GuideAttackStartRange);

		if (target is null) {
			return;
		}

		float horizontalDistance = target.Center.X - npc.Center.X;

		if (Math.Abs(horizontalDistance) > GuideStandGroundRange) {
			return;
		}

		npc.velocity.X = 0f;
	}

	public override void SetDefaults(NPC npc)
	{
		if (npc.type != NPCID.Guide) {
			return;
		}

		npc.lifeMax = GuideLifeMax;
		npc.life = GuideLifeMax;
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

	private static NPC FindNearestHostile(NPC npc, float maxDistance)
	{
		NPC nearestTarget = null;
		float bestDistanceSquared = maxDistance * maxDistance;

		for (int index = 0; index < Main.maxNPCs; index++) {
			NPC possibleTarget = Main.npc[index];

			if (!possibleTarget.active || !possibleTarget.CanBeChasedBy(npc)) {
				continue;
			}

			float currentDistanceSquared = Vector2.DistanceSquared(npc.Center, possibleTarget.Center);

			if (currentDistanceSquared >= bestDistanceSquared) {
				continue;
			}

			bestDistanceSquared = currentDistanceSquared;
			nearestTarget = possibleTarget;
		}

		return nearestTarget;
	}
}
