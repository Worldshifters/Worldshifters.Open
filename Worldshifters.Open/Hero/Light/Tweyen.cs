// <copyright file="Tweyen.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Light
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class Tweyen
    {
        public static Guid Id = Guid.Parse("ea84d795-d699-4825-833c-82a8713bff52");

        private const string BringTheThunderId = "tweyen/bring_the_thunder";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Tweyen",
                Races = { Race.Human },
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
                                Id = BringTheThunderId,
                                EffectTargettingType = EffectTargettingType.OnSelf,
                                IsUndispellable = true,
                                TurnDuration = 3,
                            }.ToByteString(),
                        },
                    },
                    ProcessEffects = (tweyen, raidActions) =>
                    {
                        if (tweyen.Hero.Rank >= 5)
                        {
                            foreach (var ally in tweyen.Raid.Allies)
                            {
                                if (!ally.IsAlive() || ally.PositionInFrontline >= 4)
                                {
                                    continue;
                                }

                                ally.ApplyStatusEffect(new StatusEffectSnapshot
                                {
                                    Id = StatusEffectLibrary.CriticalHitRateBoostNpc,
                                    Strength = 100,
                                    TurnDuration = 4,
                                    ExtraData = new CriticalHit
                                    {
                                        DamageMultiplier = 0.5,
                                    }.ToByteString(),
                                });
                            }
                        }
                    },
                    ShouldRepositionSpriteAnimationOnTarget = true,
                },
                Abilities =
                {
                    Merculight(cooldown: 6),
                    Depravity(cooldown: 8),
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
                        Ability = Depravity(cooldown: 7),
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
                            ProcessEffects = (tweyen, targetPositionInFrontline, raidActions) =>
                            {
                                var numDebuffsOnFoes = tweyen.Raid.Enemies
                                    .Where(e => e.IsAlive() && e.PositionInFrontline < 4)
                                    .Sum(e => e.GetDebuffs().Count());

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
                                        foreach (var debuff in enemy.GetDebuffs())
                                        {
                                            if (debuff.RemainingDurationInSeconds > 0)
                                            {
                                                debuff.RemainingDurationInSeconds += 90;
                                            }
                                        }

                                        damageEffect.ProcessEffects(tweyen, enemy.PositionInFrontline, raidActions);
                                    }
                                }
                            },
                            AnimationName = "attack",
                        },
                        UpgradedAbilityIndex = 3,
                    },
                },
                OnActionStart = (tweyen, _, raidActions) => ProcessPassiveEffects(tweyen),
                OnTurnEnd = (tweyen, raidActions) =>
                {
                    if (!tweyen.IsAlive())
                    {
                        return;
                    }

                    var supportSkillRank = tweyen.Hero.GetSupportSkillRank();
                    if (supportSkillRank > 0 && tweyen.DodgedDamageOrDebuff)
                    {
                        var lightDamageOnAllEnemies = LightDamageOnAllEnemies();
                        lightDamageOnAllEnemies.Effects.Add(new AbilityEffect
                        {
                            Type = AbilityEffect.Types.AbilityEffectType.MultihitDamage,
                            ExtraData = new MultihitDamage
                            {
                                DamageModifier = (1 + supportSkillRank) * 0.5,
                                DamageCap = supportSkillRank == 1 ? 74_000 : (supportSkillRank == 2 ? 220_000 : 270_000),
                                Element = Element.Light,
                                HitAllTargets = true,
                                HitNumber = 1,
                            }.ToByteString(),
                        });
                        lightDamageOnAllEnemies.Cast(tweyen, raidActions);
                    }
                },
                OnSetup = (tweyen, allies, loadout) =>
                {
                    tweyen.ApplyStatusEffect(new StatusEffectSnapshot
                    {
                        Id = "tweyen/dark_huntress_aoe_attacks",
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

        private static Ability LightDamageOnAllEnemies()
        {
            return new Ability
            {
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
            };
        }

        private static Ability Merculight(uint cooldown)
        {
            return new Ability
            {
                Name = "Merculight",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Support,
                Effects =
                {
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = StatusEffectLibrary.Dodge,
                            Strength = 1,
                            TurnDuration = 1,
                            EffectTargettingType = EffectTargettingType.OnSelf,
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
                ProcessEffects = (tweyen, targetPositionInFrontline, raidActions) =>
                {
                    if (tweyen.Hero.Level >= 85)
                    {
                        tweyen.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.SkillDamageCapUpNpc,
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
                ProcessEffects = (tweyen, targetPositionInFrontline, raidActions) =>
                {
                    foreach (var enemy in tweyen.Raid.Enemies)
                    {
                        if (!enemy.IsAlive() || enemy.PositionInFrontline >= 4)
                        {
                            continue;
                        }

                        enemy.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.DebuffResistanceDownNpc,
                                BaseAccuracy = 100,
                                RemainingDurationInSeconds = 180,
                                Strength = -10,
                            }, raidActions);

                        enemy.ApplyStatusEffectsFromTemplate(
                            new StatusEffectSnapshot
                            {
                                BaseAccuracy = 65,
                                RemainingDurationInSeconds = 180,
                                ExtraData = new Burn
                                {
                                    DamageCap = 2222,
                                }.ToByteString(),
                            },
                            raidActions,
                            (StatusEffectLibrary.BurntNpc, ModifierLibrary.Burnt, 2222),
                            (StatusEffectLibrary.PoisonedNpc, ModifierLibrary.Burnt, 2222),
                            (StatusEffectLibrary.PutrefiedNpc, ModifierLibrary.Burnt, 2222));

                        enemy.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.Blind,
                                BaseAccuracy = 50,
                                RemainingDurationInSeconds = 180,
                                Strength = 15,
                            }, raidActions);

                        enemy.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.Charmed,
                                BaseAccuracy = 30,
                                RemainingDurationInSeconds = 180,
                                Strength = 20,
                            }, raidActions);

                        enemy.ApplyStatusEffectsFromTemplate(
                            new StatusEffectSnapshot
                            {
                                BaseAccuracy = 65,
                                RemainingDurationInSeconds = 180,
                            },
                            raidActions,
                            (StatusEffectLibrary.AttackDownNpc, ModifierLibrary.FlatAttackBoost, -15),
                            (StatusEffectLibrary.DefenseDownNpc, ModifierLibrary.FlatDefenseBoost, -15),
                            (StatusEffectLibrary.DoubleAttackRateDownNpc, ModifierLibrary.FlatDoubleAttackRateBoost, -15),
                            (StatusEffectLibrary.TripleAttackRateDownNpc, ModifierLibrary.FlatTripleAttackRateBoost, -15));

                        enemy.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.ParalyzedLocal3,
                                BaseAccuracy = 20,
                                TurnDuration = 3,
                                IsLocal = true,
                            }, raidActions);

                        enemy.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.AsleepLocal3,
                                BaseAccuracy = 20,
                                TurnDuration = 3,
                                IsLocal = true,
                                ExtraData = new Asleep
                                {
                                    WakeUpOnTakingDamage = true,
                                    DamageTakenAmplification = 25,
                                }.ToByteString(),
                            }, raidActions);
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
                    ConstructorName = "mc_ab_3040031000_01_effect",
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
                ProcessEffects = (tweyen, targetPositionInFrontline, raidActions) =>
                {
                    var damage = new MultihitDamage
                    {
                        Element = Element.Light,
                        HitNumber = 1,
                    };

                    if (tweyen.Hero.Level < 95)
                    {
                        var target = tweyen.Raid.Enemies.AtPosition(targetPositionInFrontline);
                        damage.DamageModifier = 1.5 + (target.GetDebuffs().Count() * 0.5);
                        damage.DamageCap = 900_000;
                        damage.ProcessEffects(tweyen, tweyen.Raid.SelectedTarget, raidActions);

                        if (tweyen.GetStatusEffects().Any(e => e.Id == BringTheThunderId))
                        {
                            TryParalyze(target, raidActions);
                        }

                        return;
                    }

                    damage.DamageCap = 1_200_000;
                    damage.HitAllTargets = true;
                    damage.DamageModifier = 1.5 + tweyen.Raid.Enemies
                                                .Where(e => e.IsAlive() && e.PositionInFrontline < 4)
                                                .Sum(e => e.GetDebuffs().Count() * 0.5);
                    damage.ProcessEffects(tweyen, tweyen.Raid.SelectedTarget, raidActions);

                    if (tweyen.GetStatusEffects().All(e => e.Id != BringTheThunderId))
                    {
                        return;
                    }

                    foreach (var enemy in tweyen.Raid.Enemies)
                    {
                        if (!enemy.IsAlive() || enemy.PositionInFrontline >= 4)
                        {
                            continue;
                        }

                        TryParalyze(enemy, raidActions);
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
                    Modifier = ModifierLibrary.FlatAttackBoost,
                    IsPassiveEffect = true,
                    IsUsedInternally = true,
                });
            }
        }

        private static void TryParalyze(EntitySnapshot target, IList<RaidAction> raidActions)
        {
            target.ApplyStatusEffect(
                new StatusEffectSnapshot
                {
                    Id = StatusEffectLibrary.Paralyzed,
                    BaseAccuracy = 55,
                    RemainingDurationInSeconds = 60,
                }, raidActions);
        }
    }
}