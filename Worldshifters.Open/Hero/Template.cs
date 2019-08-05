// <copyright file="Template.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero
{
    using System;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;

    public static class Template
    {
        public static Guid Id = Guid.Parse("25a06a88-ac5a-45eb-9d1c-ca007f4ad82f");

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Template Hero",
                Race = Race.Unknow,
                Gender = Gender.Female,
                MaxAttack = 11222,
                AttackLevels = { 9522 },
                MaxHp = 2222,
                HpLevels = { 1822 },
                MaxLevel = 100,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Wind,
                WeaponProficiencies = { EquipmentType.MusicalInstrument },
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
                        JsAssetPath = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/model/0/npc_3040038000_03.js",
                        ConstructorName = "mc_npc_3040038000_03",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040038000_03_a",
                                Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/model/0/npc_3040038000_03_a.png",
                            },
                            new ImageAsset
                            {
                                Name = "npc_3040038000_03_b",
                                Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/model/0/npc_3040038000_03_b.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/model/0/phit_3040038000.js",
                        ConstructorName = "mc_phit_3040038000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040038000",
                                Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/model/0/phit_3040038000.png",
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
                            JsAssetPath = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/model/0/nsp_3040038000_03.js",
                            ConstructorName = "mc_nsp_3040038000_03_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040038000_03",
                                    Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/model/0/nsp_3040038000_03.png",
                                },
                            },
                        },
                    },
                    Effects =
                    {
                    },
                    ProcessEffects = (template, raidActions) =>
                    {
                    },
                    ShouldRepositionSpriteAnimationOnTarget = true,
                    ConstructorNameOnAnimationSkip = { "mc_nsp_3040038000_03_special" },
                    FrameToSkipToOnAnimationSkip = { 110, },
                },
                Abilities =
                {
                    Ability1(cooldown: 6),
                    Ability2(cooldown: 8),
                    Ability3(cooldown: 5),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = Ability1(cooldown: 5),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = Ability2(cooldown: 7),
                        UpgradedAbilityIndex = 1,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 95,
                        Ability = Ability2(cooldown: 6),
                        UpgradedAbilityIndex = 1,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 100,
                        Ability = new Ability
                        {
                            Name = "Ability 4",
                            Type = Ability.Types.AbilityType.Support,
                            Cooldown = int.MaxValue,
                            InitialCooldown = 0,
                            ModelMetadata = new ModelMetadata
                            {
                                JsAssetPath = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/3/ab_all_3040038000_03.js",
                                ConstructorName = "mc_ab_all_3040038000_03",
                                ImageAssets =
                                {
                                    new ImageAsset
                                    {
                                        Name = "ab_all_3040038000_03",
                                        Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/3/ab_all_3040038000_03.png",
                                    },
                                },
                            },
                            Effects =
                            {
                            },
                            ProcessEffects = (template, targetPositionInFrontline, raidActions) =>
                            {
                            },
                            AnimationName = "ab_motion",
                        },
                        UpgradedAbilityIndex = 3,
                    },
                },
                OnActionStart = (template, raidActions) => ProcessPassiveEffects(template),
                OnTurnEnd = (template, raidActions) =>
                {
                },
                OnSetup = (template, allies, loadout) =>
                {
                },
                OnEnteringFrontline = (template, raidActions) => ProcessPassiveEffects(template),
                OnAttackEnd = (template, attackResult, raidActions) =>
                {
                },
                OnAttackActionEnd = (template, raidActions) =>
                {
                },
                OnTargettedByEnemy = (template, enemy, raidActions) =>
                {
                },
                OnAbilityEnd = (template, ability, raidActions) =>
                {
                },
                OnDeath = (template, raidActions) =>
                {
                },
            };
        }

        private static Ability Ability1(uint cooldown)
        {
            return new Ability
            {
                Name = "Ability 1",
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/0/ab_all_3040038000_02.js",
                    ConstructorName = "mc_ab_all_3040038000_02",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040038000_02",
                            Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/0/ab_all_3040038000_02.png",
                        },
                    },
                },
                Effects =
                {
                },
                ProcessEffects = (template, targetPositionInFrontline, raidActions) =>
                {
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Ability2(uint cooldown)
        {
            return new Ability
            {
                Name = "Ability 2",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/3/ab_all_3040038000_03.js",
                    ConstructorName = "mc_ab_all_3040038000_03",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040038000_03",
                            Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/3/ab_all_3040038000_03.png",
                        },
                    },
                },
                Effects =
                {
                },
                ProcessEffects = (template, targetPositionInFrontline, raidActions) =>
                {
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Ability3(uint cooldown)
        {
            return new Ability
            {
                Name = "Ability 3",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/2/ab_all_3040038000_01.js",
                    ConstructorName = "mc_ab_all_3040038000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040038000_01",
                            Path = "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/2/ab_all_3040038000_01.png",
                        },
                    },
                },
                Effects =
                {
                },
                ProcessEffects = (template, targetPositionInFrontline, raidActions) =>
                {
                },
                AnimationName = "ab_motion",
            };
        }

        private static void ProcessPassiveEffects(EntitySnapshot template)
        {
        }
    }
}