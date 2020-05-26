// <copyright file="Pholia.cs" company="Worldshifters">
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

    public static class Pholia
    {
        public static Guid Id = Guid.Parse("37bfabf8-cb25-4fde-968e-fbfd21cf9b8d");

        private const string WhiteVeilAtTurnStart = "pholia/white_veil_at_turn_start";
        private const string RecognitionId = "pholia/recognition";
        private const string WhiteVeilId = "pholia/white_veil";
        private const string UnveiledSinId = "pholia/unveiled_sin";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Pholia",
                Races = { Race.Erune },
                Gender = Gender.Female,
                MaxAttack = 7899,
                MaxHp = 1166,
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
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.DoubleAttackRateBoost,
                    ExtendedMasteryPerks.TripleAttackRateBoost,
                    ExtendedMasteryPerks.WaterAttackBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.TripleAttackRateBoost,
                    ExtendedMasteryPerks.DebuffSuccessRateBoost,
                    ExtendedMasteryPerks.FireDamageReduction,
                    ExtendedMasteryPerks.SupportSkill,
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/37bfabf8-cb25-4fde-968e-fbfd21cf9b8d/model/0/npc_3040181000_02.js",
                        ConstructorName = "mc_npc_3040181000_02",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040181000_02_a",
                                Path = "npc/37bfabf8-cb25-4fde-968e-fbfd21cf9b8d/model/0/npc_3040181000_02_a.png",
                            },
                            new ImageAsset
                            {
                                Name = "npc_3040181000_02_b",
                                Path = "npc/37bfabf8-cb25-4fde-968e-fbfd21cf9b8d/model/0/npc_3040181000_02_b.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/37bfabf8-cb25-4fde-968e-fbfd21cf9b8d/model/0/phit_3040181000.js",
                        ConstructorName = "mc_phit_3040181000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040181000",
                                Path = "npc/37bfabf8-cb25-4fde-968e-fbfd21cf9b8d/model/0/phit_3040181000.png",
                            },
                        },
                    },
                },
                Abilities =
                {
                    WhiteVeil(cooldown: 9),
                    Recognition(cooldown: 9),
                    new Ability
                    {
                        Name = string.Empty,
                        Cooldown = 0,
                        ModelMetadata = new ModelMetadata
                        {
                            JsAssetPath = "npc/37bfabf8-cb25-4fde-968e-fbfd21cf9b8d/abilities/2/ab_all_3040181000_01.js",
                            ConstructorName = "mc_ab_all_3040181000_01",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "ab_all_3040181000_01",
                                    Path = "npc/37bfabf8-cb25-4fde-968e-fbfd21cf9b8d/abilities/2/ab_all_3040181000_01.png",
                                },
                            },
                        },
                        AnimationName = "ab_motion",
                    },
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = WhiteVeil(cooldown: 8),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = Recognition(cooldown: 8),
                        UpgradedAbilityIndex = 1,
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = string.Empty,
                    HitCount = { 6 },
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath =
                                "npc/37bfabf8-cb25-4fde-968e-fbfd21cf9b8d/model/0/nsp_3040181000_02_s2.js",
                            ConstructorName = "mc_nsp_3040181000_02_s2_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040181000_02_s2_a",
                                    Path = "npc/37bfabf8-cb25-4fde-968e-fbfd21cf9b8d/model/0/nsp_3040181000_02_s2_a.png",
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040181000_02_s2_b",
                                    Path = "npc/37bfabf8-cb25-4fde-968e-fbfd21cf9b8d/model/0/nsp_3040181000_02_s2_b.png",
                                },
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
                                Id = StatusEffectLibrary.Shield,
                                Strength = 2000,
                                EffectTargettingType = EffectTargettingType.OnAllPartyMembers,
                                TurnDuration = 4,
                            }.ToByteString(),
                        },
                    },
                },
                OnActionStart = (pholia, _, raidActions) =>
                {
                    foreach (var hero in pholia.Raid.Allies)
                    {
                        if (!hero.IsAlive() || hero.GetStatusEffects().All(e => e.Id != "pholia_recognition"))
                        {
                            continue;
                        }

                        hero.ApplyStatusEffect(new StatusEffectSnapshot
                        {
                            Strength = 100,
                            Id = "pholia/recognition/crit_rate_up",
                            IsUndispellable = true,
                            IsUsedInternally = true,
                            Modifier = ModifierLibrary.FlatCriticalHitRateBoost,
                            ExtraData = new CriticalHit
                            {
                                DamageMultiplier = 0.5,
                            }.ToByteString(),
                        });

                        hero.ApplyStatusEffectsFromTemplate(
                            new StatusEffectSnapshot
                            {
                                IsUndispellable = true,
                                IsUsedInternally = true,
                            },
                            ("pholia/recognition/da_up", ModifierLibrary.FlatDoubleAttackRateBoost, double.PositiveInfinity),
                            ("pholia/recognition/ta_up", ModifierLibrary.FlatTripleAttackRateBoost, 20),
                            ("pholia/recognition/dmg_reduction", ModifierLibrary.DamageReductionBoost, 30),
                            ("pholia/recognition/dmg_cap_up", ModifierLibrary.FlatDamageCapBoost, 20));
                    }

                    TryProcessPholiaUniqueBuffs(pholia);
                },
                OnAttackEnd = (pholia, attackResult, raidActions) =>
                {
                    if (attackResult == EntitySnapshot.AttackResult.SpecialAttack)
                    {
                        if (pholia.IsAlive())
                        {
                            var whiteVeilBuff = pholia.GetStatusEffects().FirstOrDefault(e => e.Id == WhiteVeilId);
                            if (whiteVeilBuff != null)
                            {
                                whiteVeilBuff.Strength = (long)Math.Min(pholia.MaxHp * 0.4, 8000);
                            }
                        }

                        foreach (var hero in pholia.Raid.Allies)
                        {
                            if (hero.IsAlive())
                            {
                                var pholiaRecognition = hero.GetStatusEffects()
                                    .FirstOrDefault(e => e.Id == "pholia_recognition");
                                if (pholiaRecognition != null)
                                {
                                    pholiaRecognition.TurnDuration = pholiaRecognition.TurnDuration + 2;
                                }
                            }
                        }
                    }
                },
                OnTurnEnd = (pholia, raidActions) =>
                {
                    if (pholia.IsAlive())
                    {
                        if (pholia.Hp == pholia.MaxHp)
                        {
                            pholia.AddChargeGauge(10, raidActions);
                        }
                        else
                        {
                            pholia.Heal(500, raidActions);
                        }
                    }
                },
                OnReceiveDamageFromEnemy = (pholia, enemy, raidActions) =>
                {
                    if (!pholia.IsAlive())
                    {
                        return;
                    }

                    if (pholia.GetStatusEffects().All(e => e.Id != UnveiledSinId && e.Id != WhiteVeilId) && (bool)pholia.ActionLocalDataStore[WhiteVeilAtTurnStart])
                    {
                        pholia.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = UnveiledSinId,
                                TurnDuration = 3,
                                IsUndispellable = true,
                                BaseAccuracy = double.MaxValue,
                            }, raidActions);

                        TryProcessPholiaUniqueBuffs(pholia);
                    }
                },
            };
        }

        private static void TryProcessPholiaUniqueBuffs(EntitySnapshot pholia)
        {
            if (!pholia.IsAlive())
            {
                return;
            }

            if (pholia.GetStatusEffects().Any(e => e.Id == WhiteVeilId))
            {
                pholia.ActionLocalDataStore[WhiteVeilAtTurnStart] = true;
                pholia.ApplyStatusEffectsFromTemplate(
                    new StatusEffectSnapshot
                    {
                        IsUndispellable = true,
                        IsUsedInternally = true,
                        TriggerCondition = new StatusEffectSnapshot.Types.TriggerCondition
                        {
                            Type = StatusEffectSnapshot.Types.TriggerCondition.Types.Type.HasStatusEffect,
                            Data = WhiteVeilId,
                        },
                    },
                    (WhiteVeilId + "/atk_up", ModifierLibrary.FlatAttackBoost, 30),
                    (WhiteVeilId + "/def_up", ModifierLibrary.FlatDefenseBoost, 30),
                    (WhiteVeilId + "/da_up", ModifierLibrary.FlatDoubleAttackRateBoost, double.PositiveInfinity));

                pholia.ApplyStatusEffectsFromTemplate(
                    new StatusEffectSnapshot
                    {
                        Id = WhiteVeilId + "/crit_rate_up",
                        IsUndispellable = true,
                        IsUsedInternally = true,
                        Strength = 100,
                        Modifier = ModifierLibrary.FlatCriticalHitRateBoost,
                        ExtraData = new CriticalHit
                        {
                            DamageMultiplier = 0.2,
                        }.ToByteString(),
                        TriggerCondition = new StatusEffectSnapshot.Types.TriggerCondition
                        {
                            Type = StatusEffectSnapshot.Types.TriggerCondition.Types.Type.HasStatusEffect,
                            Data = WhiteVeilId,
                        },
                    });
            }
            else
            {
                pholia.ActionLocalDataStore[WhiteVeilAtTurnStart] = false;
            }

            if (pholia.GetStatusEffects().Any(e => e.Id == UnveiledSinId))
            {
                pholia.ApplyStatusEffectsFromTemplate(
                    new StatusEffectSnapshot
                    {
                        BaseAccuracy = double.MaxValue,
                        IsUndispellable = true,
                        IsUsedInternally = true,
                        TriggerCondition = new StatusEffectSnapshot.Types.TriggerCondition
                        {
                            Type = StatusEffectSnapshot.Types.TriggerCondition.Types.Type.HasStatusEffect,
                            Data = UnveiledSinId,
                        },
                    },
                    (UnveiledSinId + "/atk_down", ModifierLibrary.FlatAttackBoost, -50),
                    (UnveiledSinId + "/def_down", ModifierLibrary.FlatDefenseBoost, -20));
            }
        }

        private static Ability WhiteVeil(uint cooldown)
        {
            return new Ability
            {
                Name = "White Veil",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/37bfabf8-cb25-4fde-968e-fbfd21cf9b8d/abilities/0/ab_3040181000_01.js",
                    ConstructorName = "mc_ab_3040181000_01_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040181000_01",
                            Path = "npc/37bfabf8-cb25-4fde-968e-fbfd21cf9b8d/abilities/0/ab_3040181000_01.png",
                        },
                    },
                },
                AnimationName = "ab_motion",
                ShouldRepositionSpriteAnimation = true,
                ProcessEffects = (pholia, _, raidActions) =>
                {
                    pholia.RemoveStatusEffect(UnveiledSinId);
                    pholia.ApplyStatusEffect(
                        new StatusEffectSnapshot
                        {
                            Id = WhiteVeilId,
                            Strength = (long)Math.Min(pholia.MaxHp * 0.4, 8000),
                            TurnDuration = int.MaxValue,
                            Modifier = ModifierLibrary.Shield,
                            IsUndispellable = true,
                        },
                        raidActions);
                },
            };
        }

        private static Ability Recognition(uint cooldown)
        {
            return new Ability
            {
                Name = "Recognition",
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/37bfabf8-cb25-4fde-968e-fbfd21cf9b8d/abilities/1/ab_3040181000_02.js",
                    ConstructorName = "mc_ab_3040181000_02_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040181000_02",
                            Path = "npc/37bfabf8-cb25-4fde-968e-fbfd21cf9b8d/abilities/1/ab_3040181000_02.png",
                        },
                    },
                },
                AnimationName = "ab_motion",
                AbilityTargetting = AbilityTargettingType.TargetSingleAliveFrontLineMemberExcludingSelf,
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
                Effects =
                {
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = RecognitionId,
                            EffectTargettingType = EffectTargettingType.OnSelectedAlly,
                            TurnDuration = 5,
                            IsUndispellable = true,
                        }.ToByteString(),
                    },
                },
            };
        }
    }
}