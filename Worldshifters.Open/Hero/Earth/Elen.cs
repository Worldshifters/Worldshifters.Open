﻿// <copyright file="Elen.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Earth
{
    using System;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Hero.Abilities;
    using Worldshifters.Data.Raid;

    public static class Elen
    {
        public static Guid Id = Guid.Parse("1fd2d3bf-ec70-4c97-9a02-4e08a941bd3a");

        private const string EightLifePilgrimageId = "elen/8_life_pilgrimage";
        private const string AikiId = "elen/aiki";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Elen",
                Race = Race.Unknow,
                Gender = Gender.Female,
                MaxAttack = 12888,
                AttackLevels = { 10788 },
                MaxHp = 2088,
                HpLevels = { 1788 },
                MaxLevel = 100,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Earth,
                WeaponProficiencies = { EquipmentType.Katana },
                MaxChargeGauge = 200,
                AvailablePerkIds =
                {
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.ChargeAttackDamageBoost,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.WaterDamageReduction,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.ChargeAttackDamageBoost,
                    ExtendedMasteryPerks.ChargeAttackDamageBoost,
                    ExtendedMasteryPerks.SupportSkill,
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/1fd2d3bf-ec70-4c97-9a02-4e08a941bd3a/model/0/npc_3040089000_02.js",
                        ConstructorName = "mc_npc_3040089000_02",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040089000_02",
                                Path = "npc/1fd2d3bf-ec70-4c97-9a02-4e08a941bd3a/model/0/npc_3040089000_02.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/1fd2d3bf-ec70-4c97-9a02-4e08a941bd3a/model/0/phit_3040089000.js",
                        ConstructorName = "mc_phit_3040089000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040089000",
                                Path = "npc/1fd2d3bf-ec70-4c97-9a02-4e08a941bd3a/model/0/phit_3040089000.png",
                            },
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = string.Empty,
                    HitCount = { 9 },
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "npc/1fd2d3bf-ec70-4c97-9a02-4e08a941bd3a/model/0/nsp_3040089000_02.js",
                            ConstructorName = "mc_nsp_3040089000_02_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040089000_02",
                                    Path = "npc/1fd2d3bf-ec70-4c97-9a02-4e08a941bd3a/model/0/nsp_3040089000_02.png",
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
                                Id = StatusEffectLibrary.DoubleAttackRateUpNpc,
                                IsBuff = true,
                                TurnDuration = 3,
                                OnSelf = true,
                                Strength = 50,
                            }.ToByteString(),
                        },
                    },
                    ProcessEffects = (elen, raidActions) =>
                    {
                        if (elen.Hero.Rank >= 5)
                        {
                            SupportAbilities.EarthAttackUpForParty(20, 3, SupportAbilities.StackingType.Npc, new AbilityEffect
                            {
                                Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                                ExtraData = new ApplyStatusEffect
                                {
                                    Id = StatusEffectLibrary.TripleAttackRateUpNpc,
                                    IsBuff = true,
                                    Strength = 50,
                                    OnSelf = true,
                                    TurnDuration = 3,
                                }.ToByteString(),
                            }).Cast(elen, elen.Raid.SelectedTarget, raidActions);
                        }
                    },
                },
                Abilities =
                {
                    OpenSpirit(cooldown: 6),
                    Purgatory(cooldown: 2),
                    DanceOfTheGods(cooldown: 6),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = OpenSpirit(cooldown: 5),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = Purgatory(cooldown: 1),
                        UpgradedAbilityIndex = 1,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = DanceOfTheGods(cooldown: 5),
                        UpgradedAbilityIndex = 2,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 100,
                        Ability = new Ability
                        {
                            Name = "Eight-Life's Pilgrimage",
                            Type = Ability.Types.AbilityType.Support,
                            Cooldown = int.MaxValue,
                            InitialCooldown = 10,
                            Effects =
                            {
                                new AbilityEffect
                                {
                                    Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                                    ExtraData = new ApplyStatusEffect
                                    {
                                        Id = StatusEffectLibrary.ChargeGaugeBoost,
                                        Strength = 200,
                                        IsBuff = true,
                                        OnSelf = true,
                                    }.ToByteString(),
                                },
                                new AbilityEffect
                                {
                                    Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                                    ExtraData = new ApplyStatusEffect
                                    {
                                        Id = EightLifePilgrimageId,
                                        IsBuff = true,
                                        OnSelf = true,
                                        IsPassiveEffect = true,
                                        TurnDuration = int.MaxValue,
                                    }.ToByteString(),
                                },
                            },
                            ModelMetadata = new ModelMetadata
                            {
                                JsAssetPath = "npc/1fd2d3bf-ec70-4c97-9a02-4e08a941bd3a/abilities/3/ab_3040037000_01.js",
                                ConstructorName = "mc_ab_3040037000_01",
                                ImageAssets =
                                {
                                    new ImageAsset
                                    {
                                        Name = "ab_3040037000_01",
                                        Path = "npc/1fd2d3bf-ec70-4c97-9a02-4e08a941bd3a/abilities/3/ab_3040037000_01.png",
                                    },
                                },
                            },
                            ShouldRepositionSpriteAnimation = true,
                        },
                        UpgradedAbilityIndex = 3,
                    },
                },
                OnActionStart = (elen, raidActions) => ProcessPassiveEffects(elen),
                OnTurnEnd = (elen, raidActions) =>
                {
                    if (!elen.IsAlive())
                    {
                        return;
                    }

                    if (elen.GetStatusEffects().Any(e => e.Id == EightLifePilgrimageId))
                    {
                        if (elen.PositionInFrontline < 4)
                        {
                            raidActions.Add(elen.AddChargeGauge(10));
                        }
                        else
                        {
                            elen.AddChargeGauge(10);
                        }
                    }

                    int supportSkillRank;
                    if (elen.PositionInFrontline < 4 && elen.Raid.GetNumSpecialAttacksUsedThisTurn() >= 2 && (supportSkillRank = elen.Hero.GetSupportSkillRank()) > 0)
                    {
                        foreach (var ally in elen.Raid.Allies)
                        {
                            if (ally.PositionInFrontline >= 4 || ally.PositionInFrontline == elen.PositionInFrontline)
                            {
                                continue;
                            }

                            // +5 charge gauge at rank 1, +8 at rank 2, +10 at rank 3
                            raidActions.Add(ally.AddChargeGauge((int)Math.Ceiling((supportSkillRank + 1) * 2.5)));
                        }
                    }
                },
                OnSetup = (elen, allies, loadout) =>
                {
                    if (elen.Hero.Level >= 95)
                    {
                        // 20% boost to damage against Water foes, non stackable with Seraphic effects from weapons
                        elen.OverrideWeaponSeraphicModifier(20);
                    }

                    if (elen.Hero.Level >= 90)
                    {
                        elen.ApplyStatusEffect(new StatusEffectSnapshot
                        {
                            Id = "elen/blade_god_da_up",
                            Modifier = ModifierLibrary.FlatDoubleAttackRateBoost,
                            Strength = 20,
                            IsBuff = true,
                            IsPassiveEffect = true,
                            IsUsedInternally = true,
                            TurnDuration = int.MaxValue,
                        });
                    }

                    elen.ApplyStatusEffect(new StatusEffectSnapshot
                    {
                        Id = "elen/blade_god",
                        Modifier = ModifierLibrary.ChargeBarSpedUp,
                        Strength = 100,
                        IsBuff = true,
                        IsPassiveEffect = true,
                        IsUsedInternally = true,
                        TurnDuration = int.MaxValue,
                    });
                },
                OnEnteringFrontline = (elen, raidActions) => ProcessPassiveEffects(elen),
            };
        }

        private static Ability OpenSpirit(uint cooldown)
        {
            var openSpirit = SupportAbilities.AttackUpForSelf(new AbilityEffect
            {
                Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                ExtraData = new ApplyStatusEffect
                {
                    Id = StatusEffectLibrary.AttackUpNpc,
                    IsBuff = true,
                    OnSelf = true,
                    TurnDuration = 3,
                    Strength = 50,
                }.ToByteString(),
            });

            openSpirit.Name = "Open Spirit";
            openSpirit.Cooldown = (int)cooldown;
            openSpirit.CanCast = (elen, targetIndex) =>
            {
                if (elen.Hero.Level >= 85)
                {
                    return (true, string.Empty);
                }

                if (elen.ChargeGauge < 10)
                {
                    return (false, "Not enough charge gauge");
                }

                return (true, string.Empty);
            };

            openSpirit.ProcessEffects = (elen, targetIndex, raidActions) =>
            {
                if (elen.Hero.Level >= 85)
                {
                    elen.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = StatusEffectLibrary.CriticalHitRateBoostNpc,
                            Strength = 75,
                            IsBuff = true,
                            TurnDuration = 3,
                            ExtraData = new CriticalHit
                            {
                                DamageMultiplier = 1,
                            }.ToByteString(),
                        }, raidActions);
                }
                else
                {
                    elen.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = StatusEffectLibrary.CriticalHitRateBoostNpc,
                            Strength = 30,
                            IsBuff = true,
                            TurnDuration = 3,
                            ExtraData = new CriticalHit
                            {
                                DamageMultiplier = 0.3,
                            }.ToByteString(),
                        }, raidActions);
                }
            };

            return openSpirit;
        }

        private static Ability Purgatory(uint cooldown)
        {
            var purgatory = SupportAbilities.ChargeBarBoost();
            purgatory.Name = "Purgatory";
            purgatory.Cooldown = (int)cooldown;
            purgatory.CanCast = (elen, targetIndex) =>
            {
                if (elen.ChargeGauge < 30)
                {
                    return (false, "Not enough charge gauge");
                }

                return (true, string.Empty);
            };

            purgatory.ProcessEffects = (elen, targetIndex, raidActions) =>
            {
                elen.ChargeGauge -= 30;
                foreach (var ally in elen.Raid.Allies)
                {
                    if (!ally.IsAlive() || ally.PositionInFrontline == elen.PositionInFrontline)
                    {
                        continue;
                    }

                    SupportAbilities.ChargeBarBoost(new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = StatusEffectLibrary.ChargeGaugeBoost,
                            Strength = 10,
                            IsBuff = true,
                            OnSelf = true,
                        }.ToByteString(),
                    }).Cast(ally, elen.Raid.SelectedTarget, raidActions);
                }
            };

            return purgatory;
        }

        private static Ability DanceOfTheGods(uint cooldown)
        {
            return new Ability
            {
                Name = "Dance of the Gods",
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/1fd2d3bf-ec70-4c97-9a02-4e08a941bd3a/abilities/2/ab_3040025000_01.js",
                    ConstructorName = "mc_ab_3040025000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040025000_01",
                            Path = "npc/1fd2d3bf-ec70-4c97-9a02-4e08a941bd3a/abilities/2/ab_3040025000_01.png",
                        },
                    },
                },
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
                ProcessEffects = (elen, targetIndex, raidActions) =>
                {
                    if (elen.Hero.Level < 95)
                    {
                        return;
                    }

                    elen.OverrideStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = $"{AikiId}_1",
                            Strength = 1,
                            IsBuff = true,
                            IsUndispellable = true,
                            TurnDuration = int.MaxValue,
                        },
                        AikiId,
                        (previousStatusEffect, newStatusEffect) =>
                        {
                            var aikiStacks = Math.Min(3, (int)previousStatusEffect.Strength + 1);
                            newStatusEffect.Strength = aikiStacks;
                            newStatusEffect.Id = $"{AikiId}_{aikiStacks}";
                            return aikiStacks > 0;
                        },
                        raidActions);
                },
            };
        }

        private static void ProcessPassiveEffects(EntitySnapshot elen)
        {
            if (!elen.IsAlive() || elen.PositionInFrontline >= 4)
            {
                return;
            }

            switch (elen.GetStatusEffectStacks(AikiId))
            {
                case 1:
                    elen.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            IsBuff = true,
                            IsUsedInternally = true,
                            IsUndispellable = true,
                            TurnDuration = int.MaxValue,
                        },
                        ("elen/atk_up", ModifierLibrary.FlatAttackBoost, 20),
                        ("elen/def_up", ModifierLibrary.FlatDefenseBoost, 50));
                    break;

                case 2:
                    elen.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            IsBuff = true,
                            IsUsedInternally = true,
                            IsUndispellable = true,
                            TurnDuration = int.MaxValue,
                        },
                        ("elen/atk_up", ModifierLibrary.FlatAttackBoost, 20),
                        ("elen/def_up", ModifierLibrary.FlatDefenseBoost, 50),
                        ("elen/da_up", ModifierLibrary.FlatDoubleAttackRateBoost, 30),
                        ("elen/ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 30));
                    break;

                case 3:
                    elen.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            IsBuff = true,
                            IsUsedInternally = true,
                            IsUndispellable = true,
                            TurnDuration = int.MaxValue,
                        },
                        ("elen/atk_up", ModifierLibrary.FlatAttackBoost, 20),
                        ("elen/def_up", ModifierLibrary.FlatDefenseBoost, 50),
                        ("elen/da_up", ModifierLibrary.FlatDoubleAttackRateBoost, 30),
                        ("elen/ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 30),
                        ("elen/dmg_cap_up", ModifierLibrary.FlatDamageCapBoost, 10));
                    break;

                default:
                    break;
            }
        }
    }
}