// <copyright file="Zooey.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Dark
{
    using System;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class Zooey
    {
        public static Guid Id = Guid.Parse("24121da9-e1c5-4aeb-8608-b6128c419cd1");

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Zooey",
                Race = Race.Primal,
                Gender = Gender.Female,
                MaxAttack = 9200,
                MaxHp = 1180,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Dark,
                WeaponProficiencies = { EquipmentType.Sword },
                AvailablePerkIds =
                {
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.DebuffResistanceBoost,
                    ExtendedMasteryPerks.AttackBoostAgainstFoesInOverdriveMode,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.DarkAttackBoost,
                    ExtendedMasteryPerks.ChargeAttackDamageBoost,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.SkillDamageBoost,
                    ExtendedMasteryPerks.SkillDamageBoost,
                    ExtendedMasteryPerks.SkillDamageCapBoost,
                    ExtendedMasteryPerks.SupportSkill,
                },
                Abilities =
                {
                    Resolution(cooldown: 9, damageModifier: 6, damageElement: Element.Dark),
                    Conjunction(cooldown: 16),
                    Thunder(damageElement: Element.Dark),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        Ability = Resolution(cooldown: 8, damageModifier: 9, damageElement: Element.Dark),
                        RequiredLevel = 55,
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        Ability = Conjunction(cooldown: 14),
                        RequiredLevel = 75,
                        UpgradedAbilityIndex = 1,
                    },
                },
                PassiveAbilities =
                {
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = "Gamma Ray",
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            ConstructorName = "mc_nsp_3040092000_02_special",
                            JsAssetPath = "npc/60d4c46a-f1bd-4d11-b39b-e18835d5e21d/model/1/nsp_3040092000_02.js",
                        },
                    },
                    HitCount = { 6 },
                    FrameToSkipToOnAnimationSkip = { 125 },
                    ConstructorNameOnAnimationSkip = { "mc_npc_3040092000_02_mortal_A" },
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        ConstructorName = "mc_npc_3040092000_02",
                        JsAssetPath = "npc/60d4c46a-f1bd-4d11-b39b-e18835d5e21d/model/1/npc_3040092000_02.js",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040092000_02_a",
                                Path = "npc/60d4c46a-f1bd-4d11-b39b-e18835d5e21d/model/1/npc_3040092000_02_a.png",
                            },
                            new ImageAsset
                            {
                                Name = "npc_3040092000_02_b",
                                Path = "npc/60d4c46a-f1bd-4d11-b39b-e18835d5e21d/model/1/npc_3040092000_02_b.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        ConstructorName = "mc_phit_3040092000_effect",
                        JsAssetPath = "npc/60d4c46a-f1bd-4d11-b39b-e18835d5e21d/model/1/phit_3040092000.js",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040092000",
                                Path = "npc/60d4c46a-f1bd-4d11-b39b-e18835d5e21d/model/1/phit_3040092000.png",
                            },
                        },
                    },
                },
            };
        }

        public static Ability Resolution(uint cooldown, double damageModifier, Element damageElement)
        {
            return new Ability
            {
                Name = "Resolution",
                Description = string.Empty,
                Cooldown = (int)cooldown,
                AnimationName = "ab_motion",
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    ConstructorName = "mc_ab_3040092000_01_effect",
                    JsAssetPath = "npc/60d4c46a-f1bd-4d11-b39b-e18835d5e21d/abilities/0/ab_3040092000_01.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040092000_01",
                            Path = "npc/60d4c46a-f1bd-4d11-b39b-e18835d5e21d/abilities/0/ab_3040092000_01.png",
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
                            Element = damageElement,
                            DamageCap = 690000,
                            DamageModifier = damageModifier,
                            HitNumber = 1,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Strength = 53.3,
                            Id = StatusEffectLibrary.JammedNpc,
                            IsBuff = true,
                            TurnDuration = 3,
                            OnSelf = true,
                            ExtraData = new LinearAttackBoost
                            {
                                StrengthAt1Hp = 80,
                                StrengthAtFullHp = 26.6,
                            }.ToByteString(),
                        }.ToByteString(),
                    },
                },
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
            };
        }

        public static Ability Thunder(Element damageElement)
        {
            return new Ability
            {
                Name = "Thunder",
                Description = string.Empty,
                Cooldown = 6,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    ConstructorName = "mc_ab_all_3040078000_03",
                    JsAssetPath = "npc/60d4c46a-f1bd-4d11-b39b-e18835d5e21d/abilities/2/ab_all_3040078000_03.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040078000_03",
                            Path = "npc/60d4c46a-f1bd-4d11-b39b-e18835d5e21d/abilities/2/ab_all_3040078000_03.png",
                        },
                    },
                },
                AnimationName = "ab_motion",
                Effects =
                {
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.MultihitDamage,
                        ExtraData = new MultihitDamage
                        {
                            Element = damageElement,
                            HitNumber = 1,
                            HitAllTargets = true,
                            DamageModifier = 2,
                            DamageCap = 470000,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (zooey, target, raidActions) =>
                {
                    var random = ThreadSafeRandom.NextDouble();
                    foreach (var enemy in zooey.Raid.Enemies)
                    {
                        if (enemy.IsAlive() && enemy.PositionInFrontline < 4)
                        {
                            enemy.ApplyStatusEffect(
                                new StatusEffectSnapshot
                                {
                                    Id = random <= 1.0 / 3
                                        ? StatusEffectLibrary.StackableDefenseDownNpc
                                        : (random <= 2.0 / 3
                                            ? StatusEffectLibrary.StackableAttackDownNpc
                                            : StatusEffectLibrary.StackableDebuffResistanceDownNpc),
                                    Strength = -10,
                                    IsStackable = true,
                                    StackingCap = -30,
                                    BaseAccuracy = 100,
                                    RemainingDurationInSeconds = 180,
                                },
                                raidActions);
                        }
                    }
                },
            };
        }

        private static Ability Conjunction(uint cooldown)
        {
            return new Ability
            {
                Name = "Conjunction",
                Description = "Set all allies' HP to 1. All allies gain Unchallenged and Drain.",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    ConstructorName = "mc_ab_all_3040092000_02",
                    JsAssetPath = "npc/60d4c46a-f1bd-4d11-b39b-e18835d5e21d/abilities/1/ab_all_3040092000_02.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040092000_02",
                            Path = "npc/60d4c46a-f1bd-4d11-b39b-e18835d5e21d/abilities/1/ab_all_3040092000_02.png",
                        },
                    },
                },
                AnimationName = "ab_motion",
                ProcessEffects = (zooey, _, raidActions) =>
                {
                    foreach (var hero in zooey.Raid.Allies)
                    {
                        if (!hero.IsAlive() || hero.PositionInFrontline >= 4)
                        {
                            continue;
                        }

                        hero.DealRawDamage(hero.Hp - 1, Element.Null, raidActions);

                        hero.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.Unchallenged,
                                TurnDuration = 1,
                                IsBuff = true,
                            }, raidActions);

                        hero.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Strength = 100,
                                Id = StatusEffectLibrary.DrainNpc,
                                TurnDuration = 4,
                                IsBuff = true,
                                ExtraData = new Drain
                                {
                                    HealingCapPercentage = 15,
                                    IsPercentageBased = true,
                                }.ToByteString(),
                            }, raidActions);
                    }
                },
            };
        }
    }
}