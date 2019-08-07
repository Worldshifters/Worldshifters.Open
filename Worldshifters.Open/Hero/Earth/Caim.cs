// <copyright file="Caim.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Earth
{
    using System;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;

    public static class Caim
    {
        public static Guid Id = Guid.Parse("411f6619-d3f5-4044-b290-34c39cbef856");

        private const string TheHangedManReversedId = "caim/sub_aura";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Caim",
                Race = Race.Human,
                Gender = Gender.Male,
                MaxAttack = 10000,
                MaxHp = 1412,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Earth,
                WeaponProficiencies = { (EquipmentType[])Enum.GetValues(typeof(EquipmentType)) },
                AvailablePerkIds =
                {
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.HealingBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.HealingBoost,
                    ExtendedMasteryPerks.DebuffSuccessRateBoost,
                    ExtendedMasteryPerks.DebuffSuccessRateBoost,
                    ExtendedMasteryPerks.HostilityBoost,
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
                        JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/model/0/npc_3040164000_02.js",
                        ConstructorName = "mc_npc_3040164000_02",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040164000_02",
                                Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/model/0/npc_3040164000_02.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/model/0/phit_3040164000.js",
                        ConstructorName = "mc_phit_3040164000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040164000",
                                Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/model/0/phit_3040164000.png",
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
                            JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/model/0/nsp_3040164000_02_s2.js",
                            ConstructorName = "mc_nsp_3040164000_02_s2_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040164000_02_s2_a",
                                    Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/model/0/nsp_3040164000_02_s2_a.png",
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040164000_02_s2_b",
                                    Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/model/0/nsp_3040164000_02_s2_b.png",
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040164000_02_s2_c",
                                    Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/model/0/nsp_3040164000_02_s2_c.png",
                                },
                            },
                        },
                    },
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
                                JsAssetPath =
                                    "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/3/ab_all_3040038000_03.js",
                                ConstructorName = "mc_ab_all_3040038000_03",
                                ImageAssets =
                                {
                                    new ImageAsset
                                    {
                                        Name = "ab_all_3040038000_03",
                                        Path =
                                            "npc/25a06a88-ac5a-45eb-9d1c-ca007f4ad82f/abilities/3/ab_all_3040038000_03.png",
                                    },
                                },
                            },
                            Effects =
                            {
                            },
                            ProcessEffects = (caim, targetPositionInFrontline, raidActions) => { },
                            AnimationName = "ab_motion",
                        },
                        UpgradedAbilityIndex = 3,
                    },
                },
                OnActionStart = (caim, raidActions) => ProcessPassiveEffects(caim),
                OnTurnEnd = (caim, raidActions) => { },
                OnSetup = (caim, allies, loadout) =>
                {
                    caim.GlobalState[TheHangedManReversedId] = TypedValue.FromBool(true);
                },
                OnEnteringFrontline = (caim, raidActions) => ProcessPassiveEffects(caim),
                OnAttackEnd = (caim, attackResult, raidActions) => { },
                OnAttackActionEnd = (caim, raidActions) => { },
                OnTargettedByEnemy = (caim, enemy, raidActions) => { },
                OnAbilityEnd = (caim, ability, raidActions) => { },
                OnDeath = (caim, raidActions) => { },
            };
        }

        private static Ability Ability1(uint cooldown)
        {
            return new Ability
            {
                Name = string.Empty,
                Cooldown = 0,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/0/ab_all_3040164000_01.js",
                    ConstructorName = "mc_ab_all_3040164000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040164000_01",
                            Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/0/ab_all_3040164000_01.png",
                        },
                    },
                },
            };
        }

        private static Ability Ability2(uint cooldown)
        {
            return new Ability
            {
                Name = string.Empty,
                Cooldown = 0,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/1/ab_3040164000_01.js",
                    ConstructorName = "mc_ab_3040164000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040164000_01",
                            Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/1/ab_3040164000_01.png",
                        },
                    },
                },
            };
        }

        private static Ability Ability3(uint cooldown)
        {
            return new Ability
            {
                Name = string.Empty,
                Cooldown = 0,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/2/ab_all_3040164000_02.js",
                    ConstructorName = "mc_ab_all_3040164000_02",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040164000_02",
                            Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/2/ab_all_3040164000_02.png",
                        },
                    },
                },
            };
        }

        private static Ability Ability4(uint cooldown)
        {
            return new Ability
            {
                Name = string.Empty,
                Cooldown = 0,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/3/ab_3040164000_02.js",
                    ConstructorName = "mc_ab_3040164000_02",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040164000_02",
                            Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/3/ab_3040164000_02.png",
                        },
                    },
                },
            };
        }

        private static Ability Ability5(uint cooldown)
        {
            return new Ability
            {
                Name = string.Empty,
                Cooldown = 0,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/4/ab_3040164000_03.js",
                    ConstructorName = "mc_ab_3040164000_03",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040164000_03",
                            Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/4/ab_3040164000_03.png",
                        },
                    },
                },
            };
        }

        private static void ProcessPassiveEffects(EntitySnapshot caim)
        {
        }
    }
}