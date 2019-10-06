// <copyright file="Seofon.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Wind
{
    using System;
    using System.Collections.Generic;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class Seofon
    {
        public static Guid Id = Guid.Parse("e1b46e04-56b2-4354-a2aa-6593a6905bb1");

        private const string SwordshineId = "seofon/swordshine";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Seofon",
                Race = Race.Human,
                Gender = Gender.Male,
                MaxAttack = 12777,
                AttackLevels = { 10777 },
                MaxHp = 1777,
                HpLevels = { 1477 },
                MaxLevel = 100,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Wind,
                WeaponProficiencies = { EquipmentType.Sword },
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
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.ChargeAttackDamageBoost,
                    ExtendedMasteryPerks.HostilityReduction,
                    ExtendedMasteryPerks.DodgeRateBoost,
                    ExtendedMasteryPerks.SupportSkill,
                },
                PassiveAbilities =
                {
                    new PassiveAbility
                    {
                        Type = PassiveAbility.Types.PassiveAbilityType.SupportSkill,
                        Name = "Passive ability 1",
                        Description = "Passive ability 1 description",
                    },
                    new PassiveAbility
                    {
                        Type = PassiveAbility.Types.PassiveAbilityType.SupportSkill,
                        Name = "Passive ability 2",
                        Description = "Passive ability 2 description",
                    },
                },
                UpgradedPassiveAbilities =
                {
                    new PassiveAbilityUpgrade
                    {
                        Ability = new PassiveAbility
                        {
                            Type = PassiveAbility.Types.PassiveAbilityType.SupportSkill,
                            Name = "Upgraded passive ability 2",
                            Description = "Upgraded passive ability 2 description",
                        },
                        RequiredLevel = 85,
                        RequiredRank = 5,
                        UpgradedPassiveAbilityIndex = 2,
                    },
                    new PassiveAbilityUpgrade
                    {
                        Ability = new PassiveAbility
                        {
                            Type = PassiveAbility.Types.PassiveAbilityType.SupportSkill,
                            Name = "Passive ability 3",
                            Description = "Passive ability 3 description",
                        },
                        RequiredLevel = 95,
                        RequiredRank = 5,
                        UpgradedPassiveAbilityIndex = 3,
                    },
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/e1b46e04-56b2-4354-a2aa-6593a6905bb1/model/0/npc_3040036000_03.js",
                        ConstructorName = "mc_npc_3040036000_03",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040036000_03_a",
                                Path = "npc/e1b46e04-56b2-4354-a2aa-6593a6905bb1/model/0/npc_3040036000_03_a.png",
                            },
                            new ImageAsset
                            {
                                Name = "npc_3040036000_03_b",
                                Path = "npc/e1b46e04-56b2-4354-a2aa-6593a6905bb1/model/0/npc_3040036000_03_b.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/e1b46e04-56b2-4354-a2aa-6593a6905bb1/model/0/phit_3040036000.js",
                        ConstructorName = "mc_phit_3040036000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040036000",
                                Path = "npc/e1b46e04-56b2-4354-a2aa-6593a6905bb1/model/0/phit_3040036000.png",
                            },
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = string.Empty,
                    HitCount = { 8 },

                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "npc/e1b46e04-56b2-4354-a2aa-6593a6905bb1/model/0/nsp_3040036000_03.js",
                            ConstructorName = "mc_nsp_3040036000_03_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040036000_03",
                                    Path = "npc/e1b46e04-56b2-4354-a2aa-6593a6905bb1/model/0/nsp_3040036000_03.png",
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
                                Id = StatusEffectLibrary.AttackUpNpc,
                                TurnDuration = 3,
                                IsBuff = true,
                                Strength = 30,
                                OnAllPartyMembers = true,
                            }.ToByteString(),
                        },
                    },
                    ProcessEffects = (seofon, raidActions) =>
                    {
                        if (seofon.Hero.Rank == 5)
                        {
                            seofon.ApplyStatusEffect(
                                new StatusEffectSnapshot
                                {
                                    Id = StatusEffectLibrary.Unchallenged,
                                    Strength = 1,
                                    IsBuff = true,
                                    TurnDuration = 3,
                                });
                        }
                    },
                    ShouldRepositionSpriteAnimationOnTarget = true,
                },
                Abilities =
                {
                    Emblema(),
                    InfinitoCreare(cooldown: 6),
                    CuoreDiLeone(),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 95,
                        Ability = InfinitoCreare(cooldown: 5),
                        UpgradedAbilityIndex = 1,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 100,
                        Ability = new Ability
                        {
                            Name = "Seven-Star's Brilliance",
                            Type = Ability.Types.AbilityType.Support,
                            Cooldown = int.MaxValue,
                            InitialCooldown = 10,
                            ModelMetadata = new ModelMetadata
                            {
                                JsAssetPath = "npc/e1b46e04-56b2-4354-a2aa-6593a6905bb1/abilities/3/ab_3040036000_02.js",
                                ConstructorName = "mc_ab_3040036000_02_effect",
                                ImageAssets =
                                {
                                    new ImageAsset
                                    {
                                        Name = "ab_3040036000_02",
                                        Path = "npc/e1b46e04-56b2-4354-a2aa-6593a6905bb1/abilities/3/ab_3040036000_02.png",
                                    },
                                },
                            },
                            CanCast = (seofon, _) =>
                            {
                                if (seofon.GetStatusEffectStacks(SwordshineId) < 3)
                                {
                                    return (false, "Not enough Swordshine stacks");
                                }

                                return (true, string.Empty);
                            },
                            ProcessEffects = (seofon, targetPositionInFrontline, raidActions) =>
                            {
                                foreach (var ally in seofon.Raid.Allies)
                                {
                                    if (ally.PositionInFrontline >= 4)
                                    {
                                        break;
                                    }

                                    ally.ChargeGauge = 100;
                                }

                                seofon.Raid.Allies.ApplyStatusEffectsFromTemplate(
                                    new StatusEffectSnapshot
                                    {
                                        IsBuff = true,
                                        TurnDuration = 1,
                                    },
                                    raidActions,
                                    ("seofon/ca_up", ModifierLibrary.FlatChargeAttackDamageBoost, 150),
                                    ("seofon/ca_cap_up", ModifierLibrary.FlatChargeAttackDamageCapBoost, 90));
                            },
                            AnimationName = "ab_motion",
                            ShouldRepositionSpriteAnimation = true,
                        },
                        UpgradedAbilityIndex = 3,
                    },
                },
                OnActionStart = (seofon, raidActions) => ProcessPassiveEffects(seofon),
                OnTurnEnd = (seofon, raidActions) =>
                {
                    if (!seofon.IsAlive() || seofon.PositionInFrontline >= 4)
                    {
                        return;
                    }

                    if (!seofon.TookDamageDuringTurn)
                    {
                        return;
                    }

                    var stacks = seofon.GetStatusEffectStacks(SwordshineId);
                    if (stacks > 0)
                    {
                        if (seofon.Hero.Level >= 85)
                        {
                            seofon.ApplyOrOverrideStatusEffectStacks(SwordshineId, (uint) stacks, -2, 5, raidActions, seofon.GetStatusEffect(SwordshineId + "_" + stacks).TurnDuration);
                        }
                        else
                        {
                            seofon.ApplyOrOverrideStatusEffectStacks(SwordshineId, (uint) stacks, -stacks, 3, raidActions);
                        }

                        ProcessSwordshineEffects(seofon);
                    }
                },
                OnSetup = (seofon, allies, loadout) =>
                {
                    if (seofon.Hero.Level >= 95)
                    {
                        seofon.OverrideWeaponSeraphicModifier(20);
                    }
                },
                OnEnteringFrontline = (seofon, raidActions) => ProcessPassiveEffects(seofon),
            };
        }

        private static Ability Emblema()
        {
            return new Ability
            {
                Name = "Emblema",
                Cooldown = 1,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/e1b46e04-56b2-4354-a2aa-6593a6905bb1/abilities/1/ab_3040036000_01.js",
                    ConstructorName = "mc_ab_3040036000_01_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040036000_01",
                            Path = "npc/e1b46e04-56b2-4354-a2aa-6593a6905bb1/abilities/1/ab_3040036000_01.png",
                        },
                    },
                },
                ProcessEffects = (seofon, _, raidActions) =>
                {
                    int increment = seofon.Hero.Level >= 85 ? 2 : 1;
                    uint maxStackCount = seofon.Hero.Level >= 85 ? 5U : 3U;
                    int turnDuration = seofon.Hero.Level >= 85 ? 5 : (seofon.Hero.Level >= 55 ? 3 : 2);
                    turnDuration += seofon.Hero.GetSupportSkillRank();
                    seofon.ApplyOrOverrideStatusEffectStacks(SwordshineId, (uint)increment, increment, maxStackCount, raidActions, turnDuration);
                    ProcessSwordshineEffects(seofon);
                },
                AnimationName = "ab_motion",
                ShouldRepositionSpriteAnimation = true,
            };
        }

        private static Ability InfinitoCreare(uint cooldown)
        {
            return new Ability
            {
                Name = "Infinito Creare",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/e1b46e04-56b2-4354-a2aa-6593a6905bb1/abilities/0/ab_all_3040036000_01.js",
                    ConstructorName = "mc_ab_all_3040036000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040036000_01",
                            Path = "npc/e1b46e04-56b2-4354-a2aa-6593a6905bb1/abilities/0/ab_all_3040036000_01.png",
                        },
                    },
                },
                ProcessEffects = (seofon, targetPositionInFrontline, raidActions) =>
                {
                    new MultihitDamage
                    {
                        Element = Element.Wind,
                        DamageModifier = (seofon.Hero.Level >= 75 ? 0.9 : 0.6) + ThreadSafeRandom.NextDouble() * 0.1,
                        HitNumber = 10,
                        RandomTargets = true,
                        DamageCap = 70_000,
                    }.ProcessEffects(seofon, raidActions);

                    if (seofon.Hero.Level >= 95)
                    {
                        seofon.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.ChargeGaugeBoost,
                                IsBuff = true,
                                Strength = 30,
                            }, raidActions);
                    }
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability CuoreDiLeone()
        {
            return new Ability
            {
                Name = "Cuore Di Leone",
                Cooldown = 14,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/e1b46e04-56b2-4354-a2aa-6593a6905bb1/abilities/2/ab_all_3040036000_02.js",
                    ConstructorName = "mc_ab_all_3040036000_02",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040036000_02",
                            Path = "npc/e1b46e04-56b2-4354-a2aa-6593a6905bb1/abilities/2/ab_all_3040036000_02.png",
                        },
                    },
                },
                CanCast = (seofon, _) =>
                {
                    if (seofon.GetStatusEffectStacks(SwordshineId) < 3)
                    {
                        return (false, "Not enough Swordshine stacks");
                    }

                    return (true, string.Empty);
                },
                ProcessEffects = (seofon, targetPositionInFrontline, raidActions) =>
                {
                    var stacks = seofon.GetStatusEffectStacks(SwordshineId);
                    seofon.ApplyOrOverrideStatusEffectStacks(SwordshineId, (uint)stacks, -3, 5, raidActions, seofon.GetStatusEffect(SwordshineId + "_" + stacks).TurnDuration);
                    foreach (var ally in seofon.Raid.Allies)
                    {
                        if (ally.PositionInFrontline >= 4)
                        {
                            break;
                        }

                        ally.ChargeGauge = 100;
                    }
                },
                AnimationName = "ab_motion",
            };
        }

        private static void ProcessPassiveEffects(EntitySnapshot seofon)
        {
            if (!seofon.IsAlive() || seofon.PositionInFrontline >= 4)
            {
                return;
            }

            seofon.Raid.Allies.ApplyStatusEffects(
                new StatusEffectSnapshot
                {
                    Id = "seofon/passive",
                    TurnDuration = 1,
                    IsBuff = true,
                    IsUsedInternally = true,
                    IsUndispellable = true,
                    Strength = 50,
                    Modifier = ModifierLibrary.FlatChargeAttackDamageBoost,
                });

            if (seofon.Hero.Level >= 90)
            {
                seofon.Raid.Allies.ApplyStatusEffects(
                    new StatusEffectSnapshot
                    {
                        Id = "seofon/passive_2",
                        TurnDuration = 1,
                        IsBuff = true,
                        IsUsedInternally = true,
                        IsUndispellable = true,
                        Strength = 10,
                        Modifier = ModifierLibrary.FlatChargeAttackDamageCapBoost,
                    });
            }

            ProcessSwordshineEffects(seofon);
        }

        private static void ProcessSwordshineEffects(EntitySnapshot seofon)
        {
            var stacks = seofon.GetStatusEffectStacks(SwordshineId);
            if (stacks == 0)
            {
                seofon.RemoveStatusEffects(
                    new HashSet<string>
                    {
                        SwordshineId + "/atk_up",
                        SwordshineId + "/def_up",
                        SwordshineId + "/da_up",
                        SwordshineId + "/crit_up",
                    });
            }

            if (stacks == 1)
            {
                seofon.ApplyStatusEffectsFromTemplate(
                    new StatusEffectSnapshot
                    {
                        IsBuff = true,
                        IsUsedInternally = true,
                        TurnDuration = 1,
                    },
                    (SwordshineId + "/atk_up", ModifierLibrary.AttackBoost, 5),
                    (SwordshineId + "/def_up", ModifierLibrary.FlatDefenseBoost, 5),
                    (SwordshineId + "/da_up", ModifierLibrary.FlatDoubleAttackRateBoost, 50),
                    (SwordshineId + "/ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 3));
            }
            else if (stacks == 2)
            {
                seofon.ApplyStatusEffectsFromTemplate(
                    new StatusEffectSnapshot
                    {
                        IsBuff = true,
                        IsUsedInternally = true,
                        TurnDuration = 1,
                    },
                    (SwordshineId + "/atk_up", ModifierLibrary.AttackBoost, 10),
                    (SwordshineId + "/def_up", ModifierLibrary.FlatDefenseBoost, 10),
                    (SwordshineId + "/da_up", ModifierLibrary.FlatDoubleAttackRateBoost, 3),
                    (SwordshineId + "/ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 40));
            }
            else if (stacks == 3)
            {
                seofon.ApplyStatusEffectsFromTemplate(
                    new StatusEffectSnapshot
                    {
                        IsBuff = true,
                        IsUsedInternally = true,
                        TurnDuration = 1,
                    },
                    (SwordshineId + "/atk_up", ModifierLibrary.AttackBoost, 10),
                    (SwordshineId + "/def_up", ModifierLibrary.FlatDefenseBoost, 10),
                    (SwordshineId + "/ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 100));
                seofon.ApplyStatusEffect(
                    new StatusEffectSnapshot
                    {
                        Id = SwordshineId + "/crit_up",
                        IsBuff = true,
                        TurnDuration = 1,
                        IsUsedInternally = true,
                        Strength = 100,
                        Modifier = ModifierLibrary.FlatCriticalHitRateBoost,
                        ExtraData = new CriticalHit
                        {
                            DamageMultiplier = 0.3,
                        }.ToByteString(),
                    });
            }
            else if (stacks == 4)
            {
                seofon.ApplyStatusEffectsFromTemplate(
                    new StatusEffectSnapshot
                    {
                        IsBuff = true,
                        IsUsedInternally = true,
                        TurnDuration = 1,
                    },
                    (SwordshineId + "/atk_up", ModifierLibrary.AttackBoost, 15),
                    (SwordshineId + "/def_up", ModifierLibrary.FlatDefenseBoost, 15),
                    (SwordshineId + "/ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 100));
                seofon.ApplyStatusEffect(
                    new StatusEffectSnapshot
                    {
                        Id = SwordshineId + "/crit_up",
                        IsBuff = true,
                        TurnDuration = 1,
                        IsUsedInternally = true,
                        Strength = 100,
                        Modifier = ModifierLibrary.FlatCriticalHitRateBoost,
                        ExtraData = new CriticalHit
                        {
                            DamageMultiplier = 0.4,
                        }.ToByteString(),
                    });
            }
            else if (stacks == 5)
            {
                seofon.ApplyStatusEffectsFromTemplate(
                    new StatusEffectSnapshot
                    {
                        IsBuff = true,
                        IsUsedInternally = true,
                        TurnDuration = 1,
                    },
                    (SwordshineId + "/atk_up", ModifierLibrary.AttackBoost, 20),
                    (SwordshineId + "/def_up", ModifierLibrary.FlatDefenseBoost, 20),
                    (SwordshineId + "/ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 100));
                seofon.ApplyStatusEffect(
                    new StatusEffectSnapshot
                    {
                        Id = SwordshineId + "/crit_up",
                        IsBuff = true,
                        TurnDuration = 1,
                        IsUsedInternally = true,
                        Strength = 100,
                        Modifier = ModifierLibrary.FlatCriticalHitRateBoost,
                        ExtraData = new CriticalHit
                        {
                            DamageMultiplier = 0.5,
                        }.ToByteString(),
                    });
            }
        }
    }
}