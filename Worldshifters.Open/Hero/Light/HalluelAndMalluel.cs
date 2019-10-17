// <copyright file="HalluelAndMalluel.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Light
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class HalluelAndMalluel
    {
        public static Guid Id = Guid.Parse("f7d1ac97-7348-4de9-ba3a-0e433ffc94dc");

        private const string LimiterBreakId = "halluel_and_malluel/limiter_break";
        private const string AdventurousTwinsId = "halluel_and_melluel/adventurous twins";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Halluel and Malluel",
                Races = { Race.Primal },
                Gender = Gender.Female,
                MaxAttack = 4000,
                MaxHp = 1600,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Light,
                WeaponProficiencies = { EquipmentType.Dagger },
                AvailablePerkIds =
                {
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.TripleAttackRateBoost,
                    ExtendedMasteryPerks.DebuffResistanceBoost,
                    ExtendedMasteryPerks.AttackBoost,
                    ExtendedMasteryPerks.DefenseBoost,
                    ExtendedMasteryPerks.HpBoost,
                    ExtendedMasteryPerks.LightAttackBoost,
                    ExtendedMasteryPerks.ChargeAttackDamageBoost,
                    ExtendedMasteryPerks.TripleAttackRateBoost,
                    ExtendedMasteryPerks.CriticalHitRateBoost,
                    ExtendedMasteryPerks.ChargeAttackDamageBoost,
                    ExtendedMasteryPerks.HealingBoost,
                    ExtendedMasteryPerks.SupportSkill,
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/f7d1ac97-7348-4de9-ba3a-0e433ffc94dc/model/0/npc_3040223000_02.js",
                        ConstructorName = "mc_npc_3040223000_02",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040223000_02",
                                Path = "npc/f7d1ac97-7348-4de9-ba3a-0e433ffc94dc/model/0/npc_3040223000_02.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/f7d1ac97-7348-4de9-ba3a-0e433ffc94dc/model/0/phit_3040223000.js",
                        ConstructorName = "mc_phit_3040223000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040223000",
                                Path = "npc/f7d1ac97-7348-4de9-ba3a-0e433ffc94dc/model/0/phit_3040223000.png",
                            },
                        },
                    },
                },
                Abilities =
                {
                    Eterno(cooldown: 8),
                    Perpetuo(cooldown: 7),
                    new Ability
                    {
                        Name = "Geminis",
                        Cooldown = 7,
                        Type = Ability.Types.AbilityType.Support,
                        ModelMetadata = new ModelMetadata
                        {
                            JsAssetPath = "npc/f7d1ac97-7348-4de9-ba3a-0e433ffc94dc/abilities/2/ab_3040223000_01.js",
                            ConstructorName = "mc_ab_3040223000_01_effect",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "ab_3040223000_01",
                                    Path = "npc/f7d1ac97-7348-4de9-ba3a-0e433ffc94dc/abilities/2/ab_3040223000_01.png",
                                },
                            },
                        },
                        AnimationName = "ab_motion",
                        ShouldRepositionSpriteAnimation = true,
                        ProcessEffects = (halluelAndMalluel, _, raidActions) =>
                        {
                            var stacks = halluelAndMalluel.GetStatusEffectStacks(LimiterBreakId);
                            if (stacks > 0)
                            {
                                halluelAndMalluel.RemoveStatusEffect($"{LimiterBreakId}_{stacks}");
                            }

                            halluelAndMalluel.ApplyStatusEffect(
                                new StatusEffectSnapshot
                                {
                                    Id = $"{LimiterBreakId}_3",
                                    Strength = 3,
                                    TurnDuration = int.MaxValue,
                                    IsUndispellable = true,
                                }, raidActions);
                        },
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = "Pain Eternal",
                    HitCount = { 5 },
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            JsAssetPath = "npc/f7d1ac97-7348-4de9-ba3a-0e433ffc94dc/model/0/nsp_3040223000_02_s2.js",
                            ConstructorName = "mc_nsp_3040223000_02_s2_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040223000_02_s2_a",
                                    Path = "npc/f7d1ac97-7348-4de9-ba3a-0e433ffc94dc/model/0/nsp_3040223000_02_s2_a.png",
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040223000_02_s2_b",
                                    Path = "npc/f7d1ac97-7348-4de9-ba3a-0e433ffc94dc/model/0/nsp_3040223000_02_s2_b.png",
                                },
                            },
                        },
                    },
                    ProcessEffects = (halluelAndMalluel, raidActions) =>
                    {
                        AddAuroraCrest(halluelAndMalluel, raidActions);
                        if (halluelAndMalluel.GetStatusEffectStacks(LimiterBreakId) > 0)
                        {
                            halluelAndMalluel.Raid.Allies.ApplyStatusEffects(
                                new StatusEffectSnapshot
                                {
                                    Id = StatusEffectLibrary.Shield,
                                    Strength = 2000,
                                    TurnDuration = int.MaxValue,
                                }, raidActions);
                        }
                    },
                    ConstructorNameOnAnimationSkip = { "moA_Cutin" },
                    FrameToSkipToOnAnimationSkip = { 106 },
                },
                OnActionStart = (halluelAndMalluel, raidActions) =>
                {
                    if (!halluelAndMalluel.IsAlive())
                    {
                        return;
                    }

                    foreach (var ally in halluelAndMalluel.Raid.Allies)
                    {
                        var auroraCrests = ally.GetStatusEffectStacks(StatusEffectLibrary.AuroraCrest);
                        if (auroraCrests > 0)
                        {
                            ally.ApplyStatusEffect(new StatusEffectSnapshot
                            {
                                Id = AdventurousTwinsId,
                                IsPassiveEffect = true,
                                IsUsedInternally = true,
                                Modifier = ModifierLibrary.SupplementalDamage,
                                Strength = 1,
                                ExtraData = new SupplementalDamage
                                {
                                    DamageCap = auroraCrests * 4000,
                                    IsPercentageBased = true,
                                }.ToByteString(),
                            });
                        }
                    }

                    if (halluelAndMalluel.GetStatusEffectStacks(LimiterBreakId) <= 0)
                    {
                        return;
                    }

                    halluelAndMalluel.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            IsUndispellable = true,
                            IsUsedInternally = true,
                        },
                        ("halluel_and_malluel/geminis_atk_up", ModifierLibrary.FlatAttackBoost, 40),
                        ("halluel_and_malluel/geminis_dmg_cap_up", ModifierLibrary.FlatDamageCapBoost, 20),
                        ("halluel_and_malluel/geminis_dodge_rate_up", ModifierLibrary.DodgeRateBoost, 40),
                        ("halluel_and_malluel/geminis_da_rate_up", ModifierLibrary.FlatDoubleAttackRateBoost, double.PositiveInfinity),
                        ("halluel_and_malluel/geminis_ta_rate_up", ModifierLibrary.FlatTripleAttackRateBoost, 30));
                },
                OnTurnEnd = (halluelAndMalluel, raidActions) =>
                {
                    if (halluelAndMalluel.NumHitsReceived <= 0)
                    {
                        return;
                    }

                    var limiterBreak = halluelAndMalluel.GetStatusEffects().FirstOrDefault(e => e.Id.StartsWith(LimiterBreakId, StringComparison.InvariantCultureIgnoreCase));
                    if (limiterBreak != null)
                    {
                        if ((int)limiterBreak.Strength == 1)
                        {
                            halluelAndMalluel.RemoveStatusEffect(limiterBreak.Id);
                        }
                        else
                        {
                            var remainingStacks = (int)limiterBreak.Strength - 1;
                            limiterBreak.Id = $"{LimiterBreakId}_{remainingStacks}";
                            limiterBreak.Strength = remainingStacks;
                        }
                    }
                },
                OnDeath = (halluelAndMalluel, raidActions) =>
                {
                    foreach (var ally in halluelAndMalluel.Raid.Allies)
                    {
                        ally.RemoveStatusEffect(AdventurousTwinsId);
                    }
                },
            };
        }

        private static Ability Eterno(uint cooldown)
        {
            return new Ability
            {
                Name = "Eterno",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Offensive,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/f7d1ac97-7348-4de9-ba3a-0e433ffc94dc/abilities/0/ab_3040223000_02.js",
                    ConstructorName = "mc_ab_3040223000_02_effect",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040223000_02",
                            Path = "npc/f7d1ac97-7348-4de9-ba3a-0e433ffc94dc/abilities/0/ab_3040223000_02.png",
                        },
                    },
                },
                ProcessEffects = (halluelAndMalluel, targetPositionInFrontline, raidActions) =>
                {
                    var target = halluelAndMalluel.Raid.Enemies.AtPosition(targetPositionInFrontline);
                    target.DealRawDamage(Math.Min(1_000_000, (long)Math.Ceiling(target.MaxHp * 0.1)), Element.Null, raidActions);

                    var auroraCrests = halluelAndMalluel.GetStatusEffectStacks(StatusEffectLibrary.AuroraCrest);
                    foreach (var ally in halluelAndMalluel.Raid.Allies)
                    {
                        if (!ally.IsAlive() || ally.PositionInFrontline >= 4)
                        {
                            continue;
                        }

                        ally.Heal((long)Math.Min(1000 + (200 * auroraCrests), ally.MaxHp * 0.1), raidActions, caster: halluelAndMalluel);
                    }
                },
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
                AnimationName = "ab_motion",
            };
        }

        private static Ability Perpetuo(uint cooldown)
        {
            return new Ability
            {
                Name = "Perpetuo",
                Cooldown = (int)cooldown,
                Type = Ability.Types.AbilityType.Support,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/f7d1ac97-7348-4de9-ba3a-0e433ffc94dc/abilities/1/ab_all_3040223000_01.js",
                    ConstructorName = "mc_ab_all_3040223000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040223000_01",
                            Path = "npc/f7d1ac97-7348-4de9-ba3a-0e433ffc94dc/abilities/1/ab_all_3040223000_01.png",
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
                            Id = StatusEffectLibrary.LightAttackUpNpc,
                            Strength = 30,
                            TurnDuration = 3,
                            EffectTargettingType = EffectTargettingType.OnAllPartyMembers,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = StatusEffectLibrary.DarkDamageCutUpNpc,
                            Strength = 20,
                            TurnDuration = 3,
                            EffectTargettingType = EffectTargettingType.OnAllPartyMembers,
                        }.ToByteString(),
                    },
                },
                AnimationName = "ab_motion_2",
                ProcessEffects = (halluelAndMalluel, _, raidActions) =>
                {
                    foreach (var ally in halluelAndMalluel.Raid.Allies)
                    {
                        if (ally.IsAlive() && ally.PositionInFrontline < 4)
                        {
                            AddAuroraCrest(ally, raidActions);
                        }
                    }

                    if (halluelAndMalluel.GetStatusEffectStacks(LimiterBreakId) > 0)
                    {
                        halluelAndMalluel.Raid.Allies.ApplyStatusEffects(
                            new StatusEffectSnapshot
                            {
                                Id = StatusEffectLibrary.AdditionalLightDamageNpc,
                                TurnDuration = 3,
                                Strength = 20,
                            },
                            raidActions);
                    }
                },
            };
        }

        private static void AddAuroraCrest(EntitySnapshot character, IList<RaidAction> raidActions)
        {
            character.ApplyOrOverrideStatusEffectStacks(StatusEffectLibrary.AuroraCrest, initialStackCount: 1, increment: 1, maxStackCount: 5, raidActions: raidActions, isUndispellable: true);
        }
    }
}
