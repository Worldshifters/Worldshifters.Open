// <copyright file="Naya.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Fire
{
    using System;
    using System.Linq;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class Naya
    {
        public static Guid Id = Guid.Parse("7605ff24-e980-4deb-bafd-0a64ff2f2d08");

        private const string BenevolentSoulId = "naya/benevolent_soul";
        private const string TheSunReversedId = "naya/the_sun_reversed";
        private const string SunTouchedParadiseId = "naya/field";
        private const string BlessedRadianceId = "naya/blessed_radiance";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Naya",
                Race = Race.Unknow,
                Gender = Gender.Female,
                MaxAttack = 9808,
                MaxHp = 1315,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Description = "Power too great, strength too great—her destiny was altered by the whisper of a demon who snuck in using dark sentiments and the departure of a friend. But in the end, the brilliant power which at last fled from restraints is sure to illuminate the way of the path.",
                Element = Element.Fire,
                WeaponProficiencies = { EquipmentType.Melee },
                AvailablePerkIds =
                {
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.ChargeAttackDamageBoost,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.TripleAttackRateBoost,
                    ExtendedMasteryPerks.FireAttackBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.FireDamageReduction,
                    ExtendedMasteryPerks.FireDamageReduction,
                    ExtendedMasteryPerks.SupportSkill,
                },
                Abilities =
                {
                    SunTouchedParadise(cooldown: 14),
                    RenatianCreed(cooldown: 14),
                    new Ability
                    {
                        Name = "Wrath of the Goddess",
                        Description = "Inflict Immaculate Sunlight to party members and enemies.",
                        Cooldown = 12,
                        ModelMetadata = new ModelMetadata
                        {
                            ConstructorName = "mc_ab_3040167000_01",
                            JsAssetPath = "npc/7605ff24-e980-4deb-bafd-0a64ff2f2d08/abilities/2/ability.js",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "ab_3040167000_01",
                                    Path = "npc/7605ff24-e980-4deb-bafd-0a64ff2f2d08/abilities/2/ab_3040167000_01.png",
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
                                    Element = Element.Fire,
                                    HitNumber = 1,
                                    DamageCap = 1_080_000,
                                    DamageModifier = 10,
                                    HitAllTargets = true,
                                }.ToByteString(),
                            },
                            ApplyStatusEffect.FromTemplate(
                                new ApplyStatusEffect
                                {
                                    BaseAccuracy = 200,
                                    IsLocal = true,
                                    TurnDuration = 4,
                                    OnAllEnemies = true,
                                },
                                (StatusEffectLibrary.DefenseDownNpcLocal, -25),
                                (StatusEffectLibrary.AttackDownNpcLocal, -25),
                                (StatusEffectLibrary.Shorted, 0)),
                        },
                        AnimationName = "ab_motion",
                        ProcessEffects = (naya, _, raidActions) =>
                        {
                            naya.Raid.Enemies.ApplyStatusEffects(
                                new StatusEffectSnapshot
                                {
                                    Id = "naya/immaculate_sunlight",
                                    IsLocal = true,
                                    BaseAccuracy = 200,
                                    TurnDuration = int.MaxValue,
                                    Modifier = ModifierLibrary.Burnt,
                                    IsUndispellable = true,
                                    Strength = 5,
                                    ExtraData = new Burn
                                    {
                                        DamageCap = 500_000,
                                        IsPercentageBased = true,
                                    }.ToByteString(),
                                },
                                raidActions);

                            naya.Raid.Allies.ApplyStatusEffects(
                                new StatusEffectSnapshot
                                {
                                    Id = "naya/immaculate_sunlight_on_allies",
                                    IsLocal = true,
                                    BaseAccuracy = double.MaxValue,
                                    TurnDuration = int.MaxValue,
                                    Modifier = ModifierLibrary.Burnt,
                                    IsUndispellable = true,
                                    Strength = 5,
                                    ExtraData = new Burn
                                    {
                                        DamageCap = 800,
                                        IsPercentageBased = true,
                                    }.ToByteString(),
                                },
                                raidActions);
                        },
                    },
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        Ability = SunTouchedParadise(cooldown: 12),
                        RequiredLevel = 55,
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        Ability = RenatianCreed(cooldown: 12),
                        RequiredLevel = 75,
                        UpgradedAbilityIndex = 1,
                    },
                },
                PassiveAbilities =
                {
                    new PassiveAbility
                    {
                        Name = "Benevolent Soul",
                        Description = "Boost to Fire allies' healing specs when the field effect Sun-Touched Paradise is active.",
                    },
                    new PassiveAbility
                    {
                        Name = "The Sun Reversed",
                        Description = "When Sub Ally: boost to Fire allies' healing specs. Remove 1 debuff from a Fire ally when that ally takes turn-based damage.",
                        Type = PassiveAbility.Types.PassiveAbilityType.BacklineEffect,
                    },
                    new PassiveAbility
                    {
                        Name = "Apostle of Purification",
                        Description = "When Switching to Main Ally: Fire allies gain Blessed Radiance.",
                        Type = PassiveAbility.Types.PassiveAbilityType.TriggerOnEnteringFrontline,
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = "Power Conflagration",
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            ConstructorName = "mc_nsp_3040161000_01_s2_special",
                            JsAssetPath = "npc/7605ff24-e980-4deb-bafd-0a64ff2f2d08/model/0/nsp_3040161000_01_s2.js",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040161000_01_s2_a",
                                    Path = "npc/7605ff24-e980-4deb-bafd-0a64ff2f2d08/model/0/nsp_3040161000_01_s2_a.png",
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040161000_01_s2_b",
                                    Path = "npc/7605ff24-e980-4deb-bafd-0a64ff2f2d08/model/0/nsp_3040161000_01_s2_b.png",
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040161000_01_s2_c",
                                    Path = "npc/7605ff24-e980-4deb-bafd-0a64ff2f2d08/model/0/nsp_3040161000_01_s2_c.png",
                                },
                            },
                        },
                    },
                    HitCount = { 1 },
                    FrameToSkipToOnAnimationSkip = { 168 },
                    ConstructorNameOnAnimationSkip = { "mc_nsp_3040161000_01_s2_special" },
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        ConstructorName = "mc_npc_3040161000_01",
                        JsAssetPath = "npc/7605ff24-e980-4deb-bafd-0a64ff2f2d08/model/0/npc_3040161000_01.js",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040161000_01_a",
                                Path = "npc/7605ff24-e980-4deb-bafd-0a64ff2f2d08/model/0/npc_3040161000_01_a.png",
                            },
                            new ImageAsset
                            {
                                Name = "npc_3040161000_01_b",
                                Path = "npc/7605ff24-e980-4deb-bafd-0a64ff2f2d08/model/0/npc_3040161000_01_b.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        ConstructorName = "mc_phit_3040161000",
                        JsAssetPath = "npc/7605ff24-e980-4deb-bafd-0a64ff2f2d08/model/0/phit_3040161000.js",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040161000",
                                Path = "npc/7605ff24-e980-4deb-bafd-0a64ff2f2d08/model/0/phit_3040161000.png",
                            },
                        },
                    },
                },
                OnActionStart = (naya, raidActions) => ProcessPassiveEffects(naya),
                OnTurnEnd = (naya, raidActions) =>
                {
                    foreach (var ally in naya.Raid.Allies)
                    {
                        if (!ally.IsAlive() || !ally.TookTurnBaseDamage)
                        {
                            continue;
                        }

                        ally.RemoveDebuff();
                    }
                },
                OnDeath = (naya, raidActions) =>
                {
                    foreach (var ally in naya.Raid.Allies)
                    {
                        if (ally.PositionInFrontline >= 4)
                        {
                            continue;
                        }

                        ally.RemoveStatusEffects(new[]
                        {
                            $"{TheSunReversedId}_healing_boost",
                            $"{TheSunReversedId}_healing_cap_boost",
                            $"{SunTouchedParadiseId}_healing_boost",
                            $"{SunTouchedParadiseId}_healing_cap_boost",
                        });
                    }
                },
                OnEnteringFrontline = (naya, raidActions) =>
                {
                    ProcessPassiveEffects(naya);
                    if (naya.GlobalState.ContainsKey("nonce"))
                    {
                        return;
                    }

                    naya.GlobalState["nonce"] = TypedValue.FromBool(true);
                    foreach (var ally in naya.Raid.Allies.Where(e => e.Element == Element.Fire))
                    {
                        ally.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = BlessedRadianceId,
                                IsBuff = true,
                                TurnDuration = int.MaxValue,
                                IsUndispellable = true,
                            }, raidActions);

                        ally.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = $"{BlessedRadianceId}_drain",
                                IsBuff = true,
                                TurnDuration = int.MaxValue,
                                IsUndispellable = true,
                                IsUsedInternally = true,
                                Modifier = ModifierLibrary.Drain,
                                Strength = 25,
                                ExtraData = new Drain
                                {
                                    HealingCap = 800,
                                    IsPercentageBased = true,
                                }.ToByteString(),
                            });

                        ally.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = $"{BlessedRadianceId}_def_up",
                                IsBuff = true,
                                TurnDuration = int.MaxValue,
                                IsUndispellable = true,
                                IsUsedInternally = true,
                                Strength = 50,
                                Modifier = ModifierLibrary.FlatDefenseBoost,
                            });
                    }
                },
            };
        }

        public static void RegisterSunTouchedParadiseFieldEffect()
        {
            FieldEffectLibrary.AddNewFieldEffect(SunTouchedParadiseId, () => new FieldEffect
            {
                Id = SunTouchedParadiseId,
                IsLocal = true,
                TurnDuration = 3,
                ProcessEffects = (raid, raidActions) =>
                {
                    foreach (var entity in raid.Allies.Concat(raid.Enemies))
                    {
                        entity.ApplyStatusEffectsFromTemplate(
                            new StatusEffectSnapshot
                            {
                                IsBuff = true,
                                IsUsedInternally = true,
                                Strength = 20,
                                IsPassiveEffect = true,
                            },
                            ($"{SunTouchedParadiseId}/atk_up", ModifierLibrary.FlatAttackBoost, 20),
                            ($"{SunTouchedParadiseId}/def_down", ModifierLibrary.FlatDefenseBoost, -25));
                    }
                },
            });
        }

        private static Ability SunTouchedParadise(uint cooldown)
        {
            return new Ability
            {
                Name = "Sun-Touched Paradise",
                Description = "Bathe the battlefield in the blazing heat of the sun.",
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    ConstructorName = "mc_ab_all_3040167000_01",
                    JsAssetPath = "npc/7605ff24-e980-4deb-bafd-0a64ff2f2d08/abilities/0/ability.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040167000_01",
                            Path = "npc/7605ff24-e980-4deb-bafd-0a64ff2f2d08/abilities/0/ab_all_3040167000_01.png",
                        },
                    },
                },
                ProcessEffects = (naya, targetPositionInFrontline, raidActions) =>
                {
                    naya.Raid.AddFieldEffect(SunTouchedParadiseId);
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability RenatianCreed(uint cooldown)
        {
            return new Ability
            {
                Name = "Renatian Creed",
                Description = "All allies deal triple attacks and deal bonus fire damage. Charge bar is frozen.",
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    ConstructorName = "mc_ab_all_3040167000_02",
                    JsAssetPath = "npc/7605ff24-e980-4deb-bafd-0a64ff2f2d08/abilities/1/ability.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040167000_02",
                            Path = "npc/7605ff24-e980-4deb-bafd-0a64ff2f2d08/abilities/1/ab_all_3040167000_02.png",
                        },
                    },
                },
                CanCast = (naya, targetPositionInFrontline) =>
                {
                    if (naya.Raid.Allies.Where(e => e.IsAlive() && e.PositionInFrontline < 4).Any(e => e.ChargeGauge < 100))
                    {
                        return (false, "Not enough charge bar");
                    }

                    return (true, string.Empty);
                },
                Effects =
                {
                    ApplyStatusEffect.FromTemplate(
                        new ApplyStatusEffect
                        {
                            TurnDuration = 4,
                            OnAllPartyMembers = true,
                            IsBuff = true,
                        },
                        (StatusEffectLibrary.TripleAttackRateUpNpc, double.MaxValue),
                        (StatusEffectLibrary.AdditionalFireDamageNpc, 30)),
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = StatusEffectLibrary.Shorted,
                            TurnDuration = 4,
                            OnAllPartyMembers = true,
                            BaseAccuracy = double.MaxValue,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (naya, _, raidActions) =>
                {
                    foreach (var ally in naya.Raid.Allies)
                    {
                        if (ally.IsAlive() && ally.PositionInFrontline < 4)
                        {
                            ally.ChargeGauge -= 100;
                        }
                    }
                },
                AnimationName = "ab_motion",
            };
        }

        private static void ProcessPassiveEffects(EntitySnapshot naya)
        {
            if (!naya.IsAlive())
            {
                return;
            }

            if (naya.PositionInFrontline < 4 && naya.Raid.GetActiveFieldEffectIds().Contains(SunTouchedParadiseId))
            {
                naya.Raid.Allies.Where(a => a.Element == Element.Fire).ApplyStatusEffectsFromTemplate(
                    new StatusEffectSnapshot
                    {
                        IsBuff = true,
                        IsPassiveEffect = true,
                        IsUsedInternally = true,
                    },
                    ($"{BenevolentSoulId}_healing_boost", ModifierLibrary.HealingBoost, 25),
                    ($"{BenevolentSoulId}_healing_cap_boost", ModifierLibrary.HealingCapBoost, 25),
                    ($"{BenevolentSoulId}_ca_boost", ModifierLibrary.FlatChargeAttackDamageBoost, 50),
                    ($"{BenevolentSoulId}_ca_cap_boost", ModifierLibrary.FlatChargeAttackDamageCapBoost, 20));
            }
            else
            {
                // Naya is a sub-ally
                naya.Raid.Allies.Where(a => a.Element == Element.Fire).ApplyStatusEffectsFromTemplate(
                    new StatusEffectSnapshot
                    {
                        IsBuff = true,
                        IsPassiveEffect = true,
                        IsUsedInternally = true,
                    },
                    ($"{TheSunReversedId}_healing_boost", ModifierLibrary.HealingBoost, 20),
                    ($"{TheSunReversedId}_healing_cap_boost", ModifierLibrary.HealingCapBoost, 20));
            }
        }
    }
}
