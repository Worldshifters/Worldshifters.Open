// <copyright file="Zooey.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Light
{
    using System;
    using System.Linq;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class Zooey
    {
        public static Guid Id = Guid.Parse("6551bdb5-0671-4152-ab2e-3fe80651533d");

        private const string HostilityUpId = "zooey/hostility_up";
        private const string SpacialRuptureId = "zooey/spacial_rupture";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Zooey",
                Races = { Race.Primal },
                Gender = Gender.Female,
                MaxAttack = 7200,
                MaxHp = 1350,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Light,
                Description =
                    "The fragments of consciousness all hoping to protect this world enveloped in stars and skies gathered together to give birth to this young girl as the arbitrator of the skies. With a legion of dragons by her side, she brandishes an azure sword ready to destroy any foe who dares to disturb the balance of the world.",
                WeaponProficiencies = { EquipmentType.Sword },
                AvailablePerkIds =
                {
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.DebuffResistanceBoost,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.LightAttackBoost,
                    ExtendedMasteryPerks.ChargeAttackDamageBoost,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.HostilityBoost,
                    ExtendedMasteryPerks.DebuffSuccessRateBoost,
                    ExtendedMasteryPerks.SupportSkill,
                },
                PassiveAbilities =
                {
                    new PassiveAbility
                    {
                        Type = PassiveAbility.Types.PassiveAbilityType.SupportSkill,
                        Name = "Envoy of Mediation",
                        Description = "Increases stats for each element among allies in the front line.",
                    },
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/6551bdb5-0671-4152-ab2e-3fe80651533d/model/0/npc_3040078000_02.js",
                        ConstructorName = "mc_npc_3040078000_02",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040078000_02_a",
                                Path = "npc/6551bdb5-0671-4152-ab2e-3fe80651533d/model/0/npc_3040078000_02_a.png",
                            },
                            new ImageAsset
                            {
                                Name = "npc_3040078000_02_b",
                                Path = "npc/6551bdb5-0671-4152-ab2e-3fe80651533d/model/0/npc_3040078000_02_b.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/6551bdb5-0671-4152-ab2e-3fe80651533d/model/0/phit_3040078000.js",
                        ConstructorName = "mc_phit_3040078000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040078000",
                                Path = "npc/6551bdb5-0671-4152-ab2e-3fe80651533d/model/0/phit_3040078000.png",
                            },
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = string.Empty,
                    HitCount = { 6 },

                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "npc/6551bdb5-0671-4152-ab2e-3fe80651533d/model/0/nsp_3040078000_02.js",
                            ConstructorName = "mc_nsp_3040078000_02_special",
                        },
                    },
                    ProcessEffects = (zooey, _) => { zooey.RemoveStatusEffect(HostilityUpId); },
                },
                Abilities =
                {
                    SpinningSlash(damageModifier: 4.5),
                    PrismHalo(cooldown: 8),
                    Thunder(cooldown: 5),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = SpinningSlash(damageModifier: 5),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = PrismHalo(cooldown: 6),
                        UpgradedAbilityIndex = 1,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 80,
                        Ability = Bisection(),
                        UpgradedAbilityIndex = 3,
                    },
                },
                OnActionStart = (zooey, _, raidActions) => ProcessPassiveEffects(zooey),
                OnEnteringFrontline = (zooey, raidActions) => ProcessPassiveEffects(zooey),
                HeroArchetype = "zooey",
            };
        }

        public static void RegisterSpacialRuptureFieldEffect()
        {
            FieldEffectLibrary.AddNewFieldEffect(SpacialRuptureId, () => new FieldEffect
            {
                Id = SpacialRuptureId,
                DurationInSeconds = 180,
                ProcessEffects = (raid, raidActions) =>
                {
                    foreach (var entity in raid.Allies.Concat(raid.Enemies))
                    {
                        entity.ApplyStatusEffectsFromTemplate(
                            new StatusEffectSnapshot
                            {
                                IsUsedInternally = true,
                                IsPassiveEffect = true,
                            },
                            ($"{SpacialRuptureId}/da_up", ModifierLibrary.FlatDoubleAttackRateBoost, 20),
                            ($"{SpacialRuptureId}/ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 10));
                    }
                },
            });
        }

        private static Ability SpinningSlash(double damageModifier)
        {
            return new Ability
            {
                Name = "Spinning Slash",
                Cooldown = 3,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/6551bdb5-0671-4152-ab2e-3fe80651533d/abilities/0/ab_3040078000_01.js",
                    ConstructorName = "mc_ab_3040078000_01_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040078000_01",
                            Path = "npc/6551bdb5-0671-4152-ab2e-3fe80651533d/abilities/0/ab_3040078000_01.png",
                        },
                    },
                },
                Effects =
                {
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.MultihitDamage,
                        ExtraData = new MultihitDamage
                        {
                            Element = Element.Light,
                            HitNumber = 1,
                            DamageCap = 630_000,
                            DamageModifier = damageModifier,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = HostilityUpId,
                            IsStackable = true,
                            Strength = 10,
                            StackingCap = 50,
                            TurnDuration = 7,
                            EffectTargettingType = EffectTargettingType.OnSelf,
                            BaseAccuracy = double.PositiveInfinity,
                        }.ToByteString(),
                    },
                },
                CanCast = (zooey, targetPositionInFrontline) =>
                {
                    if (zooey.ChargeGauge < 20)
                    {
                        return (false, "Not enough charge bar");
                    }

                    return (true, string.Empty);
                },
                ProcessEffects = (zooey, targetPositionInFrontline, raidActions) =>
                {
                    zooey.ChargeGauge -= 20;
                    if (!zooey.GlobalState.ContainsKey("spinning_slash_stun"))
                    {
                        zooey.GlobalState.Add("spinning_slash_stun", TypedValue.FromLong(0));
                    }

                    zooey.GlobalState["spinning_slash_stun"].IntegerValue += 10;
                    if (zooey.GlobalState["spinning_slash_stun"].IntegerValue >= 100)
                    {
                        zooey.Raid.Enemies.AtPosition(targetPositionInFrontline).ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.Stun,
                                RemainingDurationInSeconds = 30,
                                BaseAccuracy = 100,
                            }, raidActions);
                        zooey.GlobalState["spinning_slash_stun"].IntegerValue = 0;
                    }
                },
                AnimationName = "ab_motion",
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
            };
        }

        private static Ability PrismHalo(uint cooldown)
        {
            return new Ability
            {
                Name = "Prism Halo",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Defensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/6551bdb5-0671-4152-ab2e-3fe80651533d/abilities/3/ab_3040078000_04.js",
                    ConstructorName = "mc_ab_3040078000_04_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040078000_04",
                            Path = "npc/6551bdb5-0671-4152-ab2e-3fe80651533d/abilities/3/ab_3040078000_04.png",
                        },
                    },
                },
                Effects =
                {
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = StatusEffectLibrary.MirrorImage,
                            Strength = 2,
                            TurnDuration = int.MaxValue,
                            EffectTargettingType = EffectTargettingType.OnSelf,
                        }.ToByteString(),
                    },
                },
                AnimationName = "ab_motion",
                ShouldRepositionSpriteAnimation = true,
            };
        }

        private static Ability Thunder(uint cooldown)
        {
            return new Ability
            {
                Name = "Thunder",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/6551bdb5-0671-4152-ab2e-3fe80651533d/abilities/2/ab_all_3040078000_03.js",
                    ConstructorName = "mc_ab_all_3040078000_03",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040078000_03",
                            Path = "npc/6551bdb5-0671-4152-ab2e-3fe80651533d/abilities/2/ab_all_3040078000_03.png",
                        },
                    },
                },
                Effects =
                {
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.MultihitDamage,
                        ExtraData = new MultihitDamage
                        {
                            Element = Element.Light,
                            HitNumber = 1,
                            HitAllTargets = true,
                            DamageModifier = 3.5,
                            DamageCap = 470000,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (zooey, target, raidActions) =>
                {
                    var random = ThreadSafeRandom.NextDouble();
                    foreach (var enemy in zooey.Raid.Enemies)
                    {
                        if (enemy.IsAlive() && enemy.PositionInFrontline < 4)
                        {
                            enemy.ApplyStatusEffect(
                                new StatusEffectSnapshot
                                {
                                    Id = random <= 1.0 / 3
                                        ? StatusEffectLibrary.StackableDefenseDownNpc
                                        : (random <= 2.0 / 3
                                            ? StatusEffectLibrary.StackableAttackDownNpc
                                            : StatusEffectLibrary.StackableDebuffResistanceDownNpc),
                                    Strength = -10,
                                    IsStackable = true,
                                    StackingCap = random <= 1.0 / 3 ? -25 : -30,
                                    BaseAccuracy = 100,
                                    RemainingDurationInSeconds = 180,
                                },
                                raidActions);
                        }
                    }
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Bisection()
        {
            return new Ability
            {
                Name = "Bisection",
                Cooldown = 15,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/6551bdb5-0671-4152-ab2e-3fe80651533d/abilities/1/ab_all_3040078000_02.js",
                    ConstructorName = "mc_ab_all_3040078000_02",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040078000_02",
                            Path = "npc/6551bdb5-0671-4152-ab2e-3fe80651533d/abilities/1/ab_all_3040078000_02.png",
                        },
                    },
                },
                ProcessEffects = (zooey, _, raidActions) => { zooey.Raid.AddFieldEffect(SpacialRuptureId); },
                AnimationName = "ab_motion",
            };
        }

        private static void ProcessPassiveEffects(EntitySnapshot zooey)
        {
            if (!zooey.IsAlive() || zooey.PositionInFrontline >= 4)
            {
                return;
            }

            var distinctElements = zooey.Raid.Allies.Where(e => e.IsAlive() && e.PositionInFrontline < 4)
                .Select(e => e.Element)
                .Distinct()
                .Count();

            zooey.ApplyStatusEffectsFromTemplate(
                new StatusEffectSnapshot
                {
                    IsPassiveEffect = true,
                    IsUsedInternally = true,
                },
                ("zooey/atk_up", ModifierLibrary.AttackBoost, 15 * distinctElements),
                ("zooey/atk_up", ModifierLibrary.AttackBoost, 15 * distinctElements),
                ("zooey/def_up", ModifierLibrary.AttackBoost, 7.5 * distinctElements),
                ("zooey/da_up", ModifierLibrary.AttackBoost, 10 * distinctElements),
                ("zooey/ta_up", ModifierLibrary.AttackBoost, 3 * distinctElements));

            if (zooey.Raid.GetActiveFieldEffectIds().Contains(SpacialRuptureId))
            {
                var rank = zooey.Hero.GetSupportSkillRank();
                if (rank > 0)
                {
                    zooey.ApplyStatusEffect(new StatusEffectSnapshot
                    {
                        Id = "zooey/echo",
                        Strength = (int)((rank + 1) * 2.5),
                        Modifier = ModifierLibrary.AdditionalDamage,
                        IsUsedInternally = true,
                        IsPassiveEffect = true,
                    });
                }
            }
        }
    }
}