// <copyright file="Narmaya.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Dark
{
    using System;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Hero.Abilities;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class Narmaya
    {
        public static Guid Id = Guid.Parse("4eb50ec0-501e-4a4d-9935-48f1456d6b3f");

        private const string DawnflyDance = "dawnfly_dance";
        private const string StackableAttackUp = "narmaya/atk_up";
        private const string StackableDefenseDown = "narmaya/def_down";
        private const string Butterfly = "narmaya/butterfly";
        private const string FortifiedVigor = "narmaya/fortified_vigor";
        private const string GlasswingWaltzId = "narmaya/glasswing_waltz";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Narmaya",
                Race = Race.Draph,
                Gender = Gender.Female,
                MaxAttack = 12200,
                AttackLevels = { 10240 },
                MaxHp = 1330,
                HpLevels = { 1120 },
                MaxLevel = 100,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Dark,
                WeaponProficiencies = { EquipmentType.Katana },
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
                    ExtendedMasteryPerks.LightDamageReduction,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DarkAttackBoost,
                    ExtendedMasteryPerks.Reflect,
                    ExtendedMasteryPerks.HostilityReduction,
                    ExtendedMasteryPerks.SupportSkill,
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/npc_3040063000_03.js",
                        ConstructorName = "mc_npc_3040063000_03",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040063000_03_a",
                                Path = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/npc_3040063000_03_a.png",
                            },
                            new ImageAsset
                            {
                                Name = "npc_3040063000_03_b",
                                Path = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/npc_3040063000_03_b.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/phit_3040063000.js",
                        ConstructorName = "mc_phit_3040063000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040063000",
                                Path = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/phit_3040063000.png",
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
                            JsAssetPath = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/nsp_3040063000_03_s2.js",
                            ConstructorName = "mc_nsp_3040063000_03_s2_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040063000_03_s2",
                                    Path = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/nsp_3040063000_03_s2.png",
                                },
                            },
                        },
                    },
                    ProcessEffects = (narmaya, raidActions) =>
                    {
                        if (narmaya.GlobalState[DawnflyDance].BooleanValue)
                        {
                            narmaya.ApplyStatusEffect(
                                new StatusEffectSnapshot
                                {
                                    Id = StackableAttackUp,
                                    Strength = 15,
                                    StackingCap = 50,
                                    IsStackable = true,
                                    TurnDuration = int.MaxValue,
                                    Modifier = ModifierLibrary.FlatAttackBoost,
                                },
                                raidActions);
                            if (narmaya.Hero.Rank == 5)
                            {
                                narmaya.ApplyStatusEffect(
                                    new StatusEffectSnapshot
                                    {
                                        Id = StatusEffectLibrary.DarkAttackUpNpc,
                                        Strength = 30,
                                        TurnDuration = 4,
                                    },
                                    raidActions);
                            }
                        }
                        else
                        {
                            narmaya.RemoveStatusEffect(StackableDefenseDown);
                            if (narmaya.Hero.Rank == 5)
                            {
                                narmaya.ApplyStatusEffect(
                                    new StatusEffectSnapshot
                                    {
                                        Id = StatusEffectLibrary.MirrorImage,
                                        Strength = 2,
                                        TurnDuration = int.MaxValue,
                                    },
                                    raidActions);
                            }
                        }
                    },
                },
                Abilities =
                {
                    ButterflyEffect(skillSealDuration: 2),
                    Transient(),
                    Kyogasuigetsu(),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 45,
                        Ability = Kyogasuigetsu(),
                        UpgradedAbilityIndex = 2,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = ButterflyEffect(skillSealDuration: 1),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 100,
                        Ability = GlasswingWaltz(),
                        UpgradedAbilityIndex = 3,
                    },
                },
                OnActionStart = (narmaya, raidActions) => ProcessPassiveEffects(narmaya),
                OnSetup = (narmaya, allies, loadout) =>
                {
                    narmaya.GlobalState.Add(DawnflyDance, TypedValue.FromBool(true));
                    if (narmaya.Hero.Level >= 90)
                    {
                        narmaya.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.Tenacity,
                                TurnDuration = int.MaxValue,
                            });
                    }
                },
                OnEnteringFrontline = (narmaya, raidActions) => ProcessPassiveEffects(narmaya),
                OnDeath = (narmaya, raidActions) =>
                {
                    foreach (var ally in narmaya.Raid.Allies)
                    {
                        if (ally.IsAlive() && ally.PositionInFrontline < 4)
                        {
                            ally.RemoveStatusEffect(FortifiedVigor);
                        }
                    }
                },
            };
        }

        private static Ability ButterflyEffect(uint skillSealDuration)
        {
            return new Ability
            {
                Name = "Butterfly Effect",
                Cooldown = 3,
                Type = Ability.Types.AbilityType.Support,
                ProcessEffects = (narmaya, targetPositionInFrontline, raidActions) =>
                {
                    narmaya.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = Butterfly,
                            Strength = 70,
                            AttackElementRestriction = Element.Superior,
                            Modifier = ModifierLibrary.AdditionalDamage,
                            TurnDuration = 4,
                        },
                        raidActions);

                    narmaya.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = "narmaya/skill_sealed",
                            TurnDuration = (int)skillSealDuration,
                            IsUndispellable = true,
                            Modifier = ModifierLibrary.CantUseSkills,
                        },
                        raidActions);

                    narmaya.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = StackableAttackUp,
                            Strength = 5,
                            IsStackable = true,
                            StackingCap = 50,
                            TurnDuration = int.MaxValue,
                            Modifier = ModifierLibrary.FlatAttackBoost,
                        },
                        raidActions);

                    narmaya.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = StackableDefenseDown,
                            Strength = -7,
                            IsStackable = true,
                            StackingCap = -35,
                            TurnDuration = int.MaxValue,
                            Modifier = ModifierLibrary.FlatDefenseBoost,
                            BaseAccuracy = double.MaxValue,
                        },
                        raidActions);

                    if (narmaya.GlobalState[DawnflyDance].BooleanValue)
                    {
                        narmaya.ChangeForm(
                            new ModelMetadata
                            {
                                JsAssetPath = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/npc_3040063000_03_f1.js",
                                ConstructorName = "mc_npc_3040063000_03_f1",
                                ImageAssets =
                                {
                                    new ImageAsset
                                    {
                                        Name = "npc_3040063000_03_f1_a",
                                        Path = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/npc_3040063000_03_f1_a.png",
                                    },
                                    new ImageAsset
                                    {
                                        Name = "npc_3040063000_03_f1_b",
                                        Path = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/npc_3040063000_03_f1_b.png",
                                    },
                                },
                            },
                            raidActions,
                            new ModelMetadata
                            {
                                JsAssetPath = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/phit_3040063000_03_f1.js",
                                ConstructorName = "mc_phit_3040063000_03_f1_effect",
                                ImageAssets =
                                {
                                    new ImageAsset
                                    {
                                        Name = "phit_3040063000_03_f1",
                                        Path = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/phit_3040063000_03_f1.png",
                                    },
                                },
                            },
                            new SpecialAbility
                            {
                                ModelMetadata =
                                {
                                    new ModelMetadata
                                    {
                                        JsAssetPath = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/nsp_3040063000_03_s2.js",
                                        ConstructorName = "mc_nsp_3040063000_03_s2_special",
                                        ImageAssets =
                                        {
                                            new ImageAsset
                                            {
                                                Name = "nsp_3040063000_03_s2",
                                                Path = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/nsp_3040063000_03_s2.png",
                                            },
                                        },
                                    },
                                },
                                HitCount = { 1 },
                            });

                        narmaya.GlobalState[DawnflyDance].BooleanValue = false;
                    }
                    else
                    {
                        narmaya.ChangeForm(
                            new ModelMetadata
                            {
                                JsAssetPath = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/npc_3040063000_03.js",
                                ConstructorName = "mc_npc_3040063000_03",
                                ImageAssets =
                                {
                                    new ImageAsset
                                    {
                                        Name = "npc_3040063000_03_a",
                                        Path = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/npc_3040063000_03_a.png",
                                    },
                                    new ImageAsset
                                    {
                                        Name = "npc_3040063000_03_b",
                                        Path = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/npc_3040063000_03_b.png",
                                    },
                                },
                            },
                            raidActions,
                            new ModelMetadata
                            {
                                JsAssetPath = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/phit_3040063000.js",
                                ConstructorName = "mc_phit_3040063000_effect",
                                ImageAssets =
                                {
                                    new ImageAsset
                                    {
                                        Name = "phit_3040063000",
                                        Path = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/phit_3040063000.png",
                                    },
                                },
                            },
                            new SpecialAbility
                            {
                                ModelMetadata =
                                {
                                    new ModelMetadata
                                    {
                                        JsAssetPath = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/nsp_3040063000_03_f1_s2.js",
                                        ConstructorName = "mc_nsp_3040063000_03_f1_s2_special",
                                        ImageAssets =
                                        {
                                            new ImageAsset
                                            {
                                                Name = "nsp_3040063000_03_f1_s2",
                                                Path = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/model/0/nsp_3040063000_03_f1_s2.png",
                                            },
                                        },
                                    },
                                },
                                HitCount = { 4 },
                            });

                        narmaya.GlobalState[DawnflyDance].BooleanValue = true;
                    }
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Transient()
        {
            return new Ability
            {
                Name = "Transient",
                Cooldown = 6,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/abilities/0/ab_3040063000_01.js",
                    ConstructorName = "mc_ab_3040063000_01_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040063000_01",
                            Path = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/abilities/0/ab_3040063000_01.png",
                        },
                    },
                },
                ProcessEffects = (narmaya, targetPositionInFrontline, raidActions) =>
                {
                    new MultihitDamage
                    {
                        Element = Element.Dark,
                        DamageModifier = (narmaya.Hero.Level >= 95 ? 4 : 3) + (ThreadSafeRandom.NextDouble() * 0.5),
                        DamageCap = narmaya.Hero.Level >= 95 ? 480000 : 430000,
                        HitNumber = 1,
                    }.ProcessEffects(narmaya, targetPositionInFrontline, raidActions);

                    var hasGlasswingWaltzEffect = narmaya.GetStatusEffect(GlasswingWaltzId) != null;
                    if (narmaya.GlobalState[DawnflyDance].BooleanValue || hasGlasswingWaltzEffect)
                    {
                        narmaya.ApplyStatusEffectsFromTemplate(
                            new StatusEffectSnapshot
                            {
                                TurnDuration = 3,
                            },
                            raidActions,
                            (StatusEffectLibrary.DoubleAttackRateUpNpc, ModifierLibrary.FlatDoubleAttackRateBoost, narmaya.Hero.Level >= 95 ? double.PositiveInfinity : 25),
                            (StatusEffectLibrary.TripleAttackRateUpNpc, ModifierLibrary.FlatTripleAttackRateBoost, narmaya.Hero.Level >= 95 ? 10 : 5));
                    }

                    if (!narmaya.GlobalState[DawnflyDance].BooleanValue || hasGlasswingWaltzEffect)
                    {
                        var target = narmaya.ResolveEnemyTarget(targetPositionInFrontline);
                        if (target != null && target.IsAlive())
                        {
                            var strength = -25;
                            if (narmaya.Hero.Rank < 95)
                            {
                                if (target.ChargeDiamonds == 0)
                                {
                                    strength = -7;
                                }
                                else if (target.ChargeDiamonds == 1)
                                {
                                    strength = -14;
                                }
                                else if (target.ChargeDiamonds == 2)
                                {
                                    strength = -21;
                                }
                                else
                                {
                                    strength = -25;
                                }
                            }

                            target.ApplyStatusEffect(
                                new StatusEffectSnapshot
                                {
                                    Id = StatusEffectLibrary.DefenseDownNpc,
                                    RemainingDurationInSeconds = 180,
                                    Strength = strength,
                                    BaseAccuracy = 95,
                                },
                                raidActions);
                        }
                    }

                    if (hasGlasswingWaltzEffect)
                    {
                        narmaya.RemoveStatusEffect(GlasswingWaltzId);
                    }
                },
                AnimationName = "ab_motion",
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
            };
        }

        private static Ability Kyogasuigetsu()
        {
            return new Ability
            {
                Name = "Kyogasuigetsu",
                Cooldown = 6,
                Type = Ability.Types.AbilityType.Support,
                ProcessEffects = (narmaya, targetPositionInFrontline, raidActions) =>
                {
                    var hasGlasswingWaltzEffect = narmaya.GetStatusEffect(GlasswingWaltzId) != null;
                    if (narmaya.GlobalState[DawnflyDance].BooleanValue || hasGlasswingWaltzEffect)
                    {
                        SupportAbilities.Delay(100).Cast(narmaya, targetPositionInFrontline, raidActions, doNotRenderCastAbilityEffect: true);
                    }

                    if (!narmaya.GlobalState[DawnflyDance].BooleanValue || hasGlasswingWaltzEffect)
                    {
                        new Ability
                        {
                            ModelMetadata = new ModelMetadata
                            {
                                ConstructorName = "mc_ab_4200_effect",
                                JsAssetPath = "npc/26bf3539-9348-426d-ae81-2e4fa3aa0be8/abilities/1/ab_4200.js",
                                ImageAssets =
                                {
                                    new ImageAsset
                                    {
                                        Name = "ab_4200",
                                        Path = "npc/26bf3539-9348-426d-ae81-2e4fa3aa0be8/abilities/1/ab_4200.png",
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
                                        Id = StatusEffectLibrary.AttackUpNpc,
                                        Strength = 20,
                                        TurnDuration = 1,
                                        EffectTargettingType = EffectTargettingType.OnSelf,
                                    }.ToByteString(),
                                },
                                new AbilityEffect
                                {
                                    Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                                    ExtraData = new ApplyStatusEffect
                                    {
                                        Id = StatusEffectLibrary.AssassinStrike,
                                        Strength = 280,
                                        TurnDuration = 1,
                                        EffectTargettingType = EffectTargettingType.OnSelf,
                                        ExtraData = new AssassinStrike
                                        {
                                            DamageCap = 1_160_000,
                                            ActivationCondition = AssassinStrike.Types.ActivationCondition.TargetInOverdriveMode,
                                            ChargeAttackDamageBoost = 280.0 / 3,
                                            ChargeAttackDamageCap = 2_640_000,
                                        }.ToByteString(),
                                    }.ToByteString(),
                                },
                            },
                            ShouldRepositionSpriteAnimation = true,
                        }.Cast(narmaya, raidActions, doNotRenderCastAbilityEffect: true);
                    }

                    if (hasGlasswingWaltzEffect)
                    {
                        narmaya.RemoveStatusEffect(GlasswingWaltzId);
                    }
                },
            };
        }

        private static Ability GlasswingWaltz()
        {
            return new Ability
            {
                Name = "Glasswing Waltz",
                InitialCooldown = 3,
                Cooldown = 10,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/abilities/2/ab_3040063000_03.js",
                    ConstructorName = "mc_ab_3040063000_03_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040063000_03",
                            Path = "npc/4eb50ec0-501e-4a4d-9935-48f1456d6b3f/abilities/2/ab_3040063000_03.png",
                        },
                    },
                },
                Effects =
                {
                    ApplyStatusEffect.FromTemplate(
                        new ApplyStatusEffect
                        {
                            TurnDuration = int.MaxValue,
                            EffectTargettingType = EffectTargettingType.OnSelf,
                        },
                        (GlasswingWaltzId, 0),
                        (StatusEffectLibrary.NextChargeAttackDamageBoost, 60),
                        (StatusEffectLibrary.NextChargeAttackDamageCapBoost, 30)),
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = StatusEffectLibrary.Uplifted,
                            Strength = 10,
                            EffectTargettingType = EffectTargettingType.OnSelf,
                            TurnDuration = 3,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (narmaya, targetPositionInFrontline, raidActions) => { },
                AnimationName = "ab_motion",
                ShouldRepositionSpriteAnimation = true,
            };
        }

        private static void ProcessPassiveEffects(EntitySnapshot narmaya)
        {
            if (!narmaya.IsAlive() || narmaya.PositionInFrontline >= 4)
            {
                return;
            }

            foreach (var ally in narmaya.Raid.Allies)
            {
                if (!ally.IsAlive() || ally.PositionInFrontline >= 4 || ally.Hero.Race != Race.Draph || ally.Hero.Race != Race.Primal || ally.Hero.Race != Race.Unknow)
                {
                    continue;
                }

                ally.ApplyStatusEffect(new StatusEffectSnapshot
                {
                    Id = FortifiedVigor,
                    TurnDuration = 1,
                    IsUsedInternally = true,
                    IsUndispellable = true,
                    Modifier = ModifierLibrary.AttackBoost,
                    Strength = 10,
                });
            }
        }
    }
}