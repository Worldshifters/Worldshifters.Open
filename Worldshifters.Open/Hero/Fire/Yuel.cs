// <copyright file="Yuel.cs" company="Worldshifters">
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

    public static class Yuel
    {
        public static Guid Id = Guid.Parse("9d021476-1276-4cf9-aafd-7ad321b67142");

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Yuel",
                Race = Race.Erune,
                Gender = Gender.Female,
                MaxAttack = 8550 + 360,
                AttackLevels = { 7200 + 360 },
                MaxHp = 2000 + 270,
                HpLevels = { 1680 + 270 },
                MaxLevel = 100,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Fire,
                WeaponProficiencies = { EquipmentType.Katana, EquipmentType.Sword },
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
                    ExtendedMasteryPerks.FireAttackBoost,
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.TripleAttackRateBoost,
                    ExtendedMasteryPerks.HealingBoost,
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
                        JsAssetPath = "npc/9d021476-1276-4cf9-aafd-7ad321b67142/model/0/npc_3040006000_03.js",
                        ConstructorName = "mc_npc_3040006000_03",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040006000_03_a",
                                Path = "npc/9d021476-1276-4cf9-aafd-7ad321b67142/model/0/npc_3040006000_03_a.png",
                            },
                            new ImageAsset
                            {
                                Name = "npc_3040006000_03_b",
                                Path = "npc/9d021476-1276-4cf9-aafd-7ad321b67142/model/0/npc_3040006000_03_b.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/9d021476-1276-4cf9-aafd-7ad321b67142/model/0/phit_3040006000.js",
                        ConstructorName = "mc_phit_3040006000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040006000",
                                Path = "npc/9d021476-1276-4cf9-aafd-7ad321b67142/model/0/phit_3040006000.png",
                            },
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    HitCount = { 20 },
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "npc/9d021476-1276-4cf9-aafd-7ad321b67142/model/0/nsp_3040006000_03.js",
                            ConstructorName = "mc_nsp_3040006000_03_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040006000_03",
                                    Path = "npc/9d021476-1276-4cf9-aafd-7ad321b67142/model/0/nsp_3040006000_03.png",
                                },
                            },
                        },
                    },
                    ShouldRepositionSpriteAnimationOnTarget = true,
                    ProcessEffects = (yuel, raidActions) =>
                    {
                        if (yuel.Hero.Rank >= 5)
                        {
                            yuel.ApplyStatusEffect(
                                new StatusEffectSnapshot
                                {
                                    Id = StatusEffectLibrary.DamageCapUpNpc,
                                    Strength = 15,
                                    TurnDuration = 4,
                                });
                        }
                    },
                },
                Abilities =
                {
                    EyeOfTheSparrow(cooldown: 8),
                    Gurren(cooldown: 7, baseDamageModifier: 1.5),
                    RiteOfDawn(),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = EyeOfTheSparrow(cooldown: 7, upgradedEffects: true),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = Gurren(cooldown: 6, baseDamageModifier: 2.5),
                        UpgradedAbilityIndex = 1,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 95,
                        Ability = Gurren(cooldown: 6, baseDamageModifier: 2.5, grantsAdditionalDamage: true),
                        UpgradedAbilityIndex = 1,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 100,
                        Ability = ThirdDanceJinka(),
                        UpgradedAbilityIndex = 3,
                    },
                },
                OnSetup = (yuel, allies, loadout) =>
                {
                    yuel.ApplyStatusEffect(new StatusEffectSnapshot
                    {
                        Id = "yuel/passive",
                        TurnDuration = int.MaxValue,
                        Strength = 5,
                        Modifier = ModifierLibrary.FlatDoubleAttackRateBoost,
                        IsPassiveEffect = true,
                        IsUsedInternally = true,
                    });
                },
            };
        }

        private static Ability EyeOfTheSparrow(uint cooldown, bool upgradedEffects = false)
        {
            return new Ability
            {
                Name = "Eye of the Sparrow",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/9d021476-1276-4cf9-aafd-7ad321b67142/abilities/0/ab_4110.js",
                    ConstructorName = "mc_ab_4110_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_4110",
                            Path = "npc/9d021476-1276-4cf9-aafd-7ad321b67142/abilities/0/ab_4110.png",
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
                            Strength = upgradedEffects ? 75 : 50,
                            TurnDuration = 3,
                            EffectTargettingType = EffectTargettingType.OnSelf,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (yuel, targetPositionInFrontline, raidActions) =>
                {
                    new MultihitDamage
                    {
                        Element = Element.Fire,
                        DamageCap = 630_000,
                        DamageModifier = upgradedEffects ? (2.5 + ThreadSafeRandom.NextDouble()) : 2.5,
                    }.ProcessEffects(yuel, targetPositionInFrontline, raidActions);
                },
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
                AnimationName = "short_attack",
            };
        }

        private static Ability Gurren(uint cooldown, double baseDamageModifier, bool grantsAdditionalDamage = false)
        {
            return new Ability
            {
                Name = "Gurren",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/9d021476-1276-4cf9-aafd-7ad321b67142/abilities/1/ab_all_3040015000_02.js",
                    ConstructorName = "mc_ab_all_3040015000_02",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040015000_02",
                            Path = "npc/9d021476-1276-4cf9-aafd-7ad321b67142/abilities/1/ab_all_3040015000_02.png",
                        },
                    },
                },
                ProcessEffects = (yuel, targetPositionInFrontline, raidActions) =>
                {
                    new MultihitDamage
                    {
                        Element = Element.Fire,
                        HitAllTargets = true,
                        DamageCap = 260_000,
                        DamageModifier = baseDamageModifier + ThreadSafeRandom.NextDouble(),
                    }.ProcessEffects(yuel, raidActions);

                    if (grantsAdditionalDamage)
                    {
                        yuel.Raid.Allies.ApplyStatusEffects(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.AdditionalFireDamageNpc2,
                                Strength = 20,
                                TurnDuration = 3,
                            }, raidActions);
                    }
                },
                AnimationName = "short_attack",
            };
        }

        private static Ability RiteOfDawn()
        {
            var ability = HealingAbilities.ClearAll();
            ability.Name = "Rite of Dawn";
            ability.Description = "Remove 1 debuff from all allies and restore all allies' HP";
            ability.Cooldown = 6;
            ability.AnimationName = "short_attack";
            ability.Type = Ability.Types.AbilityType.Healing;

            // Clear debuffs first (default ClearAll effect) then heal
            ability.Effects.Add(new AbilityEffect
            {
                Type = AbilityEffect.Types.AbilityEffectType.Healing,
                ExtraData = new Heal
                {
                    HealingCap = 1500,
                    HpRecovered = 150,
                    HpPercentageRecovered = 20,
                    EffectTargettingType = EffectTargettingType.OnAllPartyMembers,
                }.ToByteString(),
            });

            return ability;
        }

        private static Ability ThirdDanceJinka()
        {
            return new Ability
            {
                Name = "Third Dance: Jinka",
                Cooldown = 6,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/9d021476-1276-4cf9-aafd-7ad321b67142/abilities/3/ab_all_3040006000_01.js",
                    ConstructorName = "mc_ab_all_3040006000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040006000_01",
                            Path = "npc/9d021476-1276-4cf9-aafd-7ad321b67142/abilities/3/ab_all_3040006000_01.png",
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
                            Id = StatusEffectLibrary.FireAttackUpNpc,
                            Strength = 20,
                            TurnDuration = 3,
                            EffectTargettingType = EffectTargettingType.OnAllPartyMembers,
                        }.ToByteString(),
                    },
                    ApplyStatusEffect.FromTemplate(
                        new ApplyStatusEffect
                        {
                            TurnDuration = 3,
                            EffectTargettingType = EffectTargettingType.OnSelf,
                        },
                        (StatusEffectLibrary.HealingBoost, 50),
                        (StatusEffectLibrary.HealingCapBoost, 100)),
                },
                AnimationName = "hide",
            };
        }
    }
}