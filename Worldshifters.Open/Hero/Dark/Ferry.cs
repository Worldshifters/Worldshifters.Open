// <copyright file="Ferry.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Dark
{
    using System;
    using System.Linq;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Hero.Abilities;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class Ferry
    {
        public static Guid Id = Guid.Parse("82b4e629-4cda-481a-8b81-f45f2ce7db19");

        private const string GhostCageId = "ferry/ghost_cage";
        private const string FreigeistId = "ferry/freigeist";

        public static Hero NewInstance()
        {
            var ghostCage = new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/82b4e629-4cda-481a-8b81-f45f2ce7db19/abilities/3/ab_all_3040209000_01.js",
                    ConstructorName = "mc_ab_all_3040209000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040209000_01",
                            Path = "npc/82b4e629-4cda-481a-8b81-f45f2ce7db19/abilities/3/ab_all_3040209000_01.png",
                        },
                    },
                },
                ProcessEffects = (ferry, targetIndex, raidActions) =>
                {
                    foreach (var enemy in ferry.Raid.Enemies)
                    {
                        if (enemy.IsAlive() && enemy.PositionInFrontline < 4)
                        {
                            enemy.DealRawDamage(999_999, Element.Null, raidActions);
                        }
                    }
                },
            };

            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Ferry",
                Race = Race.Unknow,
                Gender = Gender.Female,
                MaxAttack = 7100,
                MaxHp = 1550,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Dark,
                WeaponProficiencies = { EquipmentType.Dagger },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/82b4e629-4cda-481a-8b81-f45f2ce7db19/model/0/npc_3040209000_02.js",
                        ConstructorName = "mc_npc_3040209000_02",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040209000_02_a",
                                Path = "npc/82b4e629-4cda-481a-8b81-f45f2ce7db19/model/0/npc_3040209000_02_a.png",
                            },
                            new ImageAsset
                            {
                                Name = "npc_3040209000_02_b",
                                Path = "npc/82b4e629-4cda-481a-8b81-f45f2ce7db19/model/0/npc_3040209000_02_b.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/82b4e629-4cda-481a-8b81-f45f2ce7db19/model/0/phit_3040209000.js",
                        ConstructorName = "mc_phit_3040209000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040209000",
                                Path = "npc/82b4e629-4cda-481a-8b81-f45f2ce7db19/model/0/phit_3040209000.png",
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
                            JsAssetPath = "npc/82b4e629-4cda-481a-8b81-f45f2ce7db19/model/0/nsp_3040209000_02_s3.js",
                            ConstructorName = "mc_nsp_3040209000_02_s3_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040209000_02_s3",
                                    Path = "npc/82b4e629-4cda-481a-8b81-f45f2ce7db19/model/0/nsp_3040209000_02_s3.png",
                                },
                            },
                        },
                    },
                    ProcessEffects = (ferry, raidActions) =>
                    {
                        SupportAbilities.DarkAttackUpForParty(30, 4, SupportAbilities.StackingType.Npc, new AbilityEffect
                        {
                            Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                            ExtraData = new ApplyStatusEffect
                            {
                                Id = StatusEffectLibrary.DoubleAttackRateUpNpc,
                                Strength = 30,
                                IsBuff = true,
                                TurnDuration = 4,
                                OnAllPartyMembers = true,
                            }.ToByteString(),
                        }).Cast(ferry, ferry.Raid.SelectedTarget, raidActions);
                    },
                },
                Abilities =
                {
                    BlauGespenst(cooldown: 7),
                    Benediction(cooldown: 7),
                    new Ability
                    {
                        Name = string.Empty,
                        Cooldown = 9,
                        ModelMetadata = new ModelMetadata
                        {
                            JsAssetPath = "npc/82b4e629-4cda-481a-8b81-f45f2ce7db19/abilities/2/ab_3040209000_03.js",
                            ConstructorName = "mc_ab_3040209000_03",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "ab_3040209000_03",
                                    Path = "npc/82b4e629-4cda-481a-8b81-f45f2ce7db19/abilities/2/ab_3040209000_03.png",
                                },
                            },
                        },
                        ShouldRepositionSpriteAnimation = true,
                        AbilityTargetting = AbilityTargettingType.TargetSingleAliveFrontLineMemberExcludingSelf,
                        RepositionOnTarget = true,
                        CanCast = (ferry, targetIndex) =>
                        {
                            var target = ferry.Raid.Allies.AtPosition(targetIndex);
                            if (!target.IsAlive())
                            {
                                return (false, string.Empty);
                            }

                            if (target.IsAlive() && target.Element != Element.Dark)
                            {
                                return (false, "Can only target a Dark ally");
                            }

                            return (true, string.Empty);
                        },
                        ProcessEffects = (ferry, targetIndex, raidActions) =>
                        {
                            var target = ferry.Raid.Allies.AtPosition(targetIndex);

                            var buffs = new (string, Modifier, double)[]
                            {
                                ($"{FreigeistId}_da_up", ModifierLibrary.FlatDoubleAttackRateBoost, 100),
                                ($"{FreigeistId}_ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 20),
                                ($"{FreigeistId}_ca_up", ModifierLibrary.FlatChargeAttackDamageBoost, 50),
                                ($"{FreigeistId}_ca_cap_up", ModifierLibrary.FlatChargeAttackDamageCapBoost, 10),
                                ($"{FreigeistId}_gauge_boost", ModifierLibrary.ChargeBarSpedUp, 20),
                                ($"{FreigeistId}_autorevive", ModifierLibrary.AutoRevive, 50),
                            };

                            if (ferry.Raid.Turn >= 10)
                            {
                                buffs = buffs.Append((StatusEffectLibrary.TripleStrike, ModifierLibrary.None, 0)).ToArray();
                            }

                            target.ApplyStatusEffectsFromTemplate(
                                new StatusEffectSnapshot
                                {
                                    IsBuff = true,
                                    TurnDuration = 5,
                                    IsUndispellable = true,
                                },
                                raidActions,
                                buffs);

                            target.ApplyStatusEffect(
                                new StatusEffectSnapshot
                                {
                                    Id = $"{FreigeistId}_aggro_up",
                                    Strength = 10,
                                    Modifier = ModifierLibrary.HostilityBoost,
                                    BaseAccuracy = double.MaxValue,
                                    TurnDuration = 5,
                                    IsUndispellable = true,
                                },
                                raidActions);
                        },
                        AnimationName = "ab_motion",
                    },
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = BlauGespenst(cooldown: 6),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = Benediction(cooldown: 6),
                        UpgradedAbilityIndex = 1,
                    },
                },
                PassiveAbilities =
                {
                    new PassiveAbility
                    {
                        Name = "On the Brink",
                        Description = "10% Light and Dark damage reduction to all allies.",
                    },
                    new PassiveAbility
                    {
                        Name = "Ghostly Call",
                        Description = "10% Bonus Dark DMG effect to all allies against foes with Ghost Cage.",
                    },
                },
                OnActionStart = (ferry, raidActions) =>
                {
                    if (!ferry.IsAlive() || ferry.PositionInFrontline >= 4)
                    {
                        return;
                    }

                    foreach (var ally in ferry.Raid.Allies)
                    {
                        if (!ally.IsAlive() || ally.PositionInFrontline > 4)
                        {
                            continue;
                        }

                        ally.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = "ferry/light_dmg_reduction",
                                IsBuff = true,
                                IsPassiveEffect = true,
                                IsUsedInternally = true,
                                Strength = 10,
                                Modifier = ModifierLibrary.DamageReductionBoost,
                                AttackElementRestriction = Element.Light,
                            });

                        ally.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = "ferry/dark_dmg_reduction",
                                IsBuff = true,
                                IsPassiveEffect = true,
                                IsUsedInternally = true,
                                Strength = 10,
                                Modifier = ModifierLibrary.DamageReductionBoost,
                                AttackElementRestriction = Element.Dark,
                            });
                    }
                },
                OnTurnEnd = (ferry, raidActions) =>
                {
                    foreach (var enemy in ferry.Raid.Enemies)
                    {
                        if (enemy.IsAlive() && enemy.NumSpecialAttacksUsedThisTurn > 0 &&
                            enemy.GetStatusEffects().Any(e => e.Id == GhostCageId))
                        {
                            ghostCage.Cast(ferry, ferry.Raid.SelectedTarget, raidActions);
                            enemy.RemoveStatusEffect(GhostCageId);
                            break;
                        }
                    }
                },
                OnDeath = (ferry, raidActions) =>
                {
                    foreach (var ally in ferry.Raid.Allies)
                    {
                        if (!ally.IsAlive() || ally.PositionInFrontline > 4)
                        {
                            continue;
                        }

                        ally.RemoveStatusEffects(new[] { "ferry/light_dmg_reduction", "ferry/dark_dmg_reduction" });
                    }
                },
                OnEnteringFrontline = (ferry, raidActions) => { },
            };
        }

        private static Ability BlauGespenst(uint cooldown)
        {
            return new Ability
            {
                Name = "Blau Gespenst",
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/82b4e629-4cda-481a-8b81-f45f2ce7db19/abilities/0/ab_3040209000_01.js",
                    ConstructorName = "mc_ab_3040209000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040209000_01",
                            Path = "npc/82b4e629-4cda-481a-8b81-f45f2ce7db19/abilities/0/ab_3040209000_01.png",
                        },
                    },
                },
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
                Effects =
                {
                    ApplyStatusEffect.FromTemplate(
                        new ApplyStatusEffect
                        {
                            BaseAccuracy = 90,
                            DurationInSeconds = 180,
                        },
                        (StatusEffectLibrary.AttackDownNpc2, -25),
                        (StatusEffectLibrary.DefenseDownNpc2, -25)),
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = GhostCageId,
                            BaseAccuracy = 100,
                            TurnDuration = int.MaxValue,
                            IsUndispellable = true,
                        }.ToByteString(),
                    },
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Benediction(uint cooldown)
        {
            return new Ability
            {
                Name = "Benediction",
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/82b4e629-4cda-481a-8b81-f45f2ce7db19/abilities/1/ab_3040209000_02.js",
                    ConstructorName = "mc_ab_3040209000_02",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040209000_02",
                            Path = "npc/82b4e629-4cda-481a-8b81-f45f2ce7db19/abilities/1/ab_3040209000_02.png",
                        },
                    },
                },
                ShouldRepositionSpriteAnimation = true,
                Effects =
                {
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.Healing,
                        ExtraData = new Heal
                        {
                            OnAllPartyMembers = true,
                            HealingCap = 1500,
                            HpPercentageRecovered = 15,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = StatusEffectLibrary.ChargeGaugeBoost,
                            OnAllPartyMembers = true,
                            IsBuff = true,
                            Strength = 20,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = StatusEffectLibrary.RevitalizeNpc,
                            OnAllPartyMembers = true,
                            IsBuff = true,
                            Strength = 5,
                            TurnDuration = 3,
                            ExtraData = new Revitalize
                            {
                                HealingCap = 400,
                                IsPercentageBased = true,
                                BoostChargeGaugeAtFullHp = true,
                            }.ToByteString(),
                        }.ToByteString(),
                    },
                },
                AnimationName = "ab_motion",
            };
        }
    }
}