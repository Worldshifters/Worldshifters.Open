// <copyright file="Niyon.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Wind
{
    using System;
    using System.Linq;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class Niyon
    {
        public static Guid Id = Guid.Parse("25a06a88-ac5a-45eb-9d1c-ca007f4ad82f");

        private const string HarmonicsId = "niyon/harmonics";
        private const string SharpingId = "niyon/sharping";
        private const string TuningId = "niyon/tuning";

        public static Hero NewInstance()
        {
            var chargeAttackAdditionalDamage = new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/4/ab_all_3040038000_05.js",
                    ConstructorName = "mc_ab_all_3040038000_05",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040038000_05",
                            Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/4/ab_all_3040038000_05.png",
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
                            Element = Element.Wind,
                            DamageCap = 200_000,
                            HitAllTargets = true,
                            HitNumber = 1,
                            DamageModifier = 1,
                        }.ToByteString(),
                    },
                },
            };

            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Niyon",
                Race = Race.Unknow,
                Gender = Gender.Female,
                MaxAttack = 11222,
                AttackLevels = { 9522 },
                MaxHp = 2222,
                HpLevels = { 1822 },
                MaxLevel = 100,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Wind,
                WeaponProficiencies = { EquipmentType.MusicalInstrument },
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
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.DebuffSuccessRateBoost,
                    ExtendedMasteryPerks.SupportSkill,
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/model/0/npc_3040038000_03.js",
                        ConstructorName = "mc_npc_3040038000_03",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040038000_03_a",
                                Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/model/0/npc_3040038000_03_a.png",
                            },
                            new ImageAsset
                            {
                                Name = "npc_3040038000_03_b",
                                Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/model/0/npc_3040038000_03_b.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/model/0/phit_3040038000.js",
                        ConstructorName = "mc_phit_3040038000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040038000",
                                Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/model/0/phit_3040038000.png",
                            },
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = string.Empty,
                    HitCount = { 13 },
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/model/0/nsp_3040038000_03.js",
                            ConstructorName = "mc_nsp_3040038000_03_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040038000_03",
                                    Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/model/0/nsp_3040038000_03.png",
                                },
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
                                Id = StatusEffectLibrary.Charmed,
                                Strength = 20,
                                BaseAccuracy = 75,
                                OnAllEnemies = true,
                                DurationInSeconds = 180,
                            }.ToByteString(),
                        },
                    },
                    ProcessEffects = (niyon, raidActions) =>
                    {
                        chargeAttackAdditionalDamage.Cast(niyon, raidActions);
                        foreach (var ally in niyon.Raid.Allies)
                        {
                            foreach (var buff in ally.GetStatusEffects().Where(e =>
                                e.Id == HarmonicsId || e.Id.StartsWith(SharpingId, StringComparison.OrdinalIgnoreCase)))
                            {
                                buff.TurnDuration += 2;
                            }
                        }
                    },
                    ShouldRepositionSpriteAnimationOnTarget = true,
                    ConstructorNameOnAnimationSkip = { "mc_nsp_3040038000_03_special" },
                    FrameToSkipToOnAnimationSkip = { 110, },
                },
                Abilities =
                {
                    Ninanana(cooldown: 6),
                    Kuorria(cooldown: 8),
                    Defandue(cooldown: 5),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = Ninanana(cooldown: 5),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = Kuorria(cooldown: 7, baseStrengthBoost: 1.5),
                        UpgradedAbilityIndex = 1,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 95,
                        Ability = Kuorria(cooldown: 6, baseStrengthBoost: 1.5, applyHarmonicsAndSharping: true),
                        UpgradedAbilityIndex = 1,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 100,
                        Ability = new Ability
                        {
                            Name = "Nine-Realm's Security",
                            Type = Ability.Types.AbilityType.Support,
                            Cooldown = int.MaxValue,
                            InitialCooldown = 0,
                            ModelMetadata = new ModelMetadata
                            {
                                JsAssetPath =
                                    "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/3/ab_all_3040038000_03.js",
                                ConstructorName = "mc_ab_all_3040038000_03",
                                ImageAssets =
                                {
                                    new ImageAsset
                                    {
                                        Name = "ab_all_3040038000_03",
                                        Path =
                                            "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/3/ab_all_3040038000_03.png",
                                    },
                                },
                            },
                            Effects =
                            {
                                ApplyStatusEffect.FromTemplate(
                                    new ApplyStatusEffect
                                    {
                                        IsBuff = true,
                                        TurnDuration = 4,
                                        OnAllPartyMembers = true,
                                    },
                                    (StatusEffectLibrary.AdditionalDamageNpc, 50),
                                    (StatusEffectLibrary.TripleAttackRateUpNpc, double.MaxValue)),
                            },
                            AnimationName = "ab_motion",
                        },
                        UpgradedAbilityIndex = 3,
                    },
                },
                OnActionStart = (niyon, raidActions) => ProcessPassiveEffects(niyon),
                OnTurnEnd = (niyon, raidActions) =>
                {
                    if (!niyon.IsAlive())
                    {
                        return;
                    }
                },
                OnSetup = (niyon, allies, loadout) =>
                {
                    if (niyon.Hero.Level >= 95)
                    {
                        niyon.OverrideWeaponSeraphicModifier(20);
                    }
                },
                OnEnteringFrontline = (niyon, raidActions) => ProcessPassiveEffects(niyon),
            };
        }

        private static Ability Ninanana(uint cooldown)
        {
            return new Ability
            {
                Name = "Ninanana",
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/0/ab_all_3040038000_02.js",
                    ConstructorName = "mc_ab_all_3040038000_02",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040038000_02",
                            Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/0/ab_all_3040038000_02.png",
                        },
                    },
                },
                ProcessEffects = (niyon, _, raidActions) =>
                {
                    niyon.Raid.Enemies.ApplyStatusEffects(
                        new StatusEffectSnapshot
                        {
                            Id = StatusEffectLibrary.Sleep,
                            BaseAccuracy = 100,
                            TurnDuration = 4 + (int)(ThreadSafeRandom.NextDouble() * 3),
                            IsLocal = true,
                        },
                        raidActions);
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Kuorria(uint cooldown, double baseStrengthBoost = 1, bool applyHarmonicsAndSharping = false)
        {
            return new Ability
            {
                Name = "Kuorria",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/3/ab_all_3040038000_03.js",
                    ConstructorName = "mc_ab_all_3040038000_03",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040038000_03",
                            Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/3/ab_all_3040038000_03.png",
                        },
                    },
                },
                Effects =
                {
                    ApplyStatusEffect.FromTemplate(
                        new ApplyStatusEffect
                        {
                            IsBuff = true,
                            TurnDuration = 3,
                            OnAllPartyMembers = true,
                        },
                        (StatusEffectLibrary.DoubleAttackRateUpNpc, 30 * baseStrengthBoost),
                        (StatusEffectLibrary.AttackUpNpc, 20 * baseStrengthBoost),
                        (StatusEffectLibrary.DefenseUpNpc, 20 * baseStrengthBoost)),
                },
                ProcessEffects = (niyon, targetPositionInFrontline, raidActions) =>
                {
                    if (!applyHarmonicsAndSharping)
                    {
                        return;
                    }

                    foreach (var ally in niyon.Raid.Allies)
                    {
                        if (!ally.IsAlive() || ally.PositionInFrontline >= 4)
                        {
                            continue;
                        }

                        ally.ApplyStatusEffectsFromTemplate(
                            new StatusEffectSnapshot
                            {
                                IsBuff = true,
                                TurnDuration = 3,
                            },
                            raidActions,
                            ($"{HarmonicsId}", ModifierLibrary.AttackBoost, 30),
                            ($"{SharpingId}_da_up", ModifierLibrary.FlatDoubleAttackRateBoost, 20),
                            ($"{SharpingId}_ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 20));
                    }
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Defandue(uint cooldown)
        {
            return new Ability
            {
                Name = "Defandue",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/2/ab_all_3040038000_01.js",
                    ConstructorName = "mc_ab_all_3040038000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040038000_01",
                            Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/2/ab_all_3040038000_01.png",
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
                            Id = StatusEffectLibrary.CriticalHitRateBoostNpc,
                            Strength = 30,
                            IsBuff = true,
                            OnAllPartyMembers = true,
                            TurnDuration = 3,
                            ExtraData = new CriticalHit
                            {
                                DamageMultiplier = 0.3,
                            }.ToByteString(),
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (niyon, targetPositionInFrontline, raidActions) =>
                {
                    if (niyon.Hero.Level >= 85)
                    {
                        niyon.Raid.Allies.ApplyStatusEffects(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.Shield,
                                IsBuff = true,
                                TurnDuration = 3,
                                Strength = 2000,
                            },
                            raidActions);
                    }

                    niyon.Raid.Enemies.ApplyStatusEffects(
                        new StatusEffectSnapshot
                        {
                            Id = TuningId,
                            BaseAccuracy = 100,
                            RemainingDurationInSeconds = 180,
                            Strength = 9999,
                            Modifier = ModifierLibrary.Burnt,
                            ExtraData = new Burn
                            {
                                DamageCap = 9999,
                            }.ToByteString(),
                        },
                        raidActions);
                },
                AnimationName = "ab_motion",
            };
        }

        private static void ProcessPassiveEffects(EntitySnapshot niyon)
        {
            if (!niyon.IsAlive() || niyon.PositionInFrontline >= 4)
            {
                return;
            }

            niyon.Raid.Allies.ApplyStatusEffects(new StatusEffectSnapshot
            {
                Id = "niyon/mystic_musician",
                Strength = 10,
                IsBuff = true,
                Modifier = ModifierLibrary.FlatDebuffSuccessRateBoost,
                IsUndispellable = true,
                IsUsedInternally = true,
                TurnDuration = 1,
            });

            if (niyon.Hero.Level >= 90)
            {
                niyon.Raid.Enemies.ApplyStatusEffects(new StatusEffectSnapshot
                {
                    Id = $"{TuningId}_dmg_reduction",
                    Strength = -20,
                    BaseAccuracy = double.MaxValue,
                    Modifier = ModifierLibrary.DamageReductionBoost,
                    IsUndispellable = true,
                    IsUsedInternally = true,
                    TriggerCondition = new StatusEffectSnapshot.Types.TriggerCondition
                    {
                        Type = StatusEffectSnapshot.Types.TriggerCondition.Types.Type.HasStatusEffect,
                        Data = TuningId,
                    },
                });
            }
        }
    }
}