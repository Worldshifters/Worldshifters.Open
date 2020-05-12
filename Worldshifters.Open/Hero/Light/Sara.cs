// <copyright file="Sara.cs" company="Worldshifters">
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
    using static Worldshifters.Data.Hero.Ability.Types;

    public static class Sara
    {
        public static Guid Id = Guid.Parse("48b77e14-05d4-497f-ad1f-6673296cf486");

        private const string HammerOfGraphosId = "sara/graphos";
        private const string AfflatusId = "sara/afflatus";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Sara",
                Races = { Race.Human },
                Gender = Gender.Female,
                MaxAttack = 7600,
                MaxHp = 1840,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Light,
                WeaponProficiencies = { EquipmentType.Melee },
                AvailablePerkIds =
                {
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.DarkDamageReduction,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.SkillDamageCapBoost,
                    ExtendedMasteryPerks.DarkDamageReduction,
                    ExtendedMasteryPerks.HostilityBoost,
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
                        JsAssetPath = "npc/48b77e14-05d4-497f-ad1f-6673296cf486/model/0/npc_3040236000_02.js",
                        ConstructorName = "mc_npc_3040236000_02",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040236000_02",
                                Path = "npc/48b77e14-05d4-497f-ad1f-6673296cf486/model/0/npc_3040236000_02.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/48b77e14-05d4-497f-ad1f-6673296cf486/model/0/phit_3040236000.js",
                        ConstructorName = "mc_phit_3040236000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040236000",
                                Path = "npc/48b77e14-05d4-497f-ad1f-6673296cf486/model/0/phit_3040236000.png",
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
                            JsAssetPath = "npc/48b77e14-05d4-497f-ad1f-6673296cf486/model/0/nsp_3040236000_02_s2.js",
                            ConstructorName = "mc_nsp_3040236000_02_s2_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040236000_02_s2",
                                    Path = "npc/48b77e14-05d4-497f-ad1f-6673296cf486/model/0/nsp_3040236000_02_s2.png",
                                },
                            },
                        },
                    },
                    Effects =
                    {
                    },
                    ProcessEffects = (sara, raidActions) =>
                    {
                        if (sara.GetDebuffs().All(e => e.IsUsedInternally))
                        {
                            sara.Hero.GetAbilities()[1].Cast(sara, raidActions);
                        }
                        else
                        {
                            sara.ApplyStatusEffect(new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.RemoveAllDebuffs,
                            });
                        }
                    },
                },
                Abilities =
                {
                    Affectio(cooldown: 7),
                    Tonitrua(cooldown: 7),
                    Afflatus(cooldown: 6),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = Affectio(cooldown: 6),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = Tonitrua(cooldown: 6),
                        UpgradedAbilityIndex = 1,
                    },
                },
                OnActionStart = (sara, _, raidActions) => ProcessPassiveEffects(sara),
                OnTurnEnd = (sara, raidActions) =>
                {
                    foreach (var enemy in sara.Raid.Enemies)
                    {
                        if (enemy.NumSpecialAttacksUsedThisTurn >= 1)
                        {
                            sara.Hero.GetAbilities()[1].Cast(sara, raidActions);
                            break;
                        }
                    }
                },
                OnSetup = (sara, allies, loadout) =>
                {
                    sara.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = "passive",
                            Strength = -25,
                            Modifier = ModifierLibrary.ChargeBarSpedUp,
                            BaseAccuracy = double.MaxValue,
                            IsUsedInternally = true,
                            IsPassiveEffect = true,
                            TurnDuration = int.MaxValue,
                        });
                },
                OnEnteringFrontline = (sara, raidActions) => ProcessPassiveEffects(sara),
            };
        }

        private static Ability Affectio(uint cooldown)
        {
            return new Ability
            {
                Name = "Affectio",
                Type = AbilityType.Defensive,
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/48b77e14-05d4-497f-ad1f-6673296cf486/abilities/0/ab_all_3040236000_01.js",
                    ConstructorName = "mc_ab_all_3040236000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040236000_01",
                            Path = "npc/48b77e14-05d4-497f-ad1f-6673296cf486/abilities/0/ab_all_3040236000_01.png",
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
                            Id = StatusEffectLibrary.DarkDamageCutUpNpc,
                            Strength = 60,
                            TurnDuration = 1,
                            EffectTargettingType = EffectTargettingType.OnAllPartyMembers,
                        }.ToByteString(),
                    },
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Tonitrua(uint cooldown)
        {
            return new Ability
            {
                Name = "Tonitrua",
                Cooldown = (int)cooldown,
                Type = AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/48b77e14-05d4-497f-ad1f-6673296cf486/abilities/2/ab_all_3040236000_02.js",
                    ConstructorName = "mc_ab_all_3040236000_02",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040236000_02",
                            Path = "npc/48b77e14-05d4-497f-ad1f-6673296cf486/abilities/2/ab_all_3040236000_02.png",
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
                            HitNumber = 1,
                            Element = Element.Light,
                            DamageCap = 480_000,
                            DamageModifier = 4,
                            HitAllTargets = true,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (sara, targetPositionInFrontline, raidActions) =>
                {
                    var hammerOfGraphosStacks = sara.GetStatusEffectStacks(HammerOfGraphosId);
                    sara.ApplyOrOverrideStatusEffectStacks(HammerOfGraphosId, 1, 1, 5, raidActions, isUndispellable: true);

                    foreach (var ally in sara.Raid.Allies)
                    {
                        if (!ally.IsAlive() || ally.PositionInFrontline >= 4 || ally.PositionInFrontline == sara.PositionInFrontline)
                        {
                            continue;
                        }

                        ally.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.Shield,
                                TurnDuration = int.MaxValue,
                                Strength = hammerOfGraphosStacks == 5 ? 2000 : 1000,
                            },
                            raidActions);
                    }
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Afflatus(uint cooldown)
        {
            return new Ability
            {
                Name = "Afflatus",
                Cooldown = (int)cooldown,
                Type = AbilityType.Defensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/48b77e14-05d4-497f-ad1f-6673296cf486/abilities/1/ab_3040236000_01.js",
                    ConstructorName = "mc_ab_3040236000_01_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040236000_01",
                            Path = "npc/48b77e14-05d4-497f-ad1f-6673296cf486/abilities/1/ab_3040236000_01.png",
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
                            EffectTargettingType = EffectTargettingType.OnSelf,
                            TurnDuration = 1,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (sara, targetPositionInFrontline, raidActions) =>
                {
                    var hammerOfGraphosStacks = sara.GetStatusEffectStacks(HammerOfGraphosId);
                    if (hammerOfGraphosStacks >= 3)
                    {
                        sara.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = AfflatusId,
                                TurnDuration = 1,
                                IsUndispellable = true,
                            },
                            raidActions);

                        sara.ApplyStatusEffect(new StatusEffectSnapshot
                        {
                            Id = StatusEffectLibrary.AssassinStrike,
                            TurnDuration = 1,
                            IsUndispellable = true,
                            IsUsedInternally = true,
                            Strength = 50,
                            ExtraData = new AssassinStrike
                            {
                                ChargeAttackDamageBoost = 50,
                                DamageCap = 1_116_000,
                                ActivationCondition = AssassinStrike.Types.ActivationCondition.None,
                                ChargeAttackDamageCap = 2_180_000,
                            }.ToByteString(),
                        });
                    }
                },
                AnimationName = "ab_motion",
                ShouldRepositionSpriteAnimation = true,
            };
        }

        private static void ProcessPassiveEffects(EntitySnapshot sara)
        {
            sara.ApplyStatusEffect(
                new StatusEffectSnapshot
                {
                    Id = "passive_counter",
                    Strength = 2,
                    Modifier = ModifierLibrary.DodgeAndCounter,
                    IsUsedInternally = true,
                    IsPassiveEffect = true,
                    TurnDuration = 1,
                    ExtraData = new Counter
                    {
                        HitCount = 2,
                        DamageModifier = 1,
                    }.ToByteString(),
                });

            var hammerOfGraphosStacks = sara.GetStatusEffectStacks(HammerOfGraphosId);
            sara.ApplyStatusEffectsFromTemplate(
                new StatusEffectSnapshot
                {
                    TurnDuration = 1,
                    IsUsedInternally = true,
                    IsUndispellable = true,
                },
                (HammerOfGraphosId + "/def_up", ModifierLibrary.FlatDefenseBoost, hammerOfGraphosStacks * 20),
                (HammerOfGraphosId + "/dr_up", ModifierLibrary.FlatDebuffResistanceBoost, hammerOfGraphosStacks * 20),
                (HammerOfGraphosId + "/hostility_up", ModifierLibrary.HostilityBoost, hammerOfGraphosStacks * 9.94));
        }
    }
}