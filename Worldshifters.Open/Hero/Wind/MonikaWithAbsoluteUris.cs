// <copyright file="MonikaWithAbsoluteUris.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Wind
{
    using System;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class MonikaWithAbsoluteUris
    {
        public static Guid Id = Guid.Parse("557e49c1-bedb-46e0-bb73-b0f2594e32e7");

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Monika",
                Races = { Race.Human },
                Gender = Gender.Female,
                MaxAttack = 9000,
                MaxHp = 1400,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Wind,
                WeaponProficiencies = { EquipmentType.Sword, EquipmentType.Katana },
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
                    ExtendedMasteryPerks.SkillDamageCapBoost,
                    ExtendedMasteryPerks.ChargeAttackDamageCapBoost,
                    ExtendedMasteryPerks.DebuffSuccessRateBoost,
                    ExtendedMasteryPerks.HealingBoost,
                    ExtendedMasteryPerks.SupportSkill,
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/model/0/npc_3040238000_01.js",
                        ConstructorName = "mc_npc_3040238000_01",
                        IsAbsolutePath = true,
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040238000_01",
                                Path = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/model/0/npc_3040238000_01.png",
                                IsAbsolutePath = true,
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/model/0/phit_3040238000.js",
                        ConstructorName = "mc_phit_3040238000_effect",
                        IsAbsolutePath = true,
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040238000",
                                Path = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/model/0/phit_3040238000.png",
                                IsAbsolutePath = true,
                            },
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    HitCount = { 5 },

                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/model/0/nsp_3040238000_01_s2.js",
                            ConstructorName = "mc_nsp_3040238000_01_s2_special",
                            IsAbsolutePath = true,
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040238000_01_s2_a",
                                    Path = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/model/0/nsp_3040238000_01_s2_a.png",
                                    IsAbsolutePath = true,
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040238000_01_s2_b",
                                    Path = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/model/0/nsp_3040238000_01_s2_b.png",
                                    IsAbsolutePath = true,
                                },
                            },
                        },
                    },
                    ProcessEffects = (monika, raidActions) => { Violetshock().Cast(monika, raidActions); },
                },
                Abilities =
                {
                    FlashAndThunder(),
                    FieldDressing(),
                    WindsOfWhiteWings(),
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 45,
                        Ability = ThunderclapBurst(),
                        UpgradedAbilityIndex = 3,
                    },
                },
                OnActionStart = (monika, _, raidActions) =>
                {
                },
                OnTurnEnd = (monika, raidActions) =>
                {
                    if (!monika.IsAlive() || monika.PositionInFrontline >= 4)
                    {
                        return;
                    }

                    if (monika.DodgedDamageOrDebuff)
                    {
                        Violetshock().Cast(monika, raidActions);
                    }
                },
                OnAbilityEnd = (monika, ability, raidActions) =>
                {
                    monika.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            TurnDuration = 1,
                        },
                        raidActions,
                        (StatusEffectLibrary.TripleAttackRateUpNpc, ModifierLibrary.FlatTripleAttackRateBoost, double.MaxValue),
                        (StatusEffectLibrary.HostilityUp, ModifierLibrary.HostilityBoost, 15),
                        (StatusEffectLibrary.DodgeRateBoostNpc, ModifierLibrary.DodgeRateBoost, 25));
                },
            };
        }

        private static Ability FlashAndThunder()
        {
            return new Ability
            {
                Name = "Flash and Thunder",
                Cooldown = 3,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/abilities/1/ab_3040238000_01.js",
                    ConstructorName = "mc_ab_3040238000_01_effect",
                    IsAbsolutePath = true,
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040238000_01",
                            Path = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/abilities/1/ab_3040238000_01.png",
                            IsAbsolutePath = true,
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
                            Element = Element.Wind,
                            DamageModifier = 5,
                            HitNumber = 1,
                            DamageCap = 630_000,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (monika, targetPositionInFrontline, raidActions) =>
                {
                    if (!monika.GlobalState.TryGetValue("monika/ab_1/cast_count", out var castCount))
                    {
                        monika.GlobalState.Add("monika/ab_1/cast_count", TypedValue.FromLong(0));
                    }

                    monika.GlobalState["monika/ab_1/cast_count"].IntegerValue += 1;

                    var echoStrength = 40;
                    var duration = 3;
                    if (monika.GlobalState["monika/ab_1/cast_count"].IntegerValue == 2)
                    {
                        echoStrength = 60;
                        duration = 4;
                    }
                    else if (monika.GlobalState["monika/ab_1/cast_count"].IntegerValue >= 3)
                    {
                        echoStrength = 80;
                        duration = 5;
                    }

                    monika.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = StatusEffectLibrary.AdditionalSuperiorDamageNpc,
                            TurnDuration = duration,
                            Strength = echoStrength,
                        },
                        raidActions);

                    for (var i = 0; i < monika.AbilityCooldowns.Count; ++i)
                    {
                        monika.AbilityCooldowns[i] = 3;
                    }
                },
                AnimationName = "ab_motion",
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
            };
        }

        private static Ability FieldDressing()
        {
            return new Ability
            {
                Name = "Field Dressing",
                Cooldown = 3,
                Type = Ability.Types.AbilityType.Healing,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/abilities/2/ab_all_3040238000_02.js",
                    ConstructorName = "mc_ab_all_3040238000_02",
                    IsAbsolutePath = true,
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040238000_02",
                            Path = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/abilities/2/ab_all_3040238000_02.png",
                            IsAbsolutePath = true,
                        },
                    },
                },
                ProcessEffects = (monika, targetPositionInFrontline, raidActions) =>
                {
                    if (!monika.GlobalState.TryGetValue("monika/ab_2/cast_count", out var castCount))
                    {
                        monika.GlobalState.Add("monika/ab_2/cast_count", TypedValue.FromLong(0));
                    }

                    monika.GlobalState["monika/ab_2/cast_count"].IntegerValue += 1;

                    var healingCap = 2000;
                    if (monika.GlobalState["monika/ab_2/cast_count"].IntegerValue == 2)
                    {
                        healingCap = 2500;
                    }
                    else if (monika.GlobalState["monika/ab_2/cast_count"].IntegerValue >= 3)
                    {
                        healingCap = 3000;
                    }

                    foreach (var ally in monika.Raid.Allies)
                    {
                        ally.Heal(
                            new Heal
                            {
                                EffectTargettingType = EffectTargettingType.OnAllPartyMembers,
                                HealingCap = healingCap,
                                HpPercentageRecovered = 20,
                            },
                            raidActions,
                            monika);

                        ally.RemoveDebuff();
                    }

                    for (var i = 0; i < monika.AbilityCooldowns.Count; ++i)
                    {
                        monika.AbilityCooldowns[i] = 3;
                    }
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability WindsOfWhiteWings()
        {
            return new Ability
            {
                Name = "Winds of White Wings",
                Cooldown = 3,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/abilities/3/ab_all_3040238000_03.js",
                    ConstructorName = "mc_ab_all_3040238000_03",
                    IsAbsolutePath = true,
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040238000_03",
                            Path = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/abilities/3/ab_all_3040238000_03.png",
                            IsAbsolutePath = true,
                        },
                    },
                },
                ProcessEffects = (monika, targetPositionInFrontline, raidActions) =>
                {
                    if (!monika.GlobalState.TryGetValue("monika/ab_3/cast_count", out var castCount))
                    {
                        monika.GlobalState.Add("monika/ab_3/cast_count", TypedValue.FromLong(0));
                    }

                    monika.GlobalState["monika/ab_3/cast_count"].IntegerValue += 1;

                    monika.Raid.Allies.ApplyStatusEffects(
                        new StatusEffectSnapshot
                        {
                            Id = StatusEffectLibrary.CriticalHitRateBoostForWindAlliesNpc,
                            Strength = 70,
                            TurnDuration = 3,
                            ExtraData = new CriticalHit
                            {
                                DamageMultiplier = 0.3,
                            }.ToByteString(),
                        },
                        raidActions);

                    if (monika.GlobalState["monika/ab_3/cast_count"].IntegerValue >= 2)
                    {
                        monika.Raid.Allies.ApplyStatusEffects(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.DamageBoostedOnCriticalHitNpc,
                                Strength = 1,
                                TurnDuration = 3,
                                ExtraData = new SupplementalDamage
                                {
                                    DamageCap = 50000,
                                    IsPercentageBased = true,
                                }.ToByteString(),
                            },
                            raidActions);
                    }

                    if (monika.GlobalState["monika/ab_3/cast_count"].IntegerValue >= 3)
                    {
                        monika.Raid.Allies.ApplyStatusEffects(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.DamageCapUpNpc,
                                Strength = 10,
                                TurnDuration = 3,
                            },
                            raidActions);
                    }

                    for (var i = 0; i < monika.AbilityCooldowns.Count; ++i)
                    {
                        monika.AbilityCooldowns[i] = 3;
                    }
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability ThunderclapBurst()
        {
            return new Ability
            {
                Name = "Thunderclap Burst",
                Cooldown = 3,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/abilities/4/ab_all_3040238000_04.js",
                    ConstructorName = "mc_ab_all_3040238000_04",
                    IsAbsolutePath = true,
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040238000_04",
                            Path = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/abilities/4/ab_all_3040238000_04.png",
                            IsAbsolutePath = true,
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
                            Id = StatusEffectLibrary.Dispel,
                            BaseAccuracy = double.MaxValue,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (monika, targetPositionInFrontline, raidActions) =>
                {
                    if (!monika.GlobalState.TryGetValue("monika/ab_4/cast_count", out var castCount))
                    {
                        monika.GlobalState.Add("monika/ab_4/cast_count", TypedValue.FromLong(0));
                    }

                    monika.GlobalState["monika/ab_4/cast_count"].IntegerValue += 1;
                    if (monika.GlobalState["monika/ab_4/cast_count"].IntegerValue == 2)
                    {
                        monika.Raid.Enemies.AtPosition(monika.CurrentTargetPositionInFrontline).ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.Delay,
                                BaseAccuracy = 100,
                            },
                            raidActions);
                    }
                    else if (monika.GlobalState["monika/ab_4/cast_count"].IntegerValue >= 3)
                    {
                        var twoTurns = ThreadSafeRandom.NextDouble() > 0.75;
                        monika.Raid.Allies.ApplyStatusEffects(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.ParalyzedLocal,
                                BaseAccuracy = 50,
                                TurnDuration = twoTurns ? 2 : 1,
                            },
                            raidActions);
                    }

                    for (var i = 0; i < monika.AbilityCooldowns.Count; ++i)
                    {
                        monika.AbilityCooldowns[i] = 3;
                    }
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Violetshock()
        {
            return new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/abilities/0/ab_all_3040238000_01.js",
                    ConstructorName = "mc_ab_all_3040238000_01",
                    IsAbsolutePath = true,
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040238000_01",
                            Path = "https://worldshifters-assets.azuriteworlds.com/assets/npc/557e49c1-bedb-46e0-bb73-b0f2594e32e7/abilities/0/ab_all_3040238000_01.png",
                            IsAbsolutePath = true,
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
                            Element = Element.Wind,
                            DamageModifier = 5,
                            HitNumber = 1,
                            DamageCap = 630_000,
                            HitAllTargets = true,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = StatusEffectLibrary.ChargeGaugeBoost,
                            Strength = 20,
                            EffectTargettingType = EffectTargettingType.OnSelf,
                        }.ToByteString(),
                    },
                    ApplyStatusEffect.FromTemplate(
                        new ApplyStatusEffect
                        {
                            BaseAccuracy = 90,
                            DurationInSeconds = 180,
                            EffectTargettingType = EffectTargettingType.OnAllEnemies,
                            IsStackable = true,
                            StackingCap = -30,
                        },
                        (StatusEffectLibrary.StackableAttackDownNpc, -10),
                        (StatusEffectLibrary.StackableDefenseDownNpc, -10)),
                },
                AnimationName = "ab_motion",
            };
        }
    }
}