﻿using System;
using Sandbox;
using SWB_Base;

/*
 * This serves as a code example, css models are not included! 
*/

namespace SWB_CSS;

[Library("swb_css_m249_he", Title = "HE Grenade")]
public class M249HE : WeaponBaseEntity
{
    public override int Bucket => 4;
    public override HoldType HoldType => HoldType.Rifle;
    public override string ViewModelPath => "weapons/swb/css/m249/css_v_mach_m249para.vmdl";
    public override string WorldModelPath => "weapons/swb/css/m249/css_w_mach_m249para.vmdl";
    public override string Icon => "code/swb_css/textures/ui/css_icon_m249he.png";

    public override Func<ClipInfo, bool, FiredEntity> CreateEntity => CreateGrenadeEntity;
    public override string EntityModel => "weapons/swb/css/grenade_he/css_w_grenade_he_thrown.vmdl";
    public override Vector3 EntityVelocity => new Vector3(0, 0, 100);
    public override Vector3 EntitySpawnOffset => new Vector3(0, 15, 10);
    public override float PrimaryEntitySpeed => 17;

    public M249HE()
    {
        UISettings = new UISettings
        {
            PlayHitmarkerSound = false
        };

        General = new WeaponInfo
        {
            FOV = 75,
            WalkAnimationSpeedMod = 0.7f,

            ReloadTime = 5.7f
        };

        Primary = new ClipInfo
        {
            Ammo = 100,
            AmmoType = AmmoTypes.Grenade,
            ClipSize = 100,

            BulletSize = 5f,
            BulletType = new HitScanBullet(),
            Damage = 15f,
            Force = 4f,
            Spread = 0.2f,
            Recoil = 0.7f,
            RPM = 800,
            FiringType = FiringType.auto,
            ScreenShake = new ScreenShake
            {
                Length = 0.08f,
                Delay = 0.02f,
                Size = 0.5f,
                Rotation = 0.1f
            },

            DryFireSound = "swb_lmg.empty",
            ShootSound = "css_m249.fire",

            BulletEjectParticle = new("particles/pistol_ejectbrass.vpcf"),
            MuzzleFlashParticle = new("particles/swb/muzzle/flash.vpcf"),
            BulletTracerParticle = null,

            InfiniteAmmo = InfiniteAmmoType.reserve
        };

        ZoomAnimData = new AngPos
        {
            Angle = new Angles(1f, 0f, 0),
            Pos = new Vector3(-4.425f, 2, 2.45f)
        };

        RunAnimData = new AngPos
        {
            Angle = new Angles(10, 30, 0),
            Pos = new Vector3(4, 0, 0)
        };
    }

    private FiredEntity CreateGrenadeEntity(ClipInfo clipInfo, bool isPrimary)
    {
        var grenade = new Grenade();
        grenade.Weapon = this;
        grenade.ExplosionDelay = 3f;
        grenade.ExplosionRadius = 300f;
        grenade.ExplosionDamage = 200f;
        grenade.ExplosionForce = 350f;
        grenade.BounceSound = "css_grenade_he.bounce";
        grenade.ExplosionSound = "css_grenade_he.explode";
        grenade.ExplosionEffect = "weapons/swb/css/grenade_he/particles/grenade_he_explosion.vpcf";
        grenade.ExplosionShake = new ScreenShake
        {
            Length = 1f,
            Delay = 5f,
            Size = 5f,
            Rotation = 2f,
        };

        return grenade;
    }
}
