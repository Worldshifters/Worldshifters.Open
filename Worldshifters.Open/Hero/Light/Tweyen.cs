// <copyright file="Tweyen.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Light
{
    using System;
    using System.Linq;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Hero.Abilities;
    using Worldshifters.Data.Raid;

    public static class Tweyen
    {
        public static Guid Id = Guid.Parse("ea84d795-d699-4825-833c-82a8713bff52");

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Tweyen",
                Race = Race.Unknow,
                Gender = Gender.Female,
                MaxAttack = 11222,
                AttackLevels = { 9522 },
                MaxHp = 2222,
                HpLevels = { 1822 },
                MaxLevel = 100,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Light,
                WeaponProficiencies = { EquipmentType.Bow },
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
                        JsAssetPath = "npc/ea84d795-d699-4825-833c-82a8713bff52/model/0/npc_3710072000_01.js",
                        ConstructorName = "mc_npc_3710072000_01",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3710072000_01_a",
                                Path = "npc/ea84d795-d699-4825-833c-82a8713bff52/model/0/npc_3710072000_01_a.png",
                            },
                            new ImageAsset
                            {
                                Name = "npc_3710072000_01_b",
                                Path = "npc/ea84d795-d699-4825-833c-82a8713bff52/model/0/npc_3710072000_01_b.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/ea84d795-d699-4825-833c-82a8713bff52/model/0/phit_3040031000.js",
                        ConstructorName = "mc_phit_3040031000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040031000",
                                Path = "npc/ea84d795-d699-4825-833c-82a8713bff52/model/0/phit_3040031000.png",
                            },
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = string.Empty,
                    HitCount = { 33 },
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "npc/ea84d795-d699-4825-833c-82a8713bff52/model/0/nsp_3710072000_01.js",
                            ConstructorName = "mc_nsp_3710072000_01_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3710072000_01",
                                    Path = "npc/ea84d795-d699-4825-833c-82a8713bff52/model/0/nsp_3710072000_01.png",
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
                    ProcessEffects = (tweyen, raidActions) =>
                    {
                        if (tweyen.Hero.Rank >= 5)
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
                            }).Cast(tweyen, tweyen.Raid.SelectedTarget, raidActions);
                        }
                    },
                },
                Abilities =
                {
                    Merculight(cooldown: 6),
                    Depravity(cooldown: 2),
                    Clincher(cooldown: 6),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = Merculight(cooldown: 5),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = Depravity(cooldown: 1),
                        UpgradedAbilityIndex = 1,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = Clincher(cooldown: 5),
                        UpgradedAbilityIndex = 2,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 100,
                        Ability = new Ability
                        {
                            Name = "Two-Crown's Strife",
                            Type = Ability.Types.AbilityType.Support,
                            Cooldown = int.MaxValue,
                            InitialCooldown = 10,
                            ModelMetadata = new ModelMetadata
                            {
                                JsAssetPath = "npc/ea84d795-d699-4825-833c-82a8713bff52/abilities/3/ab_all_3040031000_01.js",
                                ConstructorName = "mc_ab_all_3040031000_01",
                                ImageAssets =
                                {
                                    new ImageAsset
                                    {
                                        Name = "ab_all_3040031000_01_a",
                                        Path = "npc/ea84d795-d699-4825-833c-82a8713bff52/abilities/3/ab_all_3040031000_01_a.png",
                                    },
                                    new ImageAsset
                                    {
                                        Name = "ab_all_3040031000_01_b",
                                        Path = "npc/ea84d795-d699-4825-833c-82a8713bff52/abilities/3/ab_all_3040031000_01_b.png",
                                    },
                                },
                            },
                            ProcessEffects = (tweyen, targetIndex, raidActions) =>
                            {
                                var numDebuffsOnFoes = tweyen.Raid.Enemies
                                    .Where(e => e.IsAlive() && e.PositionInFrontline < 4)
                                    .Sum(e => e.GetStatusEffects().Count(d => !d.IsBuff));

                                var damageEffect = new MultihitDamage
                                {
                                    Element = Element.Light,
                                    HitAllTargets = true,
                                    HitNumber = Math.Max(Math.Min(10, numDebuffsOnFoes), 3),
                                    DamageModifier = 3,
                                    DamageCap = 200_000,
                                };

                                foreach (var enemy in tweyen.Raid.Enemies)
                                {
                                    if (enemy.IsAlive() && enemy.PositionInFrontline < 4)
                                    {
                                        damageEffect.ApplyEffect(tweyen, enemy.PositionInFrontline, raidActions);
                                    }
                                }
                            },
                            AnimationName = "attack",
                        },
                        UpgradedAbilityIndex = 3,
                    },
                },
                OnActionStart = (tweyen, raidActions) => ProcessPassiveEffects(tweyen),
                OnTurnEnd = (tweyen, raidActions) =>
                {
                    if (!tweyen.IsAlive())
                    {
                        return;
                    }
                },
                OnSetup = (tweyen, allies, loadout) =>
                {
                    tweyen.ApplyStatusEffect(new StatusEffectSnapshot
                    {
                        Id = "tweyen/dark_huntress_aoe_attacks",
                        IsBuff = true,
                        Modifier = ModifierLibrary.NormalAttacksHitAllFoes,
                        IsPassiveEffect = true,
                        IsUsedInternally = true,
                        TurnDuration = int.MaxValue,
                    });
                },
                OnAttackEnd = (tweyen, attackResult, raidActions) => ProcessPassiveEffects(tweyen),
                OnEnteringFrontline = (tweyen, raidActions) => ProcessPassiveEffects(tweyen),
            };
        }

        private static Ability Merculight(uint cooldown)
        {
            return new Ability
            {
                Name = "Merculight",
                Cooldown = (int)cooldown,
                Effects =
                {
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = StatusEffectLibrary.Dodge,
                            IsBuff = true,
                            TurnDuration = 1,
                            OnSelf = true,
                        }.ToByteString(),
                    },
                },
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/ea84d795-d699-4825-833c-82a8713bff52/abilities/0/ab_180.js",
                    ConstructorName = "mc_ab_180_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_180",
                            Path = "npc/ea84d795-d699-4825-833c-82a8713bff52/abilities/0/ab_180.png",
                        },
                    },
                },
                ProcessEffects = (tweyen, targetIndex, raidActions) =>
                {
                    if (tweyen.Hero.Level >= 85)
                    {
                        tweyen.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.SkillDamageCapUpNpc,
                                IsBuff = true,
                                TurnDuration = 3,
                                Strength = 30,
                            }, raidActions);
                    }

                    if (tweyen.Hero.Level >= 55)
                    {
                        tweyen.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = "tweyen/merculight_atk_up",
                                IsBuff = true,
                                TurnDuration = 3,
                                Strength = 50,
                                Modifier = ModifierLibrary.FlatAttackBoost,
                            }, raidActions);
                    }
                    else
                    {
                        tweyen.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = "tweyen/merculight_atk_up",
                                IsBuff = true,
                                TurnDuration = 3,
                                Strength = 33,
                                Modifier = ModifierLibrary.FlatAttackBoost,
                            }, raidActions);
                    }
                },
                ShouldRepositionSpriteAnimation = true,
                AnimationName = "attack",
            };
        }

        private static Ability Depravity(uint cooldown)
        {
            return new Ability
            {
                Name = "Depravity",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/ea84d795-d699-4825-833c-82a8713bff52/abilities/1/ab_all_3040031000_02.js",
                    ConstructorName = "mc_ab_all_3040031000_02",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040031000_02",
                            Path = "npc/ea84d795-d699-4825-833c-82a8713bff52/abilities/1/ab_all_3040031000_02.png",
                        },
                    },
                },
                ProcessEffects = (tweyen, targetIndex, raidActions) =>
                {
                    if (tweyen.Hero.Level < 95)
                    {
                        return;
                    }
                },
                AnimationName = "attack",
            };
        }

        private static Ability Clincher(uint cooldown)
        {
            return new Ability
            {
                Name = "Clincher",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/ea84d795-d699-4825-833c-82a8713bff52/abilities/2/ab_3040031000_01.js",
                    ConstructorName = "mc_ab_3040031000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040031000_01",
                            Path = "npc/ea84d795-d699-4825-833c-82a8713bff52/abilities/2/ab_3040031000_01.png",
                        },
                    },
                },
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
                ProcessEffects = (tweyen, targetIndex, raidActions) =>
                {
                    if (tweyen.Hero.Level < 95)
                    {
                        return;
                    }
                },
                AnimationName = "attack",
            };
        }

        private static void ProcessPassiveEffects(EntitySnapshot tweyen)
        {
            if (!tweyen.IsAlive() || tweyen.PositionInFrontline >= 4)
            {
                return;
            }

            if (tweyen.Hero.Level >= 95)
            {
                tweyen.ApplyStatusEffect(new StatusEffectSnapshot
                {
                    Id = "tweyen/lone_archer",
                    Strength = 5 * (4 - tweyen.Raid.Enemies.Count(e => e.PositionInFrontline < 4 && e.IsAlive())),
                    IsBuff = true,
                    Modifier = ModifierLibrary.FlatDebuffSuccessRateBoost,
                    IsPassiveEffect = true,
                    IsUsedInternally = true,
                });
            }

            if (tweyen.Hero.Level >= 90)
            {
                tweyen.ApplyStatusEffect(new StatusEffectSnapshot
                {
                    Id = "tweyen/dark_huntress",
                    Strength = 5 * (4 - tweyen.Raid.Enemies.Count(e => e.PositionInFrontline < 4 && e.IsAlive())),
                    IsBuff = true,
                    Modifier = ModifierLibrary.FlatAttackBoost,
                    IsPassiveEffect = true,
                    IsUsedInternally = true,
                });
            }
        }
    }
}