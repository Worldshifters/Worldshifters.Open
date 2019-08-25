// <copyright file="Andira.cs" company="Worldshifters">
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
    using static Data.Raid.StatusEffectSnapshot.Types;

    public static class Andira
    {
        public static Guid Id = Guid.Parse("e0db0d71-c148-49af-8f86-9d403136e311");

        private const string QueenOfMonkeysId = "andira/passive_dodge";
        private const string LoopId = "andira/loop";
        private const string InfiniteDiversityId = "andira/infinite_diversity";
        private const string SageOfEternityId = "andira/sage_of_eternity";
        private const string MizaruId = "andira/mizaru";
        private const string IwazaruId = "andira/iwazaru";
        private const string KikazaruId = "andira/kikazaru";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Andira",
                Race = Race.Erune,
                Gender = Gender.Female,
                MaxAttack = 7560 + 360,
                MaxHp = 1400 + 270,
                MaxLevel = 100,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Wind,
                WeaponProficiencies = { EquipmentType.Staff, EquipmentType.Melee },
                AvailablePerkIds =
                {
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.DebuffResistanceBoost,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.TripleAttackRateBoost,
                    ExtendedMasteryPerks.WindAttackBoost,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.EarthDamageReduction,
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
                        JsAssetPath = "npc/e0db0d71-c148-49af-8f86-9d403136e311/model/0/npc_3040071000_03.js",
                        ConstructorName = "mc_npc_3040071000_03",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040071000_03",
                                Path = "npc/e0db0d71-c148-49af-8f86-9d403136e311/model/0/npc_3040071000_03.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/e0db0d71-c148-49af-8f86-9d403136e311/model/0/phit_3040071000.js",
                        ConstructorName = "mc_phit_3040071000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040071000",
                                Path = "npc/e0db0d71-c148-49af-8f86-9d403136e311/model/0/phit_3040071000.png",
                            },
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = string.Empty,
                    HitCount = { 14 },
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "npc/e0db0d71-c148-49af-8f86-9d403136e311/model/0/nsp_3040071000_03_s3.js",
                            ConstructorName = "mc_nsp_3040071000_03_s3_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040071000_03_s3",
                                    Path = "npc/e0db0d71-c148-49af-8f86-9d403136e311/model/0/nsp_3040071000_03_s3.png",
                                },
                            },
                        },
                    },
                    UpradedEffects =
                    {
                        new AbilityEffectUpgrade
                        {
                            RequiredRank = 5,
                            Effect = new AbilityEffect
                            {
                                Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                                ExtraData = new ApplyStatusEffect
                                {
                                    Id = StatusEffectLibrary.Dispel,
                                    BaseAccuracy = 200,
                                }.ToByteString(),
                            },
                        },
                    },
                    ProcessEffects = (andira, raidActions) =>
                    {
                        if (andira.Hero.Level < 95)
                        {
                            return;
                        }

                        andira.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = InfiniteDiversityId,
                                TurnDuration = int.MaxValue,
                                IsBuff = true,
                                Modifier = ModifierLibrary.DodgeRateBoost,
                                Strength = 100,
                                IsUndispellable = true,
                            },
                            raidActions);

                        andira.ApplyStatusEffectsFromTemplate(
                            new StatusEffectSnapshot
                            {
                                TurnDuration = int.MaxValue,
                                IsBuff = true,
                                IsUndispellable = true,
                                IsUsedInternally = true,
                                TriggerCondition = new TriggerCondition
                                {
                                    Type = TriggerCondition.Types.Type.HasStatusEffect,
                                    Data = InfiniteDiversityId,
                                    LinkToParentCondition = true,
                                },
                            },
                            ($"{InfiniteDiversityId}/atk_up", ModifierLibrary.FlatAttackBoost, 20),
                            ($"{InfiniteDiversityId}/da_up", ModifierLibrary.FlatDoubleAttackRateBoost, 20),
                            ($"{InfiniteDiversityId}/ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 10));

                        andira.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = $"{InfiniteDiversityId}_echo",
                                TurnDuration = int.MaxValue,
                                IsBuff = true,
                                IsUndispellable = true,
                                Strength = 20,
                                Modifier = ModifierLibrary.AdditionalDamage,
                                AttackElementRestriction = Element.Wind,
                                TriggerCondition = new TriggerCondition
                                {
                                    Type = TriggerCondition.Types.Type.HasStatusEffect,
                                    Data = InfiniteDiversityId,
                                    LinkToParentCondition = true,
                                },
                            });
                    },
                },
                Abilities =
                {
                    UnbornUndying(cooldown: 12),
                    SageOfEternity(cooldown: 6, upgradeLevel: 0),
                    Tricumulo(cooldown: 8),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = UnbornUndying(cooldown: 12, upgraded: true),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = SageOfEternity(cooldown: 6, upgradeLevel: 1),
                        UpgradedAbilityIndex = 1,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 90,
                        Ability = SageOfEternity(cooldown: 6, upgradeLevel: 2),
                        UpgradedAbilityIndex = 1,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 95,
                        Ability = new Ability
                        {
                            Name = "Multi-Decree",
                            Type = Ability.Types.AbilityType.Offensive,
                            Cooldown = 5,
                            ModelMetadata = new ModelMetadata
                            {
                                JsAssetPath = "npc/e0db0d71-c148-49af-8f86-9d403136e311/abilities/3/ab_all_3040071000_01.js",
                                ConstructorName = "mc_ab_all_3040071000_01",
                                ImageAssets =
                                {
                                    new ImageAsset
                                    {
                                        Name = "ab_all_3040071000_01",
                                        Path = "npc/e0db0d71-c148-49af-8f86-9d403136e311/abilities/3/ab_all_3040071000_01.png",
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
                                        DamageCap = 400_000,
                                        HitAllTargets = true,
                                        HitNumber = 1,
                                        DamageModifier = 2.0,
                                    }.ToByteString(),
                                },
                            },
                            ProcessEffects = (andira, _, raidActions) =>
                            {
                                if (!andira.GlobalState.ContainsKey("decree_stacks"))
                                {
                                    andira.GlobalState.Add("decree_stacks", TypedValue.FromLong(0));
                                }

                                var stacks = andira.GlobalState["decree_stacks"].IntegerValue;
                                var newStackCount = Math.Min(stacks + 1, 3);

                                foreach (var enemy in andira.Raid.Enemies)
                                {
                                    if (!enemy.IsAlive() || enemy.PositionInFrontline >= 4)
                                    {
                                        continue;
                                    }

                                    enemy.ApplyStatusEffectsFromTemplate(
                                        new StatusEffectSnapshot
                                        {
                                            IsLocal = true,
                                            BaseAccuracy = 100,
                                            TurnDuration = int.MaxValue,
                                            IsUndispellable = true,
                                        },
                                        raidActions,
                                        ($"{MizaruId}_{newStackCount}", ModifierLibrary.FlatAttackBoost, -5 * newStackCount),
                                        ($"{IwazaruId}_{newStackCount}", ModifierLibrary.FlatDefenseBoost, -5 * stacks),
                                        ($"{KikazaruId}_{newStackCount}", ModifierLibrary.None, 0));

                                    var statusEffectsToRemove = new HashSet<string>();
                                    for (var oldStackCount = 1; oldStackCount < newStackCount; ++oldStackCount)
                                    {
                                        statusEffectsToRemove.Add($"{MizaruId}_{oldStackCount}");
                                        statusEffectsToRemove.Add($"{IwazaruId}_{oldStackCount}");
                                        statusEffectsToRemove.Add($"{KikazaruId}_{oldStackCount}");
                                    }

                                    enemy.RemoveStatusEffects(statusEffectsToRemove);
                                }

                                andira.Raid.Allies.ApplyStatusEffectsFromTemplate(
                                    new StatusEffectSnapshot
                                    {
                                        IsBuff = true,
                                        IsPassiveEffect = true,
                                        IsUsedInternally = true,
                                        TurnDuration = int.MaxValue,
                                        TriggerCondition = new TriggerCondition
                                        {
                                            Type = TriggerCondition.Types.Type.HasStatusEffect,
                                            Data = $"{KikazaruId}_{newStackCount}",
                                        },
                                    },
                                    ($"{KikazaruId}_{newStackCount}_ca_boost", ModifierLibrary.FlatChargeAttackDamageBoost, 15 * newStackCount),
                                    ($"{KikazaruId}_{newStackCount}_ca_cap_boost", ModifierLibrary.FlatChargeAttackDamageCapBoost, 15 * newStackCount));

                                andira.GlobalState["decree_stacks"].IntegerValue = Math.Min(andira.GlobalState["decree_stacks"].IntegerValue + 1, 3);
                            },
                            AnimationName = "ab_motion",
                        },
                        UpgradedAbilityIndex = 3,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 100,
                        Ability = Tricumulo(cooldown: 7),
                        UpgradedAbilityIndex = 2,
                    },
                },
                OnActionStart = (andira, raidActions) => ProcessEffects(andira),
                OnTurnEnd = (andira, raidActions) =>
                {
                    if (andira.DodgedDamage)
                    {
                        andira.RemoveStatusEffect(InfiniteDiversityId);
                    }

                    foreach (var ally in andira.Raid.Allies)
                    {
                        StatusEffectSnapshot sageOfEternity;
                        if (ally.IsAlive() && ally.PositionInFrontline < 4 &&
                            (sageOfEternity = ally.GetStatusEffect(SageOfEternityId)) != null &&
                            ally.TookDamageDuringTurn)
                        {
                            ally.RemoveStatusEffect(SageOfEternityId);
                        }
                    }
                },
                OnEnteringFrontline = (andira, raidActions) => ProcessEffects(andira),
                OnDeath = (andira, raidActions) =>
                {
                    foreach (var ally in andira.Raid.Allies)
                    {
                        if (ally.PositionInFrontline < 4)
                        {
                            ally.RemoveStatusEffect(QueenOfMonkeysId);
                        }
                    }
                },
            };
        }

        private static Ability UnbornUndying(uint cooldown, bool upgraded = false)
        {
            return new Ability
            {
                Name = "Unborn, Undying",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Healing,
                Effects =
                {
                    ApplyStatusEffect.FromTemplate(
                        new ApplyStatusEffect
                        {
                            BaseAccuracy = double.MaxValue,
                            TurnDuration = upgraded ? 2 : 3,
                            OnAllPartyMembers = true,
                        },
                        (StatusEffectLibrary.DefenseDownNpc, upgraded ? 25 : 30),
                        (StatusEffectLibrary.DebuffResistanceDownNpc, upgraded ? 25 : 30)),
                },
                ProcessEffects = (andira, _, raidActions) =>
                {
                    foreach (var ally in andira.Raid.Allies)
                    {
                        if (!ally.IsAlive() || ally.PositionInFrontline >= 4)
                        {
                            continue;
                        }

                        ally.Heal(long.MaxValue, raidActions, andira);
                    }
                },
                ShouldRepositionSpriteAnimation = true,
                AnimationName = "ab_motion",
            };
        }

        private static Ability SageOfEternity(uint cooldown, int upgradeLevel)
        {
            return new Ability
            {
                Name = "Sage of Eternity",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/e0db0d71-c148-49af-8f86-9d403136e311/abilities/1/ab_3040071000_01.js",
                    ConstructorName = "mc_ab_3040071000_01_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040071000_01",
                            Path = "npc/e0db0d71-c148-49af-8f86-9d403136e311/abilities/1/ab_3040071000_01.png",
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
                            Id = StatusEffectLibrary.Substitute,
                            OnSelectedTarget = true,
                            TurnDuration = 1,
                            IsBuff = true,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (andira, targetPositionInFrontline, raidActions) =>
                {
                    var target = andira.Raid.Allies.AtPosition(targetPositionInFrontline);
                    if (upgradeLevel == 0)
                    {
                        target.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.Shield,
                                TurnDuration = 3,
                                Strength = 2500,
                                IsBuff = true,
                            },
                            raidActions);
                    }
                    else if (upgradeLevel == 1)
                    {
                        target.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.Shield,
                                TurnDuration = 3,
                                Strength = 3500,
                                IsBuff = true,
                            },
                            raidActions);
                    }
                    else if (upgradeLevel == 2)
                    {
                        target.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.Shield,
                                TurnDuration = int.MaxValue,
                                Strength = 4500,
                                IsBuff = true,
                            },
                            raidActions);
                        target.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = SageOfEternityId,
                                TurnDuration = int.MaxValue,
                                Strength = 30,
                                Modifier = ModifierLibrary.AdditionalDamage,
                                AttackElementRestriction = Element.Wind,
                                IsBuff = true,
                            },
                            raidActions);
                    }
                },
                AbilityTargetting = AbilityTargettingType.TargetSingleAliveFrontLineMember,
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
                AnimationName = "ab_motion",
            };
        }

        private static Ability Tricumulo(uint cooldown)
        {
            return new Ability
            {
                Name = "Tricumulo",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/e0db0d71-c148-49af-8f86-9d403136e311/abilities/2/ab_all_3040071000_02.js",
                    ConstructorName = "mc_ab_all_3040071000_02",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040071000_02",
                            Path = "npc/e0db0d71-c148-49af-8f86-9d403136e311/abilities/2/ab_all_3040071000_02.png",
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
                            Id = LoopId,
                            OnAllPartyMembers = true,
                            IsBuff = true,
                            TurnDuration = 6,
                            IsUndispellable = true,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (andira, _, raidActions) =>
                {
                    if (!andira.GlobalState.ContainsKey("tricumulo_uses"))
                    {
                        andira.GlobalState.Add("tricumulo_uses", TypedValue.FromLong(0));
                    }

                    if (andira.GlobalState["tricumulo_uses"].IntegerValue >= 1)
                    {
                        andira.Raid.Allies.ApplyStatusEffects(
                            new StatusEffectSnapshot
                            {
                                Id = $"{LoopId}_crit_rate_up",
                                Strength = 50,
                                IsBuff = true,
                                TurnDuration = 6,
                                Modifier = ModifierLibrary.FlatCriticalHitRateBoost,
                                ExtraData = new CriticalHit
                                {
                                    DamageMultiplier = 0.2,
                                }.ToByteString(),
                            },
                            raidActions);
                    }

                    if (andira.GlobalState["tricumulo_uses"].IntegerValue >= 2)
                    {
                        andira.Raid.Allies.ApplyStatusEffects(
                            new StatusEffectSnapshot
                            {
                                Id = $"{LoopId}_dmg_cap_boost",
                                Strength = 10,
                                IsBuff = true,
                                TurnDuration = 6,
                                Modifier = ModifierLibrary.FlatDamageCapBoost,
                            },
                            raidActions);
                    }

                    andira.GlobalState["tricumulo_uses"].IntegerValue += 1;
                    ProcessLoopEffects(andira);
                },
                AnimationName = "ab_motion",
            };
        }

        private static void ProcessLoopEffects(EntitySnapshot andira)
        {
            foreach (var ally in andira.Raid.Allies)
            {
                StatusEffectSnapshot loop;
                if ((loop = ally.GetStatusEffect(LoopId)) == null)
                {
                    continue;
                }

                ally.RemoveStatusEffects(new[]
                {
                    $"{LoopId}_atk_up",
                    $"{LoopId}_def_up",
                    $"{LoopId}_debuff_rate_up",
                    $"{LoopId}_da_up",
                    $"{LoopId}_ta_up",
                });

                if (andira.Hero.Level == 100)
                {
                    ally.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            IsBuff = true,
                            IsUndispellable = true,
                            TurnDuration = loop.TurnDuration,
                        },
                        ($"{LoopId}_atk_up", ModifierLibrary.AttackBoost, 50),
                        ($"{LoopId}_def_up", ModifierLibrary.FlatDefenseBoost, 50),
                        ($"{LoopId}_debuff_rate_up", ModifierLibrary.FlatDebuffSuccessRateBoost, 30),
                        ($"{LoopId}_da_up", ModifierLibrary.FlatDoubleAttackRateBoost, 30),
                        ($"{LoopId}_ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 15));
                }
                else
                {
                    var attackAndDefBoost = 10;
                    var debuffSuccessRateBoost = 5;
                    var doubleAttackRateBoost = 6.0;
                    if (loop.TurnDuration == 5 || loop.TurnDuration == 2)
                    {
                        doubleAttackRateBoost = 15;
                        debuffSuccessRateBoost = 15;
                        attackAndDefBoost = 25;
                    }
                    else if (loop.TurnDuration == 4)
                    {
                        doubleAttackRateBoost = 30;
                        debuffSuccessRateBoost = 30;
                        attackAndDefBoost = 50;
                    }
                    else if (loop.TurnDuration == 3)
                    {
                        doubleAttackRateBoost = 21;
                        debuffSuccessRateBoost = 20;
                        attackAndDefBoost = 35;
                    }

                    ally.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            IsBuff = true,
                            IsUndispellable = true,
                            TurnDuration = loop.TurnDuration,
                        },
                        ($"{LoopId}_atk_up", ModifierLibrary.AttackBoost, attackAndDefBoost),
                        ($"{LoopId}_def_up", ModifierLibrary.FlatDefenseBoost, attackAndDefBoost),
                        ($"{LoopId}_debuff_rate_up", ModifierLibrary.FlatDebuffSuccessRateBoost, debuffSuccessRateBoost),
                        ($"{LoopId}_da_up", ModifierLibrary.FlatDoubleAttackRateBoost, doubleAttackRateBoost),
                        ($"{LoopId}_ta_up", ModifierLibrary.FlatTripleAttackRateBoost, doubleAttackRateBoost / 2));
                }
            }
        }

        private static void ProcessEffects(EntitySnapshot andira)
        {
            ProcessLoopEffects(andira);

            if (!andira.IsAlive() || andira.PositionInFrontline >= 4)
            {
                return;
            }

            andira.ApplyStatusEffect(new StatusEffectSnapshot
            {
                Id = QueenOfMonkeysId,
                IsBuff = true,
                Modifier = ModifierLibrary.DodgeRateBoost,
                Strength = 5,
                IsPassiveEffect = true,
                IsUsedInternally = true,
            });
        }
    }
}