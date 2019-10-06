// <copyright file="Haaselia.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Water
{
    using System;
    using System.Collections.Generic;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class Haaselia
    {
        public static Guid Id = Guid.Parse("ec77d956-5a29-4591-ad5b-231f1d39ab6f");

        private const string BewitchingId = "haaselia/bewitching";
        private const string TorahId = "haaselia/torah";
        private const string MoonId = "haaselia/moon";
        private const string TearsOfLunacyId = "haaselia/tears_of_lunacy";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Haaselia",
                Race = Race.Harvin,
                Gender = Gender.Female,
                MaxAttack = 10402,
                MaxHp = 1318,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Water,
                WeaponProficiencies = { EquipmentType.Staff, EquipmentType.Melee },
                AvailablePerkIds =
                {
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.DebuffResistanceBoost,
                    ExtendedMasteryPerks.AttackBoostAgainstFoesInOverdriveMode,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.WaterAttackBoost,
                    ExtendedMasteryPerks.ChargeAttackDamageBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.Reflect,
                    ExtendedMasteryPerks.SupportSkill,
                },
                PassiveAbilities =
                {
                    new PassiveAbility
                    {
                        Type = PassiveAbility.Types.PassiveAbilityType.SupportSkill,
                        Name = "Lunar Raiment",
                        Description = "Boost to Water allies' DEF specs based on the moon phase",
                    },
                    new PassiveAbility
                    {
                        Type = PassiveAbility.Types.PassiveAbilityType.BacklineEffect,
                        Name = "The Moon Reversed",
                        Description =
                            "When Sub Ally: Boost to Water allies' ATK and DEF based on number of turns passed",
                    },
                    new PassiveAbility
                    {
                        Type = PassiveAbility.Types.PassiveAbilityType.TriggerOnEnteringFrontline,
                        Name = "The High Priestess Upright",
                        Description = "When Switching to Main Ally: Haaselia gains Torah",
                    },
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/model/0/npc_3040168000_02.js",
                        ConstructorName = "mc_npc_3040168000_02",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040168000_02",
                                Path = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/model/0/npc_3040168000_02.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/model/0/phit_3040168000.js",
                        ConstructorName = "mc_phit_3040168000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040168000",
                                Path = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/model/0/phit_3040168000.png",
                            },
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    HitCount = { 1 },
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/model/0/nsp_3040168000_02_s2.js",
                            ConstructorName = "mc_nsp_3040168000_02_s2_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040168000_02_s2_a",
                                    Path = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/model/0/nsp_3040168000_02_s2_a.png",
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040168000_02_s2_b",
                                    Path = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/model/0/nsp_3040168000_02_s2_b.png",
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040168000_02_s2_c",
                                    Path = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/model/0/nsp_3040168000_02_s2_c.png",
                                },
                            },
                        },
                    },
                    ProcessEffects = (haaselia, raidActions) =>
                    {
                        foreach (var ally in haaselia.Raid.Allies)
                        {
                            if (!ally.IsAlive() || ally.PositionInFrontline >= 4 || ally.Element != Element.Water)
                            {
                                continue;
                            }

                            ally.ApplyStatusEffect(
                                new StatusEffectSnapshot
                                {
                                    Id = MoonId,
                                    TurnDuration = 5,
                                    IsBuff = true,
                                    IsUndispellable = true,
                                    IsUsedInternally = true,
                                });

                            var stacks = ally.GetStatusEffectStacks(MoonId);
                            if (stacks > 0)
                            {
                                ally.RemoveStatusEffect($"{MoonId}_{stacks}");
                            }

                            ally.ApplyStatusEffectStacks(MoonId, 1, raidActions, turnDuration: 2, isUndispellable: true);
                        }

                        ProcessMoonEffects(haaselia);
                    },
                },
                Abilities =
                {
                    Boaz(),
                    Jachin(),
                    PhasesOfTheMoon(),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = Boaz(upgradeEffect: true),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = Jachin(upgradedEffect: true),
                        UpgradedAbilityIndex = 1,
                    },
                },
                OnActionStart = (haaselia, raidActions) => ProcessPassiveEffects(haaselia),
                OnTurnEnd = (haaselia, raidActions) =>
                {
                    haaselia.GlobalState[TorahId + "/1"].BooleanValue = false;
                    haaselia.GlobalState[TorahId + "/2"].BooleanValue = false;
                    haaselia.GlobalState[TorahId + "/3"].BooleanValue = false;

                    foreach (var ally in haaselia.Raid.Allies)
                    {
                        if (!ally.IsAlive())
                        {
                            continue;
                        }

                        var moon = ally.GetStatusEffect(MoonId);
                        if (moon != null)
                        {
                            var currentMoonStrength = ally.GetStatusEffectStacks(MoonId);
                            UpdatePhaseOfTheMoon(
                                ally,
                                currentMoonStrength,
                                Math.Max(currentMoonStrength, Math.Max(0, 5 - moon.TurnDuration) + 1),
                                raidActions);
                        }
                    }
                },
                OnSetup = (haaselia, allies, loadout) =>
                {
                    haaselia.GlobalState.Add(TorahId + "/1", TypedValue.FromBool(false));
                    haaselia.GlobalState.Add(TorahId + "/2", TypedValue.FromBool(false));
                    haaselia.GlobalState.Add(TorahId + "/3", TypedValue.FromBool(false));
                },
                OnEnteringFrontline = (haaselia, raidActions) =>
                {
                    Torah().Cast(haaselia, raidActions);
                },
                OnAbilityEnd = (haaselia, ability, raidActions) =>
                {
                    if (haaselia.GetStatusEffect(TorahId) != null)
                    {
                        for (var abilityIndex = 0; abilityIndex < haaselia.AbilityCooldowns.Count; ++abilityIndex)
                        {
                            if (haaselia.AbilityCooldowns[abilityIndex] == ability.Cooldown && !haaselia.GlobalState[TorahId + "/" + (abilityIndex + 1)].BooleanValue)
                            {
                                haaselia.GlobalState[TorahId + "/" + (abilityIndex + 1)].BooleanValue = true;

                                // Haaselia's first and second ability cooldowns are linked
                                haaselia.AbilityCooldowns[abilityIndex] = 0;
                                if (abilityIndex == 0)
                                {
                                    haaselia.AbilityCooldowns[0] = 0;
                                    haaselia.AbilityCooldowns[1] = 0;
                                    haaselia.GlobalState[TorahId + "/1"].BooleanValue = true;
                                    haaselia.GlobalState[TorahId + "/2"].BooleanValue = true;
                                }

                                break;
                            }
                        }
                    }
                },
            };
        }

        private static Ability Boaz(bool upgradeEffect = false)
        {
            return new Ability
            {
                Name = "Boaz",
                Cooldown = 5,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/abilities/2/ab_3040168000_02.js",
                    ConstructorName = "mc_ab_3040168000_02_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040168000_02",
                            Path = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/abilities/2/ab_3040168000_02.png",
                        },
                    },
                },
                ProcessEffects = (haaselia, targetPositionInFrontline, raidActions) =>
                {
                    var target = haaselia.ResolveEnemyTarget(targetPositionInFrontline);
                    if (target == null)
                    {
                        return;
                    }

                    if (!haaselia.GlobalState.ContainsKey("boaz"))
                    {
                        haaselia.GlobalState.Add("boaz", TypedValue.FromLong(0));
                    }

                    var stacks = haaselia.GlobalState["boaz"].IntegerValue;
                    var newStackCount = Math.Min(stacks + 1, 3);
                    haaselia.GlobalState["boaz"].IntegerValue = newStackCount;

                    var statusEffectsToRemove = new HashSet<string>();
                    for (var oldStackCount = 1; oldStackCount < newStackCount; ++oldStackCount)
                    {
                        statusEffectsToRemove.Add($"{BewitchingId}_{oldStackCount}");
                    }

                    target.RemoveStatusEffects(statusEffectsToRemove);

                    var newStatusEffectId = $"{BewitchingId}_{newStackCount}";
                    target.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = newStatusEffectId,
                            IsLocal = true,
                            BaseAccuracy = 150,
                            TurnDuration = int.MaxValue,
                            IsUndispellable = true,
                        },
                        raidActions);

                    target.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            IsLocal = true,
                            BaseAccuracy = double.PositiveInfinity,
                            TurnDuration = int.MaxValue,
                            IsUndispellable = true,
                            IsUsedInternally = true,
                            TriggerCondition = new StatusEffectSnapshot.Types.TriggerCondition
                            {
                                Type = StatusEffectSnapshot.Types.TriggerCondition.Types.Type.HasStatusEffect,
                                Data = newStatusEffectId,
                            },
                        },
                        raidActions,
                        ($"{BewitchingId}/atk_down", ModifierLibrary.FlatAttackBoost, -5 * newStackCount),
                        ($"{BewitchingId}/def_down", ModifierLibrary.FlatDefenseBoost, -5 * stacks),
                        ($"{BewitchingId}/dr_down", ModifierLibrary.FlatDebuffResistanceBoost, -5 * stacks));

                    // Skill linked to Jachin
                    haaselia.AbilityCooldowns[1] = 5;
                },
                AnimationName = "ab_motion",
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
            };
        }

        private static Ability Jachin(bool upgradedEffect = false)
        {
            return new Ability
            {
                Name = "Jachin",
                Cooldown = 5,
                Type = Ability.Types.AbilityType.Support,
                AbilityTargetting = AbilityTargettingType.TargetSingleAliveFrontLineMember,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/abilities/1/ab_3040168000_01.js",
                    ConstructorName = "mc_ab_3040168000_01_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040168000_01",
                            Path = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/abilities/1/ab_3040168000_01.png",
                        },
                    },
                },
                Effects =
                {
                    ApplyStatusEffect.FromTemplate(
                        new ApplyStatusEffect
                        {
                            OnSelectedTarget = true,
                            IsBuff = true,
                            TurnDuration = int.MaxValue,
                        },
                        (StatusEffectLibrary.Unchallenged, 1),
                        (StatusEffectLibrary.MirrorImage, 1),
                        (StatusEffectLibrary.Veil, 0)),
                },
                ProcessEffects = (haaselia, targetPositionInFrontline, raidActions) =>
                {
                    if (upgradedEffect)
                    {
                        haaselia.Raid.Allies.AtPosition(targetPositionInFrontline).ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.Shield,
                                Strength = 3000,
                                IsBuff = true,
                                TurnDuration = int.MaxValue,
                            }, raidActions);
                    }

                    // Skill linked to Boaz
                    haaselia.AbilityCooldowns[0] = 5;
                },
                AnimationName = "ab_motion",
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
            };
        }

        private static Ability PhasesOfTheMoon()
        {
            return new Ability
            {
                Name = "Phases of the Moon",
                Cooldown = 5,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/abilities/0/ab_all_3040168000_01.js",
                    ConstructorName = "mc_ab_all_3040168000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040168000_01",
                            Path = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/abilities/0/ab_all_3040168000_01.png",
                        },
                    },
                },
                ProcessEffects = (haaselia, targetPositionInFrontline, raidActions) =>
                {
                    haaselia.Raid.Allies.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            ElementRestriction = Element.Water,
                            IsBuff = true,
                            TurnDuration = 2,
                        },
                        raidActions,
                        (StatusEffectLibrary.WaterAttackUpNpc, ModifierLibrary.ElementalAttackBoost, 20),
                        (TearsOfLunacyId, ModifierLibrary.None, 0));

                    foreach (var ally in haaselia.Raid.Allies)
                    {
                        if (!ally.IsAlive() || ally.PositionInFrontline >= 4 || ally.Element != Element.Water)
                        {
                            continue;
                        }

                        ally.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.ChargeGaugeBoost,
                                IsBuff = true,
                                Strength = 15,
                            }, raidActions);

                        // Increase the phase of the moon by 1
                        var moonStrength = ally.GetStatusEffectStacks(MoonId);
                        if (moonStrength > 0)
                        {
                            // Moon phases update when moonStrength reaches 3 or 5
                            UpdatePhaseOfTheMoon(ally, moonStrength, moonStrength < 3 ? 3 : 5, raidActions);
                        }
                    }
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Torah()
        {
            return new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/abilities/3/ab_3040168000_03.js",
                    ConstructorName = "mc_ab_3040168000_03_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040168000_03",
                            Path = "npc/ec77d956-5a29-4591-ad5b-231f1d39ab6f/abilities/3/ab_3040168000_03.png",
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
                            Id = TorahId,
                            IsBuff = true,
                            OnSelf = true,
                            TurnDuration = int.MaxValue,
                            IsUndispellable = true,
                        }.ToByteString(),
                    },
                },
                ShouldRepositionSpriteAnimation = true,
            };
        }

        private static void ProcessPassiveEffects(EntitySnapshot haaselia)
        {
            ProcessMoonEffects(haaselia);
            if (haaselia.IsAlive() && haaselia.PositionInFrontline >= 4)
            {
                haaselia.Raid.Allies.ApplyStatusEffectsFromTemplate(
                    new StatusEffectSnapshot
                    {
                        IsBuff = true,
                        TurnDuration = 1,
                        ElementRestriction = Element.Water,
                        IsPassiveEffect = true,
                        IsUsedInternally = true,
                    },
                    ("haaselia/passive/atk_up", ModifierLibrary.FlatAttackBoost, Math.Min(20, haaselia.Raid.Turn)),
                    ("haaselia/passive/def_up", ModifierLibrary.FlatDefenseBoost, Math.Min(40, 2 * haaselia.Raid.Turn)));
            }
        }

        private static void ProcessMoonEffects(EntitySnapshot haaselia)
        {
            foreach (var ally in haaselia.Raid.Allies)
            {
                if (!ally.IsAlive() || ally.PositionInFrontline >= 4)
                {
                    continue;
                }

                var moonStrength = ally.GetStatusEffectStacks(MoonId);
                if (moonStrength > 0)
                {
                    ally.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            TurnDuration = 1,
                            IsBuff = true,
                            IsUndispellable = true,
                            IsUsedInternally = true,
                        },
                        (MoonId + "/atk_up", ModifierLibrary.AttackBoost, 10 + (5 * moonStrength)),
                        (MoonId + "/def_up", ModifierLibrary.FlatDefenseBoost, 30 + (5 * moonStrength)));
                }

                if (moonStrength >= 3)
                {
                    ally.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = MoonId + "/fire_dmg_reduced",
                            TurnDuration = 1,
                            IsBuff = true,
                            IsUndispellable = true,
                            IsUsedInternally = true,
                            Modifier = ModifierLibrary.DamageReductionBoost,
                            AttackElementRestriction = Element.Fire,
                            Strength = 20,
                        });
                }

                if (moonStrength == 5)
                {
                    ally.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = MoonId + "/fire_dmg_cut",
                            TurnDuration = 1,
                            IsBuff = true,
                            IsUndispellable = true,
                            IsUsedInternally = true,
                            Modifier = ModifierLibrary.DamageCutBoost,
                            AttackElementRestriction = Element.Fire,
                            Strength = 20,
                        });
                }

                if (ally.GetStatusEffect(TearsOfLunacyId) != null)
                {
                    ally.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = MoonId + "/da_up",
                            TurnDuration = 1,
                            IsBuff = true,
                            IsUndispellable = true,
                            IsUsedInternally = true,
                            Modifier = ModifierLibrary.FlatDoubleAttackRateBoost,
                            Strength = 20,
                        });

                    if (moonStrength >= 3)
                    {
                        ally.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = MoonId + "/echo",
                                TurnDuration = 1,
                                IsBuff = true,
                                IsUndispellable = true,
                                IsUsedInternally = true,
                                Modifier = ModifierLibrary.AdditionalDamage,
                                Strength = 20,
                            });
                    }

                    if (moonStrength == 5)
                    {
                        ally.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = MoonId + "/dmg_cap_up",
                                TurnDuration = 1,
                                IsBuff = true,
                                IsUndispellable = true,
                                IsUsedInternally = true,
                                Modifier = ModifierLibrary.FlatDamageCapBoost,
                                Strength = 10,
                            });
                    }
                }
            }
        }

        private static void UpdatePhaseOfTheMoon(EntitySnapshot ally, int currentMoonStrength, int moonStrength, IList<RaidAction> raidActions)
        {
            if (currentMoonStrength != moonStrength)
            {
                ally.RemoveStatusEffect($"{MoonId}_{currentMoonStrength}");
            }

            ally.ApplyStatusEffect(
                new StatusEffectSnapshot
                {
                    Id = MoonId + "_" + moonStrength,
                    IsBuff = true,
                    TurnDuration = 2,
                    Strength = moonStrength,
                    IsUndispellable = true,
                },
                raidActions);
        }
    }
}