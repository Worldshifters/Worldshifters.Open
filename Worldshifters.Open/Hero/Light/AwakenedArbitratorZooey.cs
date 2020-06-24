// <copyright file="AwakenedArbitratorZooey.cs" company="Worldshifters">
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
    using Worldshifters.Data.Utils;

    public static class AwakenedArbitratorZooey
    {
        public static Guid Id = Guid.Parse("b82fd33f-9222-425d-b5de-eb5d72f802c5");

        private const string EffectOnDodge = "zooey/on_dodge";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Zooey",
                Races = { Race.Primal },
                Gender = Gender.Female,
                MaxAttack = 8700,
                MaxHp = 1460,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Light,
                Description = "The world is in the midst of impending jeopardy—a disaster that only this arbitrator's true form can stop. But will her excessive empathy for the people interfere with her duty?",
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
                    ExtendedMasteryPerks.LightAttackBoost,
                    ExtendedMasteryPerks.ChargeAttackDamageBoost,
                    ExtendedMasteryPerks.SkillDamageBoost,
                    ExtendedMasteryPerks.SkillDamageCapBoost,
                    ExtendedMasteryPerks.DodgeRateBoost,
                    ExtendedMasteryPerks.HostilityBoost,
                    ExtendedMasteryPerks.SupportSkill,
                },
                PassiveAbilities =
                {
                    new PassiveAbility
                    {
                        Type = PassiveAbility.Types.PassiveAbilityType.SupportSkill,
                        Name = "Peacemaker's Tears",
                        Description = "1-turn cut to skill standby and cooldown for Last Wish upon being targeted by an ally's buff skill or healing skill",
                    },
                    new PassiveAbility
                    {
                        Type = PassiveAbility.Types.PassiveAbilityType.SupportSkill,
                        Name = "Primal Pulse",
                        Description = "Boost to critical hit rate and dodge rate based on number of turns passed",
                    },
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/b82fd33f-9222-425d-b5de-eb5d72f802c5/model/0/npc_3040150000_02.js",
                        ConstructorName = "mc_npc_3040150000_02",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040150000_02_a",
                                Path = "npc/b82fd33f-9222-425d-b5de-eb5d72f802c5/model/0/npc_3040150000_02_a.png",
                            },
                            new ImageAsset
                            {
                                Name = "npc_3040150000_02_b",
                                Path = "npc/b82fd33f-9222-425d-b5de-eb5d72f802c5/model/0/npc_3040150000_02_b.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/b82fd33f-9222-425d-b5de-eb5d72f802c5/model/0/phit_3040150000.js",
                        ConstructorName = "mc_phit_3040150000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040150000",
                                Path = "npc/b82fd33f-9222-425d-b5de-eb5d72f802c5/model/0/phit_3040150000.png",
                            },
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    HitCount = { 10 },
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "npc/b82fd33f-9222-425d-b5de-eb5d72f802c5/model/0/nsp_3040150000_02_s2.js",
                            ConstructorName = "mc_nsp_3040150000_02_s2_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040150000_02_s2",
                                    Path = "npc/b82fd33f-9222-425d-b5de-eb5d72f802c5/model/0/nsp_3040150000_02_s2.png",
                                },
                            },
                        },
                    },
                    ProcessEffects = (zooey, raidActions) =>
                    {
                        zooey.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.Shield,
                                Strength = 2000,
                                TurnDuration = int.MaxValue,
                            },
                            raidActions);
                    },
                },
                Abilities =
                {
                    Convergence(cooldown: 6),
                    RayStrike(cooldown: 7),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 45,
                        Ability = TheLastWish(),
                        UpgradedAbilityIndex = 2,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = Convergence(cooldown: 5),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = RayStrike(cooldown: 6),
                        UpgradedAbilityIndex = 1,
                    },
                },
                OnActionStart = (zooey, _, raidActions) => ProcessPassiveEffects(zooey),
                OnEnteringFrontline = (zooey, raidActions) => ProcessPassiveEffects(zooey),
                OnOtherAllyAbilityEnd = (zooey, caster, ability, raidActions) =>
                {
                    if (zooey.WasTargettedByStatusEffect && zooey.AbilityCooldowns.Count == 3 && (ability.Type == Ability.Types.AbilityType.Healing || ability.Type == Ability.Types.AbilityType.Support))
                    {
                        zooey.AbilityCooldowns[2] = Math.Max(zooey.AbilityCooldowns[2] - 1, 0);
                    }
                },
                OnTurnEnd = (zooey, raidActions) =>
                {
                    if (zooey.DodgedDamageOrDebuff && zooey.GetStatusEffect(EffectOnDodge) != null)
                    {
                        RayStrikeBonusEffect().Cast(zooey, zooey.CurrentTargetPositionInFrontline, raidActions);
                    }
                },
            };
        }

        private static Ability Convergence(uint cooldown)
        {
            return new Ability
            {
                Name = "Convergence",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/b82fd33f-9222-425d-b5de-eb5d72f802c5/abilities/0/ab_all_3040150000_01.js",
                    ConstructorName = "mc_ab_all_3040150000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040150000_01",
                            Path = "npc/b82fd33f-9222-425d-b5de-eb5d72f802c5/abilities/0/ab_all_3040150000_01.png",
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
                            Element = Element.Light,
                            HitNumber = 2,
                            DamageCap = 110_000,
                            DamageModifier = 1,
                            RandomTargets = true,
                        }.ToByteString(),
                    },
                    ApplyStatusEffect.FromTemplate(
                        new ApplyStatusEffect
                        {
                            EffectTargettingType = EffectTargettingType.OnSelf,
                            TurnDuration = 3,
                        },
                        (StatusEffectLibrary.DoubleAttackRateUpNpc, 100),
                        (StatusEffectLibrary.TripleAttackRateUpNpc, 25)),
                    ApplyStatusEffect.FromTemplate(
                        new ApplyStatusEffect
                        {
                            EffectTargettingType = EffectTargettingType.OnSelf,
                            TurnDuration = 3,
                            BaseAccuracy = double.MaxValue,
                        },
                        (StatusEffectLibrary.HostilityUp, 50)),
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability RayStrike(uint cooldown)
        {
            return new Ability
            {
                Name = "Ray Strike",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/b82fd33f-9222-425d-b5de-eb5d72f802c5/abilities/1/ab_3040150000_01.js",
                    ConstructorName = "mc_ab_3040150000_01_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040150000_01",
                            Path = "npc/b82fd33f-9222-425d-b5de-eb5d72f802c5/abilities/1/ab_3040150000_01.png",
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
                            Id = StatusEffectLibrary.DodgeRateBoostNpc,
                            Strength = 40,
                            TurnDuration = 3,
                            EffectTargettingType = EffectTargettingType.OnSelf,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = EffectOnDodge,
                            TurnDuration = 3,
                            EffectTargettingType = EffectTargettingType.OnSelf,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (zooey, targetPosition, raidActions) =>
                {
                    new MultihitDamage
                    {
                        Element = Element.Light,
                        HitNumber = 1,
                        DamageCap = 630000,
                        DamageModifier = 4 + ThreadSafeRandom.NextDouble(),
                    }.ProcessEffects(zooey, targetPosition, raidActions);
                },
                AnimationName = "ab_motion",
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
            };
        }

        private static Ability TheLastWish()
        {
            return new Ability
            {
                Name = "The Last Wish",
                InitialCooldown = 5,
                Cooldown = 12,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/b82fd33f-9222-425d-b5de-eb5d72f802c5/abilities/3/ab_3040150000_03.js",
                    ConstructorName = "mc_ab_3040150000_03_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040150000_03",
                            Path = "npc/b82fd33f-9222-425d-b5de-eb5d72f802c5/abilities/3/ab_3040150000_03.png",
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
                            Element = Element.Light,
                            HitNumber = 1,
                            DamageModifier = 10,
                            DamageCap = 1_600_000,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (zooey, target, raidActions) =>
                {
                    zooey.Raid.Allies.ApplyStatusEffects(
                        new StatusEffectSnapshot
                        {
                            Id = "zooey/sign_of_zooey",
                            TurnDuration = 5,
                            IsUndispellable = true,
                        },
                        raidActions);

                    zooey.Raid.Allies.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            IsUsedInternally = true,
                            TurnDuration = 5,
                            IsUndispellable = true,
                        },
                        ("zooey/last_wish/atk_up", ModifierLibrary.FlatAttackBoost, 100),
                        ("zooey/last_wish/def_up", ModifierLibrary.FlatDefenseBoost, 100));

                    zooey.Raid.Allies.ApplyStatusEffects(
                        new StatusEffectSnapshot
                        {
                            Id = "zooey/last_wish/drain",
                            Strength = 5,
                            Modifier = ModifierLibrary.Drain,
                            TurnDuration = 5,
                            IsUsedInternally = true,
                            IsUndispellable = true,
                            ExtraData = new Drain
                            {
                                IsPercentageBased = true,
                                HealingCap = 1000,
                                HealingCapPercentage = long.MaxValue,
                            }.ToByteString(),
                        });
                },
                AnimationName = "ab_motion",
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
            };
        }

        private static Ability RayStrikeBonusEffect()
        {
            return new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/b82fd33f-9222-425d-b5de-eb5d72f802c5/abilities/2/ab_3040150000_02.js",
                    ConstructorName = "mc_ab_3040150000_02_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040150000_02",
                            Path = "npc/b82fd33f-9222-425d-b5de-eb5d72f802c5/abilities/2/ab_3040150000_02.png",
                        },
                    },
                },
                ProcessEffects = (zooey, targetPosition, raidActions) =>
                {
                    new MultihitDamage
                    {
                        Element = Element.Light,
                        HitNumber = 1,
                        DamageModifier = 3 + ThreadSafeRandom.NextDouble(),
                        DamageCap = 630000,
                    }.ProcessEffects(zooey, targetPosition, raidActions);
                },
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
                AnimationName = "ab_motion",
            };
        }

        private static void ProcessPassiveEffects(EntitySnapshot zooey)
        {
            if (!zooey.IsAlive() || zooey.PositionInFrontline >= 4)
            {
                return;
            }

            if (ThreadSafeRandom.NextDouble() < Math.Min(0.1, 0.1 * zooey.Raid.Turn * 0.1))
            {
                zooey.ApplyStatusEffect(new StatusEffectSnapshot
                {
                    Id = StatusEffectLibrary.Dodge,
                    Strength = 1,
                });
            }

            zooey.ApplyStatusEffect(
                new StatusEffectSnapshot
                {
                    Id = "zooey/crit_rate",
                    IsPassiveEffect = true,
                    IsUsedInternally = true,
                    Modifier = ModifierLibrary.FlatCriticalHitRateBoost,
                    Strength = Math.Min(50, 5 * zooey.Raid.Turn),
                    ExtraData = new CriticalHit
                    {
                        DamageMultiplier = 0.3,
                    }.ToByteString(),
                });

            var supportSkillRank = zooey.Hero.GetSupportSkillRank();
            if (supportSkillRank > 0 && zooey.GetStatusEffects(ModifierLibrary.DodgeRateBoost).Any())
            {
                zooey.ApplyStatusEffect(
                    new StatusEffectSnapshot
                    {
                        Id = "zooey/passive",
                        Strength = supportSkillRank * 10,
                        IsPassiveEffect = true,
                        IsUsedInternally = true,
                        Modifier = ModifierLibrary.DodgeRateBoost,
                    });
            }
        }
    }
}