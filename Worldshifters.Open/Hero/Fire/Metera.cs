// <copyright file="Metera.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Fire
{
    using System;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Hero.Abilities;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class Metera
    {
        public const string AetherialSealId = "metera/aetherial_seal";

        public static Guid Id = Guid.Parse("161daf6a-56c0-4cf1-ad23-8fb88a804475");

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Metera",
                Race = Race.Erune,
                Gender = Gender.Female,
                Description = "The exquisitely charming archer is full of excitement in this bustling town. Finding it unbearable to see her little sister with such poor fashion sense, she quietly coordinates a new outfit for her. This enchantingly beautiful flower of an archer soars the skies with her sister.",
                MaxAttack = 8400 + 540,
                MaxHp = 1200,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Fire,
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
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.TripleAttackRateBoost,
                    ExtendedMasteryPerks.FireAttackBoost,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.FireAttackBoost,
                    ExtendedMasteryPerks.SkillDamageCapBoost,
                    ExtendedMasteryPerks.DodgeRateBoost,
                    ExtendedMasteryPerks.SupportSkill,
                },
                PassiveAbilities =
                {
                    new PassiveAbility
                    {
                        Type = PassiveAbility.Types.PassiveAbilityType.SupportSkill,
                        Name = "Genius",
                        Description = "Boost to ATK against foes with a debuff",
                    },
                    new PassiveAbility
                    {
                        Type = PassiveAbility.Types.PassiveAbilityType.SupportSkill,
                        Name = "Complete Arcane Bow",
                        Description = "Normal attacks consume Aetherial Seal to deal additional damage",
                    },
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/161daf6a-56c0-4cf1-ad23-8fb88a804475/model/0/npc_3040072000_01.js",
                        ConstructorName = "mc_npc_3040072000_01",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040072000_01",
                                Path = "npc/161daf6a-56c0-4cf1-ad23-8fb88a804475/model/0/npc_3040072000_01.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/161daf6a-56c0-4cf1-ad23-8fb88a804475/model/0/phit_3040072000.js",
                        ConstructorName = "mc_phit_3040072000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040072000",
                                Path = "npc/161daf6a-56c0-4cf1-ad23-8fb88a804475/model/0/phit_3040072000.png",
                            },
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = "Dense Caress",
                    HitCount = { 1 },
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "npc/161daf6a-56c0-4cf1-ad23-8fb88a804475/model/0/nsp_3040072000_01.js",
                            ConstructorName = "mc_nsp_3040072000_01_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040072000_01",
                                    Path = "npc/161daf6a-56c0-4cf1-ad23-8fb88a804475/model/0/nsp_3040072000_01.png",
                                },
                            },
                        },
                    },
                    ShouldRepositionSpriteAnimationOnTarget = true,
                },
                Abilities =
                {
                    StarrySky(cooldown: 7),
                    AdornedRemittance(cooldown: 8),
                    DescentOfTheFlames(cooldown: 4),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = StarrySky(cooldown: 6, upgraded: true),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = AdornedRemittance(cooldown: 7),
                        UpgradedAbilityIndex = 1,
                    },
                },
                OnSetup = (metera, allies, loadout) =>
                {
                    metera.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = "metera/passive",
                            Strength = 10,
                            IsPassiveEffect = true,
                            IsUsedInternally = true,
                            TurnDuration = int.MaxValue,
                            Modifier = ModifierLibrary.FlatAttackBoost,
                            TriggerCondition = new StatusEffectSnapshot.Types.TriggerCondition
                            {
                                Type = StatusEffectSnapshot.Types.TriggerCondition.Types.Type.TargetHasDebuff,
                            },
                        });
                },
                OnAttackStart = (metera, raidActions) =>
                {
                    var seals = metera.GetStatusEffectStacks(AetherialSealId);
                    if (seals <= 0)
                    {
                        return;
                    }

                    metera.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = "metera/echo",
                            TurnDuration = 1,
                            Strength = 80,
                            Modifier = ModifierLibrary.AdditionalDamage,
                            IsUsedInternally = true,
                            IsUndispellable = true,
                        });
                },
                OnAttackEnd = (metera, attackResult, raidActions) =>
                {
                    var seals = metera.GetStatusEffectStacks(AetherialSealId);
                    if (seals <= 0)
                    {
                        return;
                    }

                    metera.ApplyOrOverrideStatusEffectStacks(AetherialSealId, 5, -1, 5, raidActions);

                    if (attackResult != EntitySnapshot.AttackResult.SpecialAttack)
                    {
                        return;
                    }

                    new Ability
                    {
                        ModelMetadata = new ModelMetadata
                        {
                            JsAssetPath =
                                "npc/161daf6a-56c0-4cf1-ad23-8fb88a804475/abilities/0/ab_3040072000_01.js",
                            ConstructorName = "mc_ab_3040072000_01_effect",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "ab_3040072000_01",
                                    Path =
                                        "npc/161daf6a-56c0-4cf1-ad23-8fb88a804475/abilities/0/ab_3040072000_01.png",
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
                                    Element = Element.Fire,
                                    HitNumber = 1,
                                    DamageModifier = 2,
                                    DamageCap = 700_000,
                                }.ToByteString(),
                            },
                        },
                    }.Cast(metera, metera.CurrentTargetPositionInFrontline, raidActions);
                },
            };
        }

        private static Ability StarrySky(uint cooldown, bool upgraded = false)
        {
            return new Ability
            {
                Name = "Starry Sky",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/161daf6a-56c0-4cf1-ad23-8fb88a804475/abilities/1/ab_all_3040012000_01.js",
                    ConstructorName = "mc_ab_all_3040012000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040012000_01",
                            Path = "npc/161daf6a-56c0-4cf1-ad23-8fb88a804475/abilities/1/ab_all_3040012000_01.png",
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
                            Element = Element.Fire,
                            HitNumber = 5,
                            DamageModifier = upgraded ? 0.9 : 0.75,
                            DamageCap = 400_000,
                            RandomTargets = true,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (metera, targetPositionInFrontline, raidActions) =>
                {
                    var seals = metera.GetStatusEffectStacks(AetherialSealId);
                    metera.RemoveStatusEffect($"{AetherialSealId}_seals");
                    metera.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = $"{AetherialSealId}_5",
                            Strength = 5,
                            TurnDuration = int.MaxValue,
                        },
                        raidActions);
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability AdornedRemittance(uint cooldown)
        {
            return new Ability
            {
                Name = "Adorned Remittance",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Offensive,
                ProcessEffects = (metera, targetPositionInFrontline, raidActions) =>
                {
                    var effect = SupportAbilities.Charmed();
                    effect.Effects.Add(
                        new AbilityEffect
                        {
                            Type = AbilityEffect.Types.AbilityEffectType.MultihitDamage,
                            ExtraData = new MultihitDamage
                            {
                                Element = Element.Fire,
                                HitNumber = 1,
                                DamageModifier = 2,
                                DamageCap = 270_000,
                            }.ToByteString(),
                        });
                    effect.Effects.Add(
                        new AbilityEffect
                        {
                            Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                            ExtraData = new ApplyStatusEffect
                            {
                                Id = StatusEffectLibrary.Charmed,
                                BaseAccuracy = 90,
                                Strength = 35,
                                DurationInSeconds = 180,
                            }.ToByteString(),
                        });
                    effect.Cast(metera, targetPositionInFrontline, raidActions);
                    effect.RepositionOnTarget = true;
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability DescentOfTheFlames(uint cooldown)
        {
            return new Ability
            {
                Name = "Descent of the Flames",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/161daf6a-56c0-4cf1-ad23-8fb88a804475/abilities/0/ab_3040072000_01.js",
                    ConstructorName = "mc_ab_3040072000_01_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040072000_01",
                            Path = "npc/161daf6a-56c0-4cf1-ad23-8fb88a804475/abilities/0/ab_3040072000_01.png",
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
                            Element = Element.Fire,
                            HitNumber = 1,
                            DamageModifier = 5.5,
                            DamageCap = 700_000,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (metera, targetPositionInFrontline, raidActions) =>
                {
                    var seals = metera.GetStatusEffectStacks(AetherialSealId);
                    if (seals > 0)
                    {
                        if (ThreadSafeRandom.NextDouble() > (metera.Hero.GetSupportSkillRank() * 0.2) - 0.1)
                        {
                            metera.ApplyOrOverrideStatusEffectStacks(AetherialSealId, 5, -1, 5, raidActions);
                        }

                        return;
                    }

                    metera.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            TurnDuration = 5,
                            BaseAccuracy = double.MaxValue,
                        },
                        raidActions,
                        (StatusEffectLibrary.DefenseDownNpc, ModifierLibrary.FlatDefenseBoost, -20),
                        (StatusEffectLibrary.HostilityUp, ModifierLibrary.HostilityBoost, 10));
                },
                AnimationName = "ab_motion",
                ShouldRepositionSpriteAnimation = true,
            };
        }
    }
}