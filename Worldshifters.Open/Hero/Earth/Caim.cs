// <copyright file="Caim.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Earth
{
    using System;
    using System.Collections.Generic;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class Caim
    {
        public const string DoubleDealId = "caim/double_deal";

        public static Guid Id = Guid.Parse("411f6619-d3f5-4044-b290-34c39cbef856");

        private const string TheHangedManReversedId = "caim/sub_aura";
        private const string ClubsId = "caim/clubs";
        private const string DiamondsId = "caim/diamonds";
        private const string HeartsId = "caim/hearts";
        private const string SpadesId = "caim/spades";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Caim",
                Races = { Race.Human },
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
                        Name = "Wild Card",
                        Description = "Subject to all specialty weapon-, style-, and race-related weapon skills",
                    },
                    new PassiveAbility
                    {
                        Type = PassiveAbility.Types.PassiveAbilityType.BacklineEffect,
                        Name = "The Hanged Man Reversed",
                        Description = "When Sub Ally: When all equipped weapons are different, boost to Earth allies' ATK, DEF and damage cap",
                    },
                    new PassiveAbility
                    {
                        Type = PassiveAbility.Types.PassiveAbilityType.TriggerOnEnteringFrontline,
                        Name = "The Fool Upright	",
                        Description = "When Switching to Main Ally: Caim gains 1-4 ranks of Spade, Heart, Diamond, Club each.",
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
                    DoubleDeal(initialCooldown: 4),
                    Joker(cooldown: 8),
                    BlankFaceTrick(),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = DoubleDeal(initialCooldown: 3),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = Joker(cooldown: 7),
                        UpgradedAbilityIndex = 1,
                    },
                },
                OnActionStart = (caim, _, raidActions) => ProcessPassiveEffects(caim),
                OnTurnEnd = (caim, raidActions) => { },
                OnSetup = (caim, allies, loadout) =>
                {
                    caim.GlobalState[TheHangedManReversedId] = TypedValue.FromBool(true);
                },
                OnEnteringFrontline = (caim, raidActions) =>
                {
                    if (caim.GlobalState.ContainsKey("nonce"))
                    {
                        return;
                    }

                    caim.GlobalState["nonce"] = TypedValue.FromBool(true);
                    TheFoolUpright().Cast(caim, raidActions);
                },
                OnAttackEnd = (caim, attackResult, raidActions) => { },
                OnAttackActionEnd = (caim, raidActions) => { },
                OnOtherAllyAbilityEnd = (caim, caster, ability, raidActions) =>
                {
                    BlankFace(caim, raidActions);
                },
                OnDeath = (caim, raidActions) => { },
            };
        }

        private static Ability BlankFaceTrick()
        {
            return new Ability
            {
                Name = "Blank Face",
                Cooldown = 5,
                Type = Ability.Types.AbilityType.Support,
                ProcessEffects = (caim, targetIndex, raidActions) =>
                {
                    if (!caim.GlobalState.ContainsKey("blank_face"))
                    {
                        return;
                    }

                    if (caim.GlobalState["blank_face"].StringValue == "spades")
                    {
                        SpadeTrick().Cast(caim, raidActions);
                    }
                    else if (caim.GlobalState["blank_face"].StringValue == "diamonds")
                    {
                        DiamondTrick().Cast(caim, raidActions);
                    }
                    else if (caim.GlobalState["blank_face"].StringValue == "clubs")
                    {
                        ClubTrick().Cast(caim, raidActions);
                    }
                    else if (caim.GlobalState["blank_face"].StringValue == "hearts")
                    {
                        HeartTrick().Cast(caim, raidActions);
                    }
                },
            };
        }

        private static void BlankFace(EntitySnapshot caim, IList<RaidAction> raidActions)
        {
            var lastAbility = caim.Raid.GetLastAbilityUsed();
            if (lastAbility != null)
            {
                if (lastAbility.Type == Ability.Types.AbilityType.Offensive)
                {
                    caim.GlobalState["blank_face"] = TypedValue.FromString("spades");
                    if (caim.PositionInFrontline < 4)
                    {
                        SpadesPreparation().Cast(caim, raidActions);
                    }
                }
                else if (lastAbility.Type == Ability.Types.AbilityType.Healing)
                {
                    caim.GlobalState["blank_face"] = TypedValue.FromString("hearts");
                    if (caim.PositionInFrontline < 4)
                    {
                        HeartsPreparation().Cast(caim, raidActions);
                    }
                }
                else if (lastAbility.Type == Ability.Types.AbilityType.Support)
                {
                    caim.GlobalState["blank_face"] = TypedValue.FromString("diamonds");
                    if (caim.PositionInFrontline < 4)
                    {
                        DiamondsPreparation().Cast(caim, raidActions);
                    }
                }
                else if (lastAbility.Type == Ability.Types.AbilityType.Defensive)
                {
                    caim.GlobalState["blank_face"] = TypedValue.FromString("clubs");
                    if (caim.PositionInFrontline < 4)
                    {
                        ClubsPreparation().Cast(caim, raidActions);
                    }
                }
            }
        }

        private static Ability DoubleDeal(uint initialCooldown)
        {
            return new Ability
            {
                Name = "Double Deal",
                Cooldown = int.MaxValue,
                InitialCooldown = (int)initialCooldown,
                Type = Ability.Types.AbilityType.Support,
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
                Effects =
                {
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = DoubleDealId,
                            EffectTargettingType = EffectTargettingType.OnAllPartyMembers,
                            IsUndispellable = true,
                            TurnDuration = int.MaxValue,
                        }.ToByteString(),
                    },
                },
            };
        }

        private static Ability Joker(uint cooldown)
        {
            return new Ability
            {
                Name = string.Empty,
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Support,
                ProcessEffects = (caim, targetIndex, raidActions) =>
                {
                    if (caim.GlobalState.ContainsKey("beginning_of_joker"))
                    {
                        EndOfJoker().Cast(caim, raidActions);
                        caim.GlobalState.Remove("beginning_of_joker");
                        caim.Raid.Allies.ApplyStatusEffectsFromTemplate(
                            new StatusEffectSnapshot
                            {
                                TurnDuration = 3,
                            },
                            raidActions,
                            (StatusEffectLibrary.AttackUpSummon, ModifierLibrary.AttackBoost, 30),
                            (StatusEffectLibrary.DefenseUpSummon, ModifierLibrary.FlatDefenseBoost, 30),
                            (StatusEffectLibrary.TripleAttackRateUpSummon, ModifierLibrary.FlatTripleAttackRateBoost, 20),
                            (StatusEffectLibrary.DamageCapUpSummon, ModifierLibrary.FlatDamageCapBoost, 10),
                            (StatusEffectLibrary.Uplifted, ModifierLibrary.ChargeBarSpedUp, 15));

                        caim.Raid.Allies.ApplyStatusEffects(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.RevitalizeSummon,
                                Strength = 500,
                                TurnDuration = 3,
                                ExtraData = new Revitalize
                                {
                                    BoostChargeGaugeAtFullHp = true,
                                    HealingCap = 500,
                                }.ToByteString(),
                            },
                            raidActions);

                        caim.Raid.Allies.ApplyStatusEffects(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.Veil,
                                TurnDuration = int.MaxValue,
                            },
                            raidActions);
                    }
                    else
                    {
                        var lastAbility = caim.Raid.GetLastAbilityUsed(heroIdToExclude: caim.Hero.Id);
                        lastAbility?.Cast(caim, raidActions, doNotRenderCastAbilityEffect: true);
                        caim.GlobalState["beginning_of_joker"] = TypedValue.FromBool(true);
                    }
                },
                DoNotRenderAbilityCastEffect = true,
            };
        }

        private static Ability ClubTrick()
        {
            return new Ability
            {
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
                Effects =
                {
                    ApplyStatusEffect.FromTemplate(
                        new ApplyStatusEffect
                        {
                            IsStackable = true,
                            EffectTargettingType = EffectTargettingType.OnAllEnemies,
                            BaseAccuracy = 100,
                            DurationInSeconds = 180,
                            StackingCap = -40,
                        },
                        (StatusEffectLibrary.StackableAttackDownNpc, -10),
                        (StatusEffectLibrary.StackableDefenseDownNpc, -10)),
                },
                ProcessEffects = (caim, targetIndex, raidActions) =>
                {
                    caim.ApplyOrOverrideStatusEffectStacks(ClubsId, 1, 1, 4, raidActions, isUndispellable: true);
                },
            };
        }

        private static Ability ClubsPreparation()
        {
            return new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/clubs_preparation/ab_3040164000_08.js",
                    ConstructorName = "mc_ab_3040164000_08_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040164000_08",
                            Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/clubs_preparation/ab_3040164000_08.png",
                        },
                    },
                },
                ShouldRepositionSpriteAnimation = true,
            };
        }

        private static Ability DiamondTrick()
        {
            return new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/diamonds/ab_3040164000_07.js",
                    ConstructorName = "mc_ab_3040164000_07_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040164000_07",
                            Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/diamonds/ab_3040164000_07.png",
                        },
                    },
                },
                ShouldRepositionSpriteAnimation = true,
                ProcessEffects = (caim, targetIndex, raidActions) =>
                {
                    caim.Raid.Allies.ApplyStatusEffects(
                        new StatusEffectSnapshot
                        {
                            Id = StatusEffectLibrary.ChargeGaugeBoost,
                            Strength = 15,
                        },
                        raidActions);
                    caim.ApplyOrOverrideStatusEffectStacks(DiamondsId, 1, 1, 4, raidActions, isUndispellable: true);
                },
            };
        }

        private static Ability DiamondsPreparation()
        {
            return new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/diamonds_preparation/ab_3040164000_06.js",
                    ConstructorName = "mc_ab_3040164000_06_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040164000_06",
                            Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/diamonds_preparation/ab_3040164000_06.png",
                        },
                    },
                },
                ShouldRepositionSpriteAnimation = true,
            };
        }

        private static Ability HeartTrick()
        {
            return new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/diamonds/ab_3040164000_07.js",
                    ConstructorName = "mc_ab_3040164000_07_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040164000_07",
                            Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/diamonds/ab_3040164000_07.png",
                        },
                    },
                },
                ShouldRepositionSpriteAnimation = true,
                Effects =
                {
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.Healing,
                        ExtraData = new Heal
                        {
                            HpPercentageRecovered = 20,
                            HealingCap = 2000,
                            EffectTargettingType = EffectTargettingType.OnAllPartyMembers,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (caim, targetIndex, raidActions) =>
                {
                    caim.ApplyOrOverrideStatusEffectStacks(HeartsId, 1, 1, 4, raidActions, isUndispellable: true);
                },
            };
        }

        private static Ability HeartsPreparation()
        {
            return new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/hearts_preparation/ab_3040164000_04.js",
                    ConstructorName = "mc_ab_3040164000_04_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040164000_04",
                            Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/hearts_preparation/ab_3040164000_04.png",
                        },
                    },
                },
                ShouldRepositionSpriteAnimation = true,
            };
        }

        private static Ability SpadeTrick()
        {
            return new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/spades/ab_3040164000_03.js",
                    ConstructorName = "mc_ab_3040164000_03_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040164000_03",
                            Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/spades/ab_3040164000_03.png",
                        },
                    },
                },
                ShouldRepositionSpriteAnimation = true,
                ProcessEffects = (caim, targetIndex, raidActions) =>
                {
                    caim.Attack(raidActions, disableSpecialAttack: true);
                    caim.ApplyOrOverrideStatusEffectStacks(SpadesId, 1, 1, 4, raidActions, isUndispellable: true);
                },
            };
        }

        private static Ability SpadesPreparation()
        {
            return new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/spades_preparation/ab_3040164000_02.js",
                    ConstructorName = "mc_ab_3040164000_02_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040164000_02",
                            Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/spades_preparation/ab_3040164000_02.png",
                        },
                    },
                },
                ShouldRepositionSpriteAnimation = true,
            };
        }

        private static Ability EndOfJoker()
        {
            return new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/1/ab_3040164000_01.js",
                    ConstructorName = "mc_ab_3040164000_01_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040164000_01",
                            Path = "npc/411f6619-d3f5-4044-b290-34c39cbef856/abilities/1/ab_3040164000_01.png",
                        },
                    },
                },
                ShouldRepositionSpriteAnimation = true,
            };
        }

        private static Ability TheFoolUpright()
        {
            return new Ability
            {
                DoNotRenderAbilityCastEffect = true,
                ProcessEffects = (caim, targetIndex, raidActions) =>
                {
                    EndOfJoker().Cast(caim, raidActions);
                    caim.ApplyOrOverrideStatusEffectStacks(ClubsId, (uint)(ThreadSafeRandom.NextDouble() * 4) + 1, 1, 4, raidActions, isUndispellable: true);
                    caim.ApplyOrOverrideStatusEffectStacks(DiamondsId, (uint)(ThreadSafeRandom.NextDouble() * 4) + 1, 1, 4, raidActions, isUndispellable: true);
                    caim.ApplyOrOverrideStatusEffectStacks(HeartsId, (uint)(ThreadSafeRandom.NextDouble() * 4) + 1, 1, 4, raidActions, isUndispellable: true);
                    caim.ApplyOrOverrideStatusEffectStacks(SpadesId, (uint)(ThreadSafeRandom.NextDouble() * 4) + 1, 1, 4, raidActions, isUndispellable: true);
                },
            };
        }

        private static void ProcessPassiveEffects(EntitySnapshot caim)
        {
            if (!caim.IsAlive())
            {
                return;
            }

            if (caim.PositionInFrontline >= 4 && caim.GlobalState.ContainsKey(TheHangedManReversedId))
            {
                caim.Raid.Allies.ApplyStatusEffectsFromTemplate(
                    new StatusEffectSnapshot
                    {
                        TurnDuration = 1,
                        ElementRestriction = Element.Earth,
                        IsPassiveEffect = true,
                        IsUsedInternally = true,
                    },
                    ($"{TheHangedManReversedId}/atk_up", ModifierLibrary.FlatAttackBoost, 20),
                    ($"{TheHangedManReversedId}/def_up", ModifierLibrary.FlatDefenseBoost, 50),
                    ($"{TheHangedManReversedId}/dmg_cap_up", ModifierLibrary.FlatDamageCapBoost, 10));
            }

            if (caim.PositionInFrontline < 4)
            {
                var clubStacks = caim.GetStatusEffectStacks(ClubsId);
                var diamondStacks = caim.GetStatusEffectStacks(DiamondsId);
                var heartStacks = caim.GetStatusEffectStacks(HeartsId);
                caim.ApplyStatusEffectsFromTemplate(
                    new StatusEffectSnapshot
                    {
                        IsUsedInternally = true,
                        IsUndispellable = true,
                        TurnDuration = 1,
                    },
                    ($"{SpadesId}/atk_up", ModifierLibrary.FlatAttackBoost, StackCountToBuffStrength(caim.GetStatusEffectStacks(SpadesId))),
                    ($"{HeartsId}/healing_up", ModifierLibrary.HealingBoost, StackCountToBuffStrength(heartStacks)),
                    ($"{HeartsId}/healing_cap_up", ModifierLibrary.HealingCapBoost, StackCountToBuffStrength(caim.GetStatusEffectStacks(HeartsId))),
                    ($"{DiamondsId}/def_up", ModifierLibrary.FlatDefenseBoost, 25 * diamondStacks),
                    ($"{DiamondsId}/dsr", ModifierLibrary.FlatDebuffSuccessRateBoost, StackCountToBuffStrength(clubStacks)));

                if (heartStacks > 0)
                {
                    caim.ApplyStatusEffect(new StatusEffectSnapshot
                    {
                        Id = $"{HeartsId}/drain",
                        TurnDuration = 1,
                        Modifier = ModifierLibrary.Drain,
                        Strength = 10,
                        IsUsedInternally = true,
                        IsUndispellable = true,
                        ExtraData = new Drain
                        {
                            HealingCap = 500,
                            IsPercentageBased = true,
                            HealingCapPercentage = long.MaxValue, // Force HealingCap only to be taken into account for healing cap calculations
                        }.ToByteString(),
                    });
                }

                if (diamondStacks > 0)
                {
                    caim.ApplyStatusEffect(new StatusEffectSnapshot
                    {
                        Id = StatusEffectLibrary.WaterSwitch,
                        TurnDuration = 1,
                        IsUsedInternally = true,
                        IsUndispellable = true,
                    });
                }

                if (clubStacks > 0)
                {
                    caim.ApplyStatusEffect(new StatusEffectSnapshot
                    {
                        Id = $"{ClubsId}/echo",
                        TurnDuration = 1,
                        IsUsedInternally = true,
                        IsUndispellable = true,
                        Strength = 10,
                        Modifier = ModifierLibrary.AdditionalDamage,
                    });
                }
            }
        }

        private static double StackCountToBuffStrength(int stackCount)
        {
            if (stackCount == 0)
            {
                return 0;
            }

            if (stackCount == 1)
            {
                return 10;
            }

            if (stackCount == 2)
            {
                return 20;
            }

            if (stackCount == 3)
            {
                return 35;
            }

            return 50;
        }
    }
}