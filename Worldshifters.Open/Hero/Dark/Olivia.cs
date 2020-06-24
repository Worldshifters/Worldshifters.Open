// <copyright file="Olivia.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Dark
{
    using System;
    using System.Linq;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class Olivia
    {
        public static Guid Id = Guid.Parse("8fa966e2-0c05-4bc4-918d-9b5fd4a9686b");

        private const string TwilightTerrorId = "olivia/twilight_terror";
        private const string SoulBlades = "olivia/soul_blades";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Olivia",
                Races = { Race.Primal },
                Gender = Gender.Female,
                MaxAttack = 7800,
                MaxHp = 1480,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Dark,
                WeaponProficiencies = { EquipmentType.Sword },
                AvailablePerkIds =
                {
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.DebuffResistanceBoost,
                    ExtendedMasteryPerks.AttackBoostAgainstFoesInOverdriveMode,
                    ExtendedMasteryPerks.AttackBoostAgainstFoesInOverdriveMode,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.DarkAttackBoost,
                    ExtendedMasteryPerks.ChargeAttackDamageBoost,
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.TripleAttackRateBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.DebuffSuccessRateBoost,
                    ExtendedMasteryPerks.SupportSkill,
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/8fa966e2-0c05-4bc4-918d-9b5fd4a9686b/model/0/npc_3040145000_02.js",
                        ConstructorName = "mc_npc_3040145000_02",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040145000_02",
                                Path = "npc/8fa966e2-0c05-4bc4-918d-9b5fd4a9686b/model/0/npc_3040145000_02.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/8fa966e2-0c05-4bc4-918d-9b5fd4a9686b/model/0/phit_3040145000.js",
                        ConstructorName = "mc_phit_3040145000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040145000",
                                Path = "npc/8fa966e2-0c05-4bc4-918d-9b5fd4a9686b/model/0/phit_3040145000.png",
                            },
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = string.Empty,
                    HitCount = { 2 },
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "npc/8fa966e2-0c05-4bc4-918d-9b5fd4a9686b/model/0/nsp_3040145000_02_s2.js",
                            ConstructorName = "mc_nsp_3040145000_02_s2_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040145000_02_s2_a",
                                    Path = "npc/8fa966e2-0c05-4bc4-918d-9b5fd4a9686b/model/0/nsp_3040145000_02_s2_a.png",
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040145000_02_s2_b",
                                    Path = "npc/8fa966e2-0c05-4bc4-918d-9b5fd4a9686b/model/0/nsp_3040145000_02_s2_b.png",
                                },
                            },
                        },
                    },
                    ProcessEffects = (olivia, raidActions) =>
                    {
                        olivia.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.DarkAttackUpNpc,
                                Strength = 30,
                                TurnDuration = 4,
                            },
                            raidActions);

                        olivia.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = SoulBlades,
                                TurnDuration = int.MaxValue,
                            });

                        ProcessPassiveEffects(olivia);
                    },
                },
                Abilities =
                {
                    SterlingSea(cooldown: 9),
                    PeccatumMortale(cooldown: 9),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 45,
                        Ability = Nevermore(),
                        UpgradedAbilityIndex = 2,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = SterlingSea(cooldown: 8),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = PeccatumMortale(cooldown: 8),
                        UpgradedAbilityIndex = 1,
                    },
                },
                OnActionStart = (olivia, _, raidActions) => ProcessPassiveEffects(olivia),
                OnEnteringFrontline = (olivia, raidActions) => ProcessPassiveEffects(olivia),
                OnAbilityEnd = (olivia, ability, raidActions) =>
                {
                    if (olivia.IsAlive())
                    {
                        var supportSkillRank = olivia.Hero.GetSupportSkillRank();
                        if (supportSkillRank > 0)
                        {
                            var chargeGaugeGain = (int)Math.Ceiling((1 + olivia.Hero.GetSupportSkillRank()) * 2.5);
                            olivia.AddChargeGauge(chargeGaugeGain, raidActions);
                        }
                    }
                },
            };
        }

        private static Ability SterlingSea(uint cooldown)
        {
            return new Ability
            {
                Name = "Sterling Sea",
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/8fa966e2-0c05-4bc4-918d-9b5fd4a9686b/abilities/0/ab_all_3040145000_01.js",
                    ConstructorName = "mc_ab_all_3040145000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040145000_01",
                            Path = "npc/8fa966e2-0c05-4bc4-918d-9b5fd4a9686b/abilities/0/ab_all_3040145000_01.png",
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
                            Element = Element.Dark,
                            DamageModifier = 3,
                            HitNumber = 2,
                            DamageCap = 650000,
                            HitAllTargets = true,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (olivia, targetPositionInFrontline, raidActions) =>
                {
                    olivia.Raid.Enemies.ApplyStatusEffects(
                        new StatusEffectSnapshot
                        {
                            Id = TwilightTerrorId,
                            TurnDuration = 2,
                            IsLocal = true,
                            BaseAccuracy = 90,
                            Strength = 2,
                        },
                        raidActions);

                    olivia.Raid.Enemies.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            TurnDuration = 2,
                            BaseAccuracy = double.MaxValue,
                            IsUsedInternally = true,
                            TriggerCondition = new StatusEffectSnapshot.Types.TriggerCondition
                            {
                                Type = StatusEffectSnapshot.Types.TriggerCondition.Types.Type.HasStatusEffect,
                                Data = TwilightTerrorId,
                            },
                            IsLocal = true,
                        },
                        (TwilightTerrorId + "/ca_disabled", ModifierLibrary.CantUseChargeAttack, 0),
                        (TwilightTerrorId + "/frozen_charge_diamonds", ModifierLibrary.FrozenChargeDiamonds, 0));

                    olivia.Raid.Enemies.ApplyStatusEffects(
                        new StatusEffectSnapshot
                        {
                            Id = StatusEffectLibrary.DoubleAttackRateDownNpc,
                            RemainingDurationInSeconds = 180,
                            BaseAccuracy = 90,
                            Strength = 50,
                        },
                        raidActions);
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability PeccatumMortale(uint cooldown)
        {
            return new Ability
            {
                Name = "Peccatum Mortale",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/8fa966e2-0c05-4bc4-918d-9b5fd4a9686b/abilities/1/ab_3040145000_01.js",
                    ConstructorName = "mc_ab_3040145000_01_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040145000_01",
                            Path = "npc/8fa966e2-0c05-4bc4-918d-9b5fd4a9686b/abilities/1/ab_3040145000_01.png",
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
                            Element = Element.Dark,
                            DamageModifier = 5,
                            HitNumber = 1,
                            DamageCap = 850000,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = StatusEffectLibrary.Delay,
                            BaseAccuracy = 100,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (olivia, targetPositionInFrontline, raidActions) =>
                {
                    if (olivia.GetStatusEffect(SoulBlades) != null)
                    {
                        olivia.RemoveStatusEffect(SoulBlades);
                        olivia.Hero.GetAbilities()[1].Cast(olivia, olivia.CurrentTargetPositionInFrontline, raidActions);
                    }
                },
                AnimationName = "ab_motion",
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
            };
        }

        private static Ability Nevermore()
        {
            return new Ability
            {
                Name = "Nevermore",
                Cooldown = 7,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/8fa966e2-0c05-4bc4-918d-9b5fd4a9686b/abilities/2/ab_3040145000_02.js",
                    ConstructorName = "mc_ab_3040145000_02_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040145000_02",
                            Path = "npc/8fa966e2-0c05-4bc4-918d-9b5fd4a9686b/abilities/2/ab_3040145000_02.png",
                        },
                    },
                },
                ProcessEffects = (olivia, targetPositionInFrontline, raidActions) =>
                {
                    olivia.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            TurnDuration = 2,
                        },
                        raidActions,
                        (StatusEffectLibrary.DoubleAttackRateUpNpc, ModifierLibrary.FlatDoubleAttackRateBoost, 30),
                        (StatusEffectLibrary.DebuffSuccessRateUpSummon, ModifierLibrary.FlatDoubleAttackRateBoost, 30));

                    olivia.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = StatusEffectLibrary.CriticalHitRateBoostNpc,
                            TurnDuration = 2,
                            Strength = 100,
                            ExtraData = new CriticalHit
                            {
                                DamageMultiplier = 0.3,
                            }.ToByteString(),
                        },
                        raidActions);
                },
                AnimationName = "ab_motion",
                ShouldRepositionSpriteAnimation = true,
            };
        }

        private static void ProcessPassiveEffects(EntitySnapshot olivia)
        {
            if (!olivia.IsAlive() || olivia.PositionInFrontline >= 4)
            {
                return;
            }

            olivia.ApplyStatusEffect(
                new StatusEffectSnapshot
                {
                    Id = "olivia/passive/echo",
                    Strength = Math.Min(30, 3 * olivia.Raid.Turn),
                    Modifier = ModifierLibrary.AdditionalDamage,
                    AttackElementRestriction = Element.Dark,
                    IsUsedInternally = true,
                    IsPassiveEffect = true,
                });

            olivia.ApplyStatusEffect(
                new StatusEffectSnapshot
                {
                    Id = "olivia/passive/light_def_down",
                    Strength = Math.Max(-30, -3 * olivia.Raid.Turn),
                    Modifier = ModifierLibrary.FlatDefenseBoost,
                    AttackElementRestriction = Element.Light,
                    BaseAccuracy = double.MaxValue,
                    IsUsedInternally = true,
                    IsPassiveEffect = true,
                });

            if (olivia.GetStatusEffects(ModifierLibrary.ElementalAttackBoost).Any(e => !e.IsUsedInternally && e.AttackElementRestriction == Element.Dark))
            {
                olivia.ApplyStatusEffect(
                    new StatusEffectSnapshot
                    {
                        Id = "olivia/passive",
                        Modifier = ModifierLibrary.Seraphic,
                        AttackElementRestriction = Element.Dark,
                        Strength = 10,
                        IsPassiveEffect = true,
                        IsUsedInternally = true,
                    });
            }
        }
    }
}