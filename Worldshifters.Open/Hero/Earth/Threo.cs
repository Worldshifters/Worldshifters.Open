// <copyright file="Threo.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Earth
{
    using System;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Hero.Abilities;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;
    using static Worldshifters.Data.Raid.StatusEffectSnapshot.Types;

    public static class Threo
    {
        public static Guid Id = Guid.Parse("612d0c88-d7ef-43ec-bf20-7d630c7c5200");

        private const string Wrath = "threo/wrath";
        private const string Agitation = "threo/agitation";

        private static readonly ModelMetadata AxeFormModel = new ModelMetadata
        {
            JsAssetPath = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/model/0/npc_3040032000_03.js",
            ConstructorName = "mc_npc_3040032000_03",
            ImageAssets =
            {
                new ImageAsset
                {
                    Name = "npc_3040032000_03",
                    Path = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/model/0/npc_3040032000_03.png",
                },
            },
        };

        private static readonly ModelMetadata AxeFormOnHitModel = new ModelMetadata
        {
            JsAssetPath = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/model/0/phit_3040032000.js",
            ConstructorName = "mc_phit_3040032000_effect",
            ImageAssets =
            {
                new ImageAsset
                {
                    Name = "phit_3040032000",
                    Path = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/model/0/phit_3040032000.png",
                },
            },
        };

        private static readonly ModelMetadata AxeFormChargeAttackModel = new ModelMetadata
        {
            JsAssetPath = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/model/0/nsp_3040032000_03.js",
            ConstructorName = "mc_nsp_3040032000_03_special",
            ImageAssets =
            {
                new ImageAsset
                {
                    Name = "nsp_3040032000_03",
                    Path = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/model/0/nsp_3040032000_03.png",
                },
            },
        };

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Threo",
                Races = { Race.Draph },
                Gender = Gender.Female,
                MaxAttack = 13333,
                AttackLevels = { 11333 },
                MaxHp = 1833,
                HpLevels = { 1533 },
                MaxLevel = 100,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Earth,
                WeaponProficiencies = { EquipmentType.Axe, EquipmentType.Sword },
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
                    ExtendedMasteryPerks.AttackBoostAndDefenseDown,
                    ExtendedMasteryPerks.AttackBoostAndDefenseDown,
                    ExtendedMasteryPerks.ChargeAttackDamageBoost,
                    ExtendedMasteryPerks.ChargeAttackDamageCapBoost,
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
                    AxeFormModel,
                },
                OnHitEffectModelMetadata =
                {
                    AxeFormOnHitModel,
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = string.Empty,
                    HitCount = { 1 },
                    ModelMetadata =
                    {
                        AxeFormChargeAttackModel,
                    },
                    ProcessEffects = (threo, raidActions) =>
                    {
                        if (threo.GlobalState["::axe_form"].BooleanValue)
                        {
                            threo.GlobalState["::axe_form"].BooleanValue = false;
                            threo.ApplyStatusEffect(
                                new StatusEffectSnapshot
                                {
                                    Id = StatusEffectLibrary.EarthAttackUpNpc,
                                    Strength = 20,
                                    TurnDuration = 4,
                                },
                                raidActions);

                            threo.PlayAnimation("change_1", raidActions);
                            threo.ChangeForm(
                                new ModelMetadata
                                {
                                    JsAssetPath = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/model/0/npc_3040032000_03_f1.js",
                                    ConstructorName = "mc_npc_3040032000_03_f1",
                                    ImageAssets =
                                    {
                                        new ImageAsset
                                        {
                                            Name = "npc_3040032000_03_f1",
                                            Path = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/model/0/npc_3040032000_03_f1.png",
                                        },
                                    },
                                },
                                raidActions,
                                onHitEffectModel: new ModelMetadata
                                {
                                    JsAssetPath = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/model/0/phit_3040032000_03_f1.js",
                                    ConstructorName = "mc_phit_3040032000_03_f1_effect",
                                    ImageAssets =
                                    {
                                        new ImageAsset
                                        {
                                            Name = "phit_3040032000_03_f1",
                                            Path = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/model/0/phit_3040032000_03_f1.png",
                                        },
                                    },
                                },
                                specialAbility: new SpecialAbility
                                {
                                    HitCount = { 2 },
                                    ModelMetadata =
                                    {
                                        new ModelMetadata
                                        {
                                            JsAssetPath = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/model/0/nsp_3040032000_03_f1.js",
                                            ConstructorName = "mc_nsp_3040032000_03_f1_special",
                                            ImageAssets =
                                            {
                                                new ImageAsset
                                                {
                                                    Name = "nsp_3040032000_03_f1",
                                                    Path = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/model/0/nsp_3040032000_03_f1.png",
                                                },
                                            },
                                        },
                                    },
                                    ShouldRepositionSpriteAnimationOnTarget = true,
                                });

                            threo.ChangeAbilityIcon(1, "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/abilities/1a.png");
                        }
                        else
                        {
                            threo.GlobalState["::axe_form"].BooleanValue = true;
                            var currentTarget = threo.ResolveEnemyTarget(threo.CurrentTargetPositionInFrontline);
                            if (currentTarget.IsAlive())
                            {
                                MeteorThrust().Cast(threo, currentTarget.PositionInFrontline, raidActions);
                            }

                            threo.PlayAnimation("change_2", raidActions);
                            threo.ChangeForm(
                                AxeFormModel,
                                raidActions,
                                onHitEffectModel: AxeFormOnHitModel,
                                specialAbility: new SpecialAbility
                                {
                                    HitCount = { 1 },
                                    ModelMetadata =
                                    {
                                        AxeFormChargeAttackModel,
                                    },
                                    ShouldRepositionSpriteAnimationOnTarget = true,
                                });

                            threo.ChangeAbilityIcon(1, "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/abilities/1.png");
                        }
                    },
                    ShouldRepositionSpriteAnimationOnTarget = true,
                },
                Abilities =
                {
                    VorpalRage(),
                    BerserkForge(cooldown: 7),
                    GroundZero(cooldown: 8),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 85,
                        Ability = BerserkForge(cooldown: 6),
                        UpgradedAbilityIndex = 1,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 95,
                        Ability = GroundZero(cooldown: 7),
                        UpgradedAbilityIndex = 2,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 100,
                        Ability = ThreeTigerBlessing(0),
                        UpgradedAbilityIndex = 3,
                    },
                },
                OnAttackEnd = (threo, attackResult, raidActions) =>
                {
                    if (!threo.IsAlive() ||
                        threo.PositionInFrontline >= 4 ||
                        (attackResult != EntitySnapshot.AttackResult.Single &&
                         attackResult != EntitySnapshot.AttackResult.Double &&
                         attackResult != EntitySnapshot.AttackResult.Triple &&
                         attackResult != EntitySnapshot.AttackResult.MultiAttack))
                    {
                        return;
                    }

                    var supportSkillRank = threo.Hero.GetSupportSkillRank();
                    if (supportSkillRank > 0 && ThreadSafeRandom.NextDouble() < (1 + supportSkillRank) * 0.025)
                    {
                        threo.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = "threo/atk_up",
                                TurnDuration = int.MaxValue,
                                IsStackable = true,
                                Strength = 10,
                                Modifier = ModifierLibrary.FlatAttackBoost,
                                StackingCap = 30,
                            },
                            raidActions);
                    }
                },
                OnSetup = (threo, allies, loadout) =>
                {
                    threo.GlobalState.Add("::axe_form", TypedValue.FromBool(true));
                    if (threo.Hero.Level >= 95)
                    {
                        // 20% boost to damage against Water foes, non stackable with Seraphic effects from weapons
                        threo.OverrideWeaponSeraphicModifier(20);
                    }
                },
            };
        }

        private static Ability GroundZero(uint cooldown)
        {
            return new Ability
            {
                Name = "Ground Zero",
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/abilities/0/ab_all_3040032000_01.js",
                    ConstructorName = "mc_ab_all_3040032000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040032000_01",
                            Path = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/abilities/0/ab_all_3040032000_01.png",
                        },
                    },
                },
                ProcessEffects = (threo, targetPositionInFrontline, raidActions) =>
                {
                    var consumedHp = (long)(threo.Hp * 0.99);
                    if (threo.Hp == consumedHp)
                    {
                        consumedHp = Math.Max(0, consumedHp - 1);
                    }

                    threo.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = StatusEffectLibrary.Shield,
                            Strength = 3000,
                            TurnDuration = int.MaxValue,
                        },
                        raidActions);
                    threo.DealRawDamage(consumedHp, Element.Null, raidActions, countAsDamage: false);
                    long plainDamage;
                    if (threo.Hero.Level < 95)
                    {
                        plainDamage = (Math.Min(7000, consumedHp) * 100) +
                                      (Math.Min(1000, Math.Max(0, consumedHp - 7000)) * 70) +
                                      (Math.Min(1000, Math.Max(0, consumedHp - 8000)) * 40) +
                                      (Math.Min(1000, Math.Max(0, consumedHp - 9000)) * 10) +
                                      (Math.Max(0, consumedHp - 10000) * 1);
                    }
                    else
                    {
                        plainDamage = (Math.Min(10500, consumedHp) * 100) +
                                      (Math.Min(1500, Math.Max(0, consumedHp - 10500)) * 70) +
                                      (Math.Min(1500, Math.Max(0, consumedHp - 12000)) * 40) +
                                      (Math.Min(1500, Math.Max(0, consumedHp - 13500)) * 10) +
                                      (Math.Max(0, consumedHp - 15000) * 1);
                    }

                    foreach (var enemy in threo.Raid.Enemies)
                    {
                        enemy.DealRawDamage(plainDamage, Element.Null, raidActions);
                    }

                    if (threo.Hero.Level >= 95)
                    {
                        threo.Raid.Enemies.ApplyStatusEffects(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.EarthDefenseDownNpc,
                                Strength = -25,
                                BaseAccuracy = 100,
                                RemainingDurationInSeconds = 180,
                            },
                            raidActions);
                    }
                },
                AnimationName = "attack",
            };
        }

        private static Ability ThreeTigerBlessing(uint cooldown)
        {
            return new Ability
            {
                Name = "Three-Tiger's Blessing",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/abilities/2/ab_3040032000_02.js",
                    ConstructorName = "mc_ab_3040032000_02_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040032000_02",
                            Path = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/abilities/2/ab_3040032000_02.png",
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
                            Id = StatusEffectLibrary.Uplifted,
                            TurnDuration = 3,
                            EffectTargettingType = EffectTargettingType.OnSelf,
                            Strength = double.MaxValue,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (threo, targetPositionInFrontline, raidActions) =>
                {
                    var ignition = SupportAbilities.Ignition(int.MaxValue);
                    ignition.DoNotRenderAbilityCastEffect = true;
                    ignition.Cast(threo, raidActions);

                    threo.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = "threo/tiger_blessing",
                            Modifier = ModifierLibrary.FlatChargeAttackDamageCapBoost,
                            Strength = 100,
                        },
                        raidActions);

                    threo.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = "threo/tiger_blessing_atk_up",
                            Modifier = ModifierLibrary.FlatAttackBoost,
                            Strength = 280,
                            IsUsedInternally = true,
                            TriggerCondition = new TriggerCondition
                            {
                                Type = TriggerCondition.Types.Type.HasStatusEffect,
                                Data = "threo/tiger_blessing",
                            },
                        });
                },
                AnimationName = "attack",
                ShouldRepositionSpriteAnimation = true,
            };
        }

        private static Ability VorpalRage()
        {
            return new Ability
            {
                Name = "Vorpal Rage",
                Cooldown = 4,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/abilities/4/ab_3040032000_04.js",
                    ConstructorName = "mc_ab_3040032000_04_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040032000_04",
                            Path = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/abilities/4/ab_3040032000_04.png",
                        },
                    },
                },
                ProcessEffects = (threo, targetPositionInFrontline, raidActions) =>
                {
                    new MultihitDamage
                    {
                        Element = Element.Earth,
                        DamageModifier = (threo.Hero.Level >= 55 ? 2 : 1.5) + (ThreadSafeRandom.NextDouble() * 0.5),
                        DamageCap = 620_000,
                        HitNumber = 1,
                    }.ProcessEffects(threo, targetPositionInFrontline, raidActions);

                    // TODO: drain
                    if (threo.GlobalState["::axe_form"].BooleanValue)
                    {
                        threo.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = Wrath,
                                TurnDuration = 5,
                            },
                            raidActions);
                        threo.Heal(threo.HpPercentage < 25 ? 3000 : 1500, raidActions);
                        threo.ApplyStatusEffectsFromTemplate(
                            new StatusEffectSnapshot
                            {
                                IsUsedInternally = true,
                                TurnDuration = 5,
                                TriggerCondition = new TriggerCondition
                                {
                                    Type = TriggerCondition.Types.Type.HasStatusEffect,
                                    Data = Wrath,
                                },
                            },
                            (Wrath + "/da_up", ModifierLibrary.FlatDoubleAttackRateBoost, 25),
                            (Wrath + "/ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 15));

                        if (threo.Hero.Level >= 90)
                        {
                            threo.ApplyStatusEffect(new StatusEffectSnapshot
                            {
                                Id = Wrath + "/crit",
                                IsUsedInternally = true,
                                TurnDuration = 5,
                                TriggerCondition = new TriggerCondition
                                {
                                    Type = TriggerCondition.Types.Type.HasStatusEffect,
                                    Data = Wrath,
                                },
                                Strength = 30,
                                Modifier = ModifierLibrary.FlatCriticalHitRateBoost,
                                ExtraData = new CriticalHit
                                {
                                    DamageMultiplier = 0.5,
                                }.ToByteString(),
                            });
                        }
                    }
                    else if (threo.GetStatusEffect(Wrath) != null)
                    {
                        threo.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = Agitation,
                                TurnDuration = 5,
                            },
                            raidActions);
                        threo.ApplyStatusEffectsFromTemplate(
                            new StatusEffectSnapshot
                            {
                                IsUsedInternally = true,
                                TurnDuration = 5,
                                TriggerCondition = new TriggerCondition
                                {
                                    Type = TriggerCondition.Types.Type.HasStatusEffect,
                                    Data = Agitation,
                                },
                            },
                            (Agitation + "/ca_up", ModifierLibrary.FlatChargeAttackDamageBoost, 15),
                            (Agitation + "/cb_up", ModifierLibrary.FlatChainBurstDamageBoost, 15));

                        if (threo.Hero.Level >= 90)
                        {
                            threo.ApplyStatusEffect(new StatusEffectSnapshot
                            {
                                Id = Agitation + "/echo",
                                IsUsedInternally = true,
                                TurnDuration = 5,
                                TriggerCondition = new TriggerCondition
                                {
                                    Type = TriggerCondition.Types.Type.HasStatusEffect,
                                    Data = Wrath,
                                },
                                Strength = 70,
                                Modifier = ModifierLibrary.AdditionalDamage,
                                AttackElementRestriction = Element.Earth,
                            });
                        }
                    }
                },
                AnimationName = "attack",
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
            };
        }

        private static Ability BerserkForge(uint cooldown)
        {
            return new Ability
            {
                Name = "Berserk Forge",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/abilities/5/ab_3030224000_02.js",
                    ConstructorName = "mc_ab_3030224000_02_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3030224000_02",
                            Path = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/abilities/5/ab_3030224000_02.png",
                        },
                    },
                },
                ProcessEffects = (threo, targetPositionInFrontline, raidActions) =>
                {
                    if (threo.GlobalState["::axe_form"].BooleanValue)
                    {
                        threo.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.DodgeAndCounter,
                                TurnDuration = 3,
                                Strength = 3,
                                ExtraData = new Counter
                                {
                                    DamageModifier = threo.Hero.Level >= 75 ? 2 : 1.5,
                                    HitCount = 3,
                                }.ToByteString(),
                            },
                            raidActions);

                        if (threo.Hero.Level >= 85)
                        {
                            threo.ApplyStatusEffect(
                                new StatusEffectSnapshot
                                {
                                    Id = "threo/atk_up_ab",
                                    TurnDuration = 3,
                                    Strength = 60,
                                },
                                raidActions);
                        }
                    }
                    else if (threo.GetStatusEffect(Wrath) != null)
                    {
                        threo.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.JammedNpc,
                                Strength = threo.Hero.Level >= 75 ? 125 : 100,
                                ExtraData = new LinearAttackBoost
                                {
                                    StrengthAt1Hp = threo.Hero.Level >= 75 ? 247.5 : 188,
                                    StrengthAtFullHp = 0,
                                }.ToByteString(),
                            },
                            raidActions);

                        if (threo.Hero.Level >= 85)
                        {
                            threo.ApplyStatusEffect(
                                new StatusEffectSnapshot
                                {
                                    Id = StatusEffectLibrary.HostilityDown,
                                    Strength = -5,
                                },
                                raidActions);
                        }
                    }
                },
                AnimationName = "attack",
                ShouldRepositionSpriteAnimation = true,
            };
        }

        private static Ability MeteorThrust()
        {
            return new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/abilities/3/ab_3040032000_03.js",
                    ConstructorName = "mc_ab_3040032000_03_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040032000_03",
                            Path = "npc/612d0c88-d7ef-43ec-bf20-7d630c7c5200/abilities/3/ab_3040032000_03.png",
                        },
                    },
                },
                ProcessEffects = (threo, targetPositionInFrontline, raidActions) =>
                {
                    var enemy = threo.Raid.Enemies.AtPosition(threo.CurrentTargetPositionInFrontline);
                    if (enemy.IsAlive())
                    {
                        enemy.DealRawDamage(threo.Hero.Rank >= 5 ? 1_999_998 : 999_999, Element.Null, raidActions);
                    }
                },
                ShouldRepositionSpriteAnimation = true,
                DoNotRenderAbilityCastEffect = true,
                RepositionOnTarget = true,
            };
        }
    }
}