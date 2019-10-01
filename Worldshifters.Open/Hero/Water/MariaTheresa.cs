// <copyright file="MariaTheresa.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Water
{
    using System;
    using System.Linq;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class MariaTheresa
    {
        public static Guid Id = Guid.Parse("ebbe21c2-f8ef-44e6-b947-b1323ef8c070");

        private const string DevotionToJusticeId = "maria_theresa/devotion_to_justice";
        private const string RighteousIndignationId = "maria_theresa/righteous_indignation";
        private const string UnrighteousnessId = "maria_theresa/unrighteousness";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Maria Theresa",
                Race = Race.Draph,
                Gender = Gender.Female,
                MaxAttack = 11222,
                MaxHp = 2222,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Water,
                WeaponProficiencies = { EquipmentType.Staff, EquipmentType.Sword },
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
                    ExtendedMasteryPerks.FireDamageReduction,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.ChargeAttackDamageBoost,
                    ExtendedMasteryPerks.SupportSkill,
                },
                PassiveAbilities =
                {
                    new PassiveAbility
                    {
                        Type = PassiveAbility.Types.PassiveAbilityType.SupportSkill,
                        Name = "Aurum Sword",
                        Description =
                            "Water damage to all foes when an ally casts a buff-removing skill. Inflict Status Unrighteousness (Local) 3.pngUnrighteousness.",
                    },
                    new PassiveAbility
                    {
                        Type = PassiveAbility.Types.PassiveAbilityType.BacklineEffect,
                        Name = "Justice Reversed",
                        Description =
                            "When Sub Ally: Water damage to all foes when a Water ally casts a buff-removing skill. Inflict Attack Down and Defense Down.",
                    },
                    new PassiveAbility
                    {
                        Type = PassiveAbility.Types.PassiveAbilityType.TriggerOnEnteringFrontline,
                        Name = "The Empress Upright",
                        Description =
                            "When Switching to Main Ally: All Water allies gain Status Righteous Indignation.",
                    },
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/model/0/npc_3040160000_02.js",
                        ConstructorName = "mc_npc_3040160000_02",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040160000_02_a",
                                Path = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/model/0/npc_3040160000_02_a.png",
                            },
                            new ImageAsset
                            {
                                Name = "npc_3040160000_02_b",
                                Path = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/model/0/npc_3040160000_02_b.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/model/0/phit_3040160000.js",
                        ConstructorName = "mc_phit_3040160000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040160000",
                                Path = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/model/0/phit_3040160000.png",
                            },
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = string.Empty,

                    HitCount = { 4 },

                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/model/0/nsp_3040160000_02_s2.js",
                            ConstructorName = "mc_nsp_3040160000_02_s2_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040160000_02_s2_a",
                                    Path =
                                        "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/model/0/nsp_3040160000_02_s2_a.png",
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040160000_02_s2_b",
                                    Path =
                                        "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/model/0/nsp_3040160000_02_s2_b.png",
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040160000_02_s2_c",
                                    Path =
                                        "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/model/0/nsp_3040160000_02_s2_c.png",
                                },
                            },
                        },
                    },
                },
                Abilities =
                {
                    Abraxas(cooldown: 6),
                    Uguale(cooldown: 8),
                    Fedelta(cooldown: 5),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = Abraxas(cooldown: 5),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = Uguale(cooldown: 7),
                        UpgradedAbilityIndex = 1,
                    },
                },
                OnEnteringFrontline = (mariaTheresa, raidActions) =>
                {
                    if (mariaTheresa.GlobalState.ContainsKey("nonce"))
                    {
                        return;
                    }

                    mariaTheresa.GlobalState["nonce"] = TypedValue.FromBool(true);
                    TheEmpressUpright().Cast(mariaTheresa, raidActions);
                },
                OnAbilityEnd = (mariaTheresa, ability, raidActions) =>
                {
                    if (!mariaTheresa.IsAlive())
                    {
                        return;
                    }

                    if (ability.Effects.Where(e => e.Type == AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect)
                        .Any(e => ApplyStatusEffect.ParseFrom(e.ExtraData).Id == StatusEffectLibrary.Dispel))
                    {
                        AurumSword().Cast(mariaTheresa, raidActions);
                    }
                },
                OnOtherAllyAbilityEnd = (mariaTheresa, caster, ability, raidActions) =>
                {
                    if (!mariaTheresa.IsAlive())
                    {
                        return;
                    }

                    if (ability.Effects.Where(e => e.Type == AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect)
                        .Any(e => ApplyStatusEffect.ParseFrom(e.ExtraData).Id == StatusEffectLibrary.Dispel))
                    {
                        if (mariaTheresa.PositionInFrontline >= 4)
                        {
                            JusticeReversed().Cast(mariaTheresa, raidActions);
                        }
                        else
                        {
                            AurumSword().Cast(mariaTheresa, raidActions);
                        }
                    }
                },
                OnDeath = (mariaTheresa, raidActions) => { },
            };
        }

        private static Ability Abraxas(uint cooldown)
        {
            return new Ability
            {
                Name = "Abraxas",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/abilities/0/ab_all_3040160000_01.js",
                    ConstructorName = "mc_ab_all_3040160000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040160000_01",
                            Path = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/abilities/0/ab_all_3040160000_01.png",
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
                            Element = Element.Water,
                            HitNumber = 2,
                            DamageCap = 420_000,
                            DamageModifier = 3.5,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = StatusEffectLibrary.Dispel,
                            BaseAccuracy = double.PositiveInfinity,
                        }.ToByteString(),
                    },
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Uguale(uint cooldown)
        {
            return new Ability
            {
                Name = "Uguale",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Healing,
                AbilityTargetting = AbilityTargettingType.TargetSingleAliveFrontLineMember,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/abilities/1/ab_all_3040160000_02.js",
                    ConstructorName = "mc_ab_all_3040160000_02",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040160000_02",
                            Path = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/abilities/1/ab_all_3040160000_02.png",
                        },
                    },
                },
                ProcessEffects = (mariaTheresa, targetPositionInFrontline, raidActions) =>
                {
                    var target = mariaTheresa.Raid.Allies.AtPosition(targetPositionInFrontline);
                    foreach (var hero in mariaTheresa.Raid.Allies)
                    {
                        if (hero.IsAlive() && hero.PositionInFrontline < 4)
                        {
                            hero.Hp = Math.Min(hero.MaxHp, target.Hp);
                            hero.ChargeGauge = Math.Min(hero.MaxChargeGauge, target.ChargeGauge);
                        }
                    }
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Fedelta(uint cooldown)
        {
            return new Ability
            {
                Name = "Fedelta",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/abilities/4/ab_all_3040160000_05.js",
                    ConstructorName = "mc_ab_all_3040160000_05",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040160000_05",
                            Path = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/abilities/4/ab_all_3040160000_05.png",
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
                            Id = StatusEffectLibrary.RemoveDebuff,
                            OnAllPartyMembers = true,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.Healing,
                        ExtraData = new Heal
                        {
                            HealingCap = long.MaxValue,
                            EffectTargettingType = EffectTargettingType.OnAllPartyMembers,
                            HpRecovered = long.MaxValue,
                        }.ToByteString(),
                    },
                },
                CanCast = (mariaTheresa, targetPositionInFrontline) =>
                {
                    foreach (var hero in mariaTheresa.Raid.Allies)
                    {
                        if (hero.IsAlive() && hero.PositionInFrontline < 4 && hero.HpPercentage >= 25)
                        {
                            return (false, "All allies must be in critical condition");
                        }
                    }

                    return (true, string.Empty);
                },
                ProcessEffects = (mariaTheresa, targetPositionInFrontline, raidActions) =>
                {
                    mariaTheresa.Raid.Allies.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            IsBuff = true,
                            TurnDuration = 5,
                            IsUndispellable = true,
                        },
                        raidActions,
                        (DevotionToJusticeId, ModifierLibrary.None, 0),
                        (DevotionToJusticeId + "/def_up", ModifierLibrary.FlatDefenseBoost, 100),
                        (DevotionToJusticeId + "/da_up", ModifierLibrary.FlatDoubleAttackRateBoost, 45),
                        (DevotionToJusticeId + "/ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 30),
                        (DevotionToJusticeId + "/dmg_cap_up", ModifierLibrary.FlatDamageCapBoost, 20));

                    mariaTheresa.Raid.Allies.ApplyStatusEffects(
                        new StatusEffectSnapshot
                        {
                            Id = DevotionToJusticeId + "/crit_rate_up",
                            IsBuff = true,
                            TurnDuration = 5,
                            IsUndispellable = true,
                            Strength = 100,
                            Modifier = ModifierLibrary.FlatCriticalHitRateBoost,
                            ExtraData = new CriticalHit
                            {
                                DamageMultiplier = 0.5,
                            }.ToByteString(),
                        },
                        raidActions);
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability AurumSword()
        {
            return new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/abilities/0/ab_all_3040160000_01.js",
                    ConstructorName = "mc_ab_all_3040160000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040160000_01",
                            Path = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/abilities/0/ab_all_3040160000_01.png",
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
                            Element = Element.Water,
                            HitNumber = 1,
                            DamageCap = 630_000,
                            DamageModifier = 3.5,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = UnrighteousnessId,
                            BaseAccuracy = 100,
                            TurnDuration = 3,
                            IsLocal = true,
                            OnAllEnemies = true,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (mariaTheresa, targetPositionInFrontline, raidActions) =>
                {
                    mariaTheresa.Raid.Enemies.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            BaseAccuracy = double.PositiveInfinity,
                            IsLocal = true,
                            IsUsedInternally = true,
                            TurnDuration = 3,
                            TriggerCondition = new StatusEffectSnapshot.Types.TriggerCondition
                            {
                                Type = StatusEffectSnapshot.Types.TriggerCondition.Types.Type.HasStatusEffect,
                                Data = UnrighteousnessId,
                            },
                        },
                        (UnrighteousnessId + "/def_down", ModifierLibrary.FlatDefenseBoost, -10),
                        (UnrighteousnessId + "/atk_down", ModifierLibrary.FlatAttackBoost, -10));
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability JusticeReversed()
        {
            return new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/abilities/3/ab_all_3040160000_04.js",
                    ConstructorName = "mc_ab_all_3040160000_04",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040160000_04",
                            Path = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/abilities/3/ab_all_3040160000_04.png",
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
                            Element = Element.Water,
                            HitNumber = 1,
                            DamageCap = 630_000,
                            DamageModifier = 3.5,
                        }.ToByteString(),
                    },
                    ApplyStatusEffect.FromTemplate(
                        new ApplyStatusEffect
                        {
                            BaseAccuracy = 100,
                            TurnDuration = 3,
                            IsStackable = true,
                            StackingCap = -30,
                            OnAllEnemies = true,
                        },
                        (StatusEffectLibrary.StackableAttackDownNpc, -10),
                        (StatusEffectLibrary.StackableDefenseDownNpc, -10)),
                },
            };
        }

        private static Ability TheEmpressUpright()
        {
            return new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/abilities/2/ab_all_3040160000_03.js",
                    ConstructorName = "mc_ab_all_3040160000_03",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040160000_03",
                            Path = "npc/ebbe21c2-f8ef-44e6-b947-b1323ef8c070/abilities/2/ab_all_3040160000_03.png",
                        },
                    },
                },
                ProcessEffects = (mariaTheresa, targetPositionInFrontline, raidActions) =>
                {
                    mariaTheresa.Raid.Allies.ApplyStatusEffects(
                        new StatusEffectSnapshot
                        {
                            Id = RighteousIndignationId,
                            IsBuff = true,
                            TurnDuration = int.MaxValue,
                            IsUndispellable = true,
                            ElementRestriction = Element.Water,
                        }, raidActions);

                    mariaTheresa.Raid.Allies.ApplyStatusEffects(
                        new StatusEffectSnapshot
                        {
                            Id = RighteousIndignationId + "/atk_up",
                            IsBuff = true,
                            TurnDuration = int.MaxValue,
                            IsUndispellable = true,
                            IsUsedInternally = true,
                            Modifier = ModifierLibrary.FlatAttackBoost,
                            Strength = 25,
                            ElementRestriction = Element.Water,
                        });

                    mariaTheresa.Raid.Allies.ApplyStatusEffects(
                        new StatusEffectSnapshot
                        {
                            Id = RighteousIndignationId + "/echo",
                            IsBuff = true,
                            TurnDuration = int.MaxValue,
                            IsUndispellable = true,
                            IsUsedInternally = true,
                            Modifier = ModifierLibrary.AdditionalDamage,
                            Strength = 20,
                            TriggerCondition = new StatusEffectSnapshot.Types.TriggerCondition
                            {
                                Type = StatusEffectSnapshot.Types.TriggerCondition.Types.Type.TargetHasStatusEffect,
                                Data = UnrighteousnessId,
                            },
                        });
                },
            };
        }
    }
}