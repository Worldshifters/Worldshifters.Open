// <copyright file="Alexiel.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Earth
{
    using System;
    using System.Collections.Generic;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;

    public static class Alexiel
    {
        public static Guid Id = Guid.Parse("7d3a79da-c92d-4c5a-be19-ab507b8320c7");

        private const string MirrorBladeId = "alexiel/mirror_blade";
        private const string GuardianOfTheRealmId = "alexiel/earth_dmg_boost";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Alexiel",
                Race = Race.Unknow,
                Gender = Gender.Female,
                MaxAttack = 7000,
                MaxHp = 1960,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Earth,
                WeaponProficiencies = { EquipmentType.Sword, EquipmentType.Katana },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/7d3a79da-c92d-4c5a-be19-ab507b8320c7/model/0/npc_3040158000_02.js",
                        ConstructorName = "mc_npc_3040158000_02",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040158000_02_a",
                                Path = "npc/7d3a79da-c92d-4c5a-be19-ab507b8320c7/model/0/npc_3040158000_02_a.png",
                            },
                            new ImageAsset
                            {
                                Name = "npc_3040158000_02_b",
                                Path = "npc/7d3a79da-c92d-4c5a-be19-ab507b8320c7/model/0/npc_3040158000_02_b.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/7d3a79da-c92d-4c5a-be19-ab507b8320c7/model/0/phit_3040158000.js",
                        ConstructorName = "mc_phit_3040158000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040158000",
                                Path = "npc/7d3a79da-c92d-4c5a-be19-ab507b8320c7/model/0/phit_3040158000.png",
                            },
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = string.Empty,
                    HitCount = { 7 },
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "npc/7d3a79da-c92d-4c5a-be19-ab507b8320c7/model/0/nsp_3040158000_02.js",
                            ConstructorName = "mc_nsp_3040158000_02_special",
                        },
                    },
                    Effects =
                    {
                        new AbilityEffect
                        {
                            Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                            ExtraData = new ApplyStatusEffect
                            {
                                Id = StatusEffectLibrary.Dispel,
                                BaseAccuracy = double.MaxValue,
                            }.ToByteString(),
                        },
                    },
                    ProcessEffects = (alexiel, raidActions) =>
                    {
                        AddMirrorBlade(alexiel, raidActions);
                    },
                },
                Abilities =
                {
                    UncrossableRealm(cooldown: 7),
                    NibelungSilt(cooldown: 14),
                    new Ability
                    {
                        Name = "Lagulf",
                        Cooldown = 7,
                        ModelMetadata = new ModelMetadata
                        {
                            JsAssetPath =
                                "npc/7d3a79da-c92d-4c5a-be19-ab507b8320c7/abilities/2/ab_all_3040158000_03.js",
                            ConstructorName = "mc_ab_all_3040158000_03",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "ab_all_3040158000_03",
                                    Path =
                                        "npc/7d3a79da-c92d-4c5a-be19-ab507b8320c7/abilities/2/ab_all_3040158000_03.png",
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
                                    Element = Element.Earth,
                                    HitNumber = 6,
                                    RandomTargets = true,
                                    DamageModifier = 1.5,
                                    DamageCap = 200_000,
                                }.ToByteString(),
                            },
                        },
                        ProcessEffects = (alexiel, targetIndex, raidActions) =>
                        {
                            AddMirrorBlade(alexiel, raidActions);
                        },
                        AnimationName = "ab_motion",
                    },
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = UncrossableRealm(cooldown: 6),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = NibelungSilt(cooldown: 12),
                        UpgradedAbilityIndex = 1,
                    },
                },
                OnActionStart = (alexiel, raidActions) => ProcessPassiveEffects(alexiel),
                OnEnteringFrontline = (alexiel, raidActions) => ProcessPassiveEffects(alexiel),
                OnDeath = (alexiel, raidActions) =>
                {
                    foreach (var ally in alexiel.Raid.Allies)
                    {
                        if (ally.PositionInFrontline < 4)
                        {
                            ally.RemoveStatusEffect(GuardianOfTheRealmId);
                        }
                    }
                },
            };
        }

        private static Ability UncrossableRealm(uint cooldown)
        {
            return new Ability
            {
                Name = "Uncrossable Realm",
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath =
                        "npc/7d3a79da-c92d-4c5a-be19-ab507b8320c7/abilities/0/ab_all_3040158000_01.js",
                    ConstructorName = "mc_ab_all_3040158000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040158000_01",
                            Path =
                                "npc/7d3a79da-c92d-4c5a-be19-ab507b8320c7/abilities/0/ab_all_3040158000_01.png",
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
                            Id = StatusEffectLibrary.DamageCutUpNpc,
                            IsBuff = true,
                            TurnDuration = 1,
                            OnAllPartyMembers = true,
                        }.ToByteString(),
                    },
                },
                AnimationName = "ab_motion_2",
            };
        }

        private static Ability NibelungSilt(uint cooldown)
        {
            return new Ability
            {
                Name = string.Empty,
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath =
                        "npc/7d3a79da-c92d-4c5a-be19-ab507b8320c7/abilities/1/ab_all_3040158000_02.js",
                    ConstructorName = "mc_ab_all_3040158000_02",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040158000_02",
                            Path =
                                "npc/7d3a79da-c92d-4c5a-be19-ab507b8320c7/abilities/1/ab_all_3040158000_02.png",
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
                            Element = Element.Earth,
                            DamageModifier = 2.5,
                            HitNumber = 1,
                            HitAllTargets = true,
                            DamageCap = 630_000,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = StatusEffectLibrary.Unchallenged,
                            IsBuff = true,
                            OnAllPartyMembers = true,
                            TurnDuration = int.MaxValue,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = StatusEffectLibrary.Veil,
                            IsBuff = true,
                            OnAllPartyMembers = true,
                            TurnDuration = int.MaxValue,
                        }.ToByteString(),
                    },
                },
                AnimationName = "ab_motion",
            };
        }

        private static void ProcessPassiveEffects(EntitySnapshot alexiel)
        {
            if (!alexiel.IsAlive() || alexiel.PositionInFrontline >= 4)
            {
                return;
            }

            foreach (var ally in alexiel.Raid.Allies)
            {
                if (ally.IsAlive() && ally.PositionInFrontline < 4)
                {
                    ally.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = GuardianOfTheRealmId,
                            IsBuff = true,
                            IsUsedInternally = true,
                            Modifier = ModifierLibrary.ElementalAttackBoostAmplification,
                            Strength = 30,
                            TurnDuration = 1,
                            IsPassiveEffect = true,
                        });
                }
            }

            ProcessMirrorBladeEffects(alexiel);
        }

        private static void ProcessMirrorBladeEffects(EntitySnapshot alexiel)
        {
            if (!alexiel.IsAlive() || alexiel.PositionInFrontline >= 4)
            {
                return;
            }

            var bladeCount = alexiel.GetStatusEffectStacks(MirrorBladeId);
            if (bladeCount == 0)
            {
                return;
            }

            alexiel.ApplyStatusEffectsFromTemplate(
                new StatusEffectSnapshot
                {
                    IsBuff = true,
                    IsUndispellable = true,
                    IsUsedInternally = true,
                    TurnDuration = int.MaxValue,
                },
                ($"{MirrorBladeId}/atk_up", ModifierLibrary.FlatAttackBoost, 10 * bladeCount),
                ($"{MirrorBladeId}/def_up", ModifierLibrary.FlatDefenseBoost, 10 * bladeCount),
                ($"{MirrorBladeId}/ca_up", ModifierLibrary.FlatChargeAttackDamageBoost, 10 * (bladeCount + 1)),
                ($"{MirrorBladeId}/ca_cap_up", ModifierLibrary.FlatChargeAttackDamageCapBoost, 5 * (bladeCount + 1)));
        }

        private static void AddMirrorBlade(EntitySnapshot alexiel, IList<RaidAction> raidActions)
        {
            alexiel.OverrideStatusEffect(
                new StatusEffectSnapshot
                {
                    Id = $"{MirrorBladeId}_1",
                    Strength = 1,
                    IsBuff = true,
                    IsUndispellable = true,
                    TurnDuration = int.MaxValue,
                },
                MirrorBladeId,
                (previousStatusEffect, newStatusEffect) =>
                {
                    var bladeCount = Math.Min(5, (int)previousStatusEffect.Strength + 1);
                    newStatusEffect.Strength = bladeCount;
                    newStatusEffect.Id = $"{MirrorBladeId}_{bladeCount}";
                    return bladeCount > 0;
                },
                raidActions);

            ProcessMirrorBladeEffects(alexiel);
        }
    }
}