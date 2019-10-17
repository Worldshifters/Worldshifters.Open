// <copyright file="JessicaThemed.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Earth
{
    using System;
    using System.Linq;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;
    using static Data.Raid.StatusEffectSnapshot.Types;

    public static class JessicaThemed
    {
        public static Guid Id = Guid.Parse("5f1f772e-6f69-497f-bd5c-a1a7a575fbad");

        private const string GodsendTriggerId = "jessica/themed/godsend_trigger";
        private const string FireSupportId = "jessica/themed/fire_support";
        private const string FeuerwerkId = "jessica/themed/feuerwerk";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Jessica",
                Races = { Race.Human },
                Gender = Gender.Female,
                MaxAttack = 5900,
                MaxHp = 1860,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Earth,
                WeaponProficiencies = { EquipmentType.Gun },
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
                PassiveAbilities =
                {
                    new PassiveAbility
                    {
                        Name = "Unforgettable Summer",
                        Description =
                            "When an ally is below 25% HP: Deal guaranteed triple attacks and 50% boost to healing specs.",
                    },
                    new PassiveAbility
                    {
                        Name = "Vacation Gear",
                        Description =
                            "Upon using charge attack: Extend Status Godsend Trigger's duration by 2 turns. Raise Status Fire Support lvl by 1.",
                    },
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/5f1f772e-6f69-497f-bd5c-a1a7a575fbad/model/0/npc_3040227000_02.js",
                        ConstructorName = "mc_npc_3040227000_02",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040227000_02",
                                Path = "npc/5f1f772e-6f69-497f-bd5c-a1a7a575fbad/model/0/npc_3040227000_02.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/5f1f772e-6f69-497f-bd5c-a1a7a575fbad/model/0/phit_3040227000.js",
                        ConstructorName = "mc_phit_3040227000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040227000",
                                Path = "npc/5f1f772e-6f69-497f-bd5c-a1a7a575fbad/model/0/phit_3040227000.png",
                            },
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = string.Empty,
                    HitCount = { 1 },
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "npc/5f1f772e-6f69-497f-bd5c-a1a7a575fbad/model/0/nsp_3040227000_02_s2.js",
                            ConstructorName = "mc_nsp_3040227000_02_s2_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040227000_02_s2_a",
                                    Path = "npc/5f1f772e-6f69-497f-bd5c-a1a7a575fbad/model/0/nsp_3040227000_02_s2_a.png",
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040227000_02_s2_b",
                                    Path = "npc/5f1f772e-6f69-497f-bd5c-a1a7a575fbad/model/0/nsp_3040227000_02_s2_b.png",
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
                                Id = StatusEffectLibrary.Blind,
                                Strength = 25,
                                BaseAccuracy = 90,
                                DurationInSeconds = 180,
                            }.ToByteString(),
                        },
                        new AbilityEffect
                        {
                            Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                            ExtraData = new ApplyStatusEffect
                            {
                                Id = StatusEffectLibrary.RemoveDebuff,
                                EffectTargettingType = EffectTargettingType.OnAllPartyMembers,
                            }.ToByteString(),
                        },
                    },
                    ProcessEffects = (jessica, raidActions) =>
                    {
                        var godsendTrigger = jessica.GetStatusEffect(GodsendTriggerId);
                        if (godsendTrigger != null)
                        {
                            godsendTrigger.TurnDuration += 2;
                        }

                        jessica.ApplyOrOverrideStatusEffectStacks(FireSupportId, initialStackCount: 1, increment: 1, maxStackCount: 2, raidActions: raidActions, isUndispellable: true);
                    },
                },
                Abilities =
                {
                    Pflegeschuss(cooldown: 8),
                    Feuerwerk(cooldown: 7),
                    Aussenseiter(cooldown: 7),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = Pflegeschuss(cooldown: 7),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = Feuerwerk(cooldown: 6),
                        UpgradedAbilityIndex = 1,
                    },
                },
                OnTurnEnd = (jessica, raidActions) =>
                {
                    if (jessica.GetStatusEffect(GodsendTriggerId) != null)
                    {
                        TryProcessUnforgettableSummerHealingBoost(jessica);
                        GodsendTrigger().Cast(jessica, raidActions);
                    }
                },
                OnAttackStart = (jessica, raidActions) =>
                {
                    if (jessica.Raid.Allies.Any(e => e.HpPercentage < 25))
                    {
                        jessica.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = "jessica/passive_ta_up",
                                Modifier = ModifierLibrary.FlatTripleAttackRateBoost,
                                IsUsedInternally = true,
                                Strength = double.PositiveInfinity,
                            });
                    }
                },
                OnAbilityStart = (jessica, raidActions) =>
                {
                    TryProcessUnforgettableSummerHealingBoost(jessica);
                },
            };
        }

        private static Ability GodsendTrigger()
        {
            return new Ability
            {
                Type = Ability.Types.AbilityType.Offensive,
                Effects =
                {
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.Healing,
                        ExtraData = new Heal
                        {
                            HpRecovered = 800,
                            HealingCap = 800,
                            EffectTargettingType = EffectTargettingType.OnAllPartyMembers,
                        }.ToByteString(),
                    },
                },
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/5f1f772e-6f69-497f-bd5c-a1a7a575fbad/abilities/0/ab_all_3040227000_01.js",
                    ConstructorName = "mc_ab_all_3040227000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040227000_01",
                            Path = "npc/5f1f772e-6f69-497f-bd5c-a1a7a575fbad/abilities/0/ab_all_3040227000_01.png",
                        },
                    },
                },
                ProcessEffects = (jessica, targetPositionInFrontline, raidActions) =>
                {
                    var fireSupportStack = jessica.GetStatusEffectStacks(FireSupportId);
                    new MultihitDamage
                    {
                        Element = Element.Earth,
                        DamageCap = (long)(480_000 * (1 + (0.5 * fireSupportStack))),
                        DamageModifier = 2.5 + (0.5 * fireSupportStack),
                        HitNumber = 1,
                        HitAllTargets = true,
                    }.ProcessEffects(jessica, raidActions);
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Pflegeschuss(uint cooldown)
        {
            var ability = GodsendTrigger();
            ability.Name = "Pflegeschuss";
            ability.Cooldown = (int)cooldown;
            ability.Effects.Add(new AbilityEffect
            {
                Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                ExtraData = new ApplyStatusEffect
                {
                    Id = GodsendTriggerId,
                    TurnDuration = 3,
                    IsUndispellable = true,
                    EffectTargettingType = EffectTargettingType.OnSelf,
                }.ToByteString(),
            });
            return ability;
        }

        private static Ability Feuerwerk(uint cooldown)
        {
            return new Ability
            {
                Name = "Feuerwerk",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/5f1f772e-6f69-497f-bd5c-a1a7a575fbad/abilities/1/ab_all_3040227000_02.js",
                    ConstructorName = "mc_ab_all_3040227000_02",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040227000_02",
                            Path = "npc/5f1f772e-6f69-497f-bd5c-a1a7a575fbad/abilities/1/ab_all_3040227000_02.png",
                        },
                    },
                },
                Effects =
                {
                },
                ProcessEffects = (jessica, targetPositionInFrontline, raidActions) =>
                {
                    jessica.Raid.Allies.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            IsUndispellable = true,
                            TurnDuration = 3,
                        },
                        raidActions,
                        ($"{FeuerwerkId}_atk_up", ModifierLibrary.FlatAttackBoost, 30),
                        ($"{FeuerwerkId}_def_up", ModifierLibrary.FlatDefenseBoost, 30),
                        ($"{FeuerwerkId}_da_up", ModifierLibrary.FlatDoubleAttackRateBoost, 30),
                        ($"{FeuerwerkId}_ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 30));

                    if (jessica.GetStatusEffectStacks(FireSupportId) > 0)
                    {
                        jessica.Raid.Allies.ApplyStatusEffects(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.DamageBoostedNpc,
                                Strength = 20_000,
                                TurnDuration = 3,
                            },
                            raidActions);
                    }
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Aussenseiter(uint cooldown)
        {
            return new Ability
            {
                Name = "Aussenseiter",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Support,
                AbilityTargetting = AbilityTargettingType.TargetSingleAliveFrontLineMember,
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/5f1f772e-6f69-497f-bd5c-a1a7a575fbad/abilities/2/ab_3030241000_03.js",
                    ConstructorName = "mc_ab_3030241000_03_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3030241000_03",
                            Path = "npc/5f1f772e-6f69-497f-bd5c-a1a7a575fbad/abilities/2/ab_3030241000_03.png",
                        },
                    },
                },
                CanCast = (jessica, targetPositionInFrontline) =>
                {
                    var target = jessica.Raid.Allies.AtPosition(targetPositionInFrontline);
                    if (!target.IsAlive())
                    {
                        return (false, string.Empty);
                    }

                    if (target.IsAlive() && target.Element != Element.Earth)
                    {
                        return (false, "Can only target an Earth ally");
                    }

                    return (true, string.Empty);
                },
                ProcessEffects = (jessica, targetPositionInFrontline, raidActions) =>
                {
                    var target = jessica.Raid.Allies.AtPosition(targetPositionInFrontline);
                    target.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = StatusEffectLibrary.Shield,
                            Strength = (long)Math.Min(target.MaxHp * 0.7, 4000),
                            TurnDuration = int.MaxValue,
                            IsUndispellable = true,
                        },
                        raidActions);
                    target.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = StatusEffectLibrary.AdditionalDamageNpc,
                            Strength = 30,
                            TurnDuration = int.MaxValue,
                            IsUndispellable = true,
                            TriggerCondition = new TriggerCondition
                            {
                                Type = TriggerCondition.Types.Type.HasStatusEffect,
                                Data = StatusEffectLibrary.Shield,
                                LinkToParentCondition = true,
                            },
                        },
                        raidActions);
                },
                AnimationName = "ab_motion",
            };
        }

        private static void TryProcessUnforgettableSummerHealingBoost(EntitySnapshot jessica)
        {
            if (jessica.Raid.Allies.Any(e => e.HpPercentage < 25))
            {
                jessica.ApplyStatusEffectsFromTemplate(
                    new StatusEffectSnapshot
                    {
                        IsUsedInternally = true,
                        IsPassiveEffect = true,
                    },
                    ("jessica/passive_healing_cap_up", ModifierLibrary.HealingCapBoost, 50),
                    ("jessica/passive_healing_up", ModifierLibrary.HealingBoost, 50));
            }
        }
    }
}