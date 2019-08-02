// <copyright file="Nier.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Dark
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Raid;

    public static class Nier
    {
        public static Guid Id = Guid.Parse("0269f30f-3c61-45ac-9c75-9290516e8985");

        private const string LoveRedemptionId = "nier/love_redemption";
        private const string ThirstingId = "nier/thirsting";
        private const string BelovedId = "nier/beloved";
        private const string UnfinishedBusinessId = "nier/unfinished_business";
        private const string WorldOfDeathAndLoveId = "nier/field";

        public static Hero NewInstance()
        {
            var ability4Sprite = new Ability
            {
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/0269f30f-3c61-45ac-9c75-9290516e8985/abilities/3/ab_all_3040169000_02.js",
                    ConstructorName = "mc_ab_all_3040169000_02",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040169000_02",
                            Path =
                                "npc/0269f30f-3c61-45ac-9c75-9290516e8985/abilities/3/ab_all_3040169000_02.png",
                        },
                    },
                },
            };

            var unfinishedBusiness = new Ability
            {
                ModelMetadata = ability4Sprite.ModelMetadata,
                Effects =
                {
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = UnfinishedBusinessId,
                            OnAllPartyMembers = true,
                            IsUndispellable = true,
                            TurnDuration = 4,
                            BaseAccuracy = double.MaxValue,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = UnfinishedBusinessId,
                            OnAllEnemies = true,
                            IsUndispellable = true,
                            TurnDuration = 4,
                            BaseAccuracy = double.MaxValue,
                        }.ToByteString(),
                    },
                },
                ProcessEffects = (nier, targetPositionInFrontline, raidActions) =>
                {
                    foreach (var entity in nier.Raid.Allies.Concat(nier.Raid.Enemies))
                    {
                        if (!entity.IsAlive() || entity.PositionInFrontline >= 4)
                        {
                            continue;
                        }

                        entity.ApplyStatusEffectsFromTemplate(
                            new StatusEffectSnapshot
                            {
                                BaseAccuracy = double.MaxValue,
                                IsUndispellable = true,
                                IsUsedInternally = true,
                                TurnDuration = 4,
                            },
                            ($"{UnfinishedBusinessId}/def_down", ModifierLibrary.FlatDefenseBoost, -50),
                            ($"{UnfinishedBusinessId}/da_down", ModifierLibrary.FlatDoubleAttackRateBoost, -100),
                            ($"{UnfinishedBusinessId}/ta_down", ModifierLibrary.FlatTripleAttackRateBoost, -100),
                            ($"{UnfinishedBusinessId}/no_healing", ModifierLibrary.FlatHealingCapBoost, double.MinValue));
                    }
                },
            };

            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Nier",
                Race = Race.Unknow,
                Gender = Gender.Female,
                MaxAttack = 8906,
                MaxHp = 1313,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Element = Element.Dark,
                WeaponProficiencies = { EquipmentType.Dagger },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/0269f30f-3c61-45ac-9c75-9290516e8985/model/0/npc_3040169000_02.js",
                        ConstructorName = "mc_npc_3040169000_02",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040169000_02",
                                Path = "npc/0269f30f-3c61-45ac-9c75-9290516e8985/model/0/npc_3040169000_02.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        JsAssetPath = "npc/0269f30f-3c61-45ac-9c75-9290516e8985/model/0/phit_3040169000.js",
                        ConstructorName = "phit_3040169000_effect",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040169000",
                                Path = "npc/0269f30f-3c61-45ac-9c75-9290516e8985/model/0/phit_3040169000.png",
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
                            JsAssetPath = "npc/0269f30f-3c61-45ac-9c75-9290516e8985/model/0/nsp_3040169000_02_s2.js",
                            ConstructorName = "mc_nsp_3040169000_02_s2_special",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040169000_02_s2_a",
                                    Path = "npc/0269f30f-3c61-45ac-9c75-9290516e8985/model/0/nsp_3040169000_02_s2_a.png",
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040169000_02_s2_b",
                                    Path = "npc/0269f30f-3c61-45ac-9c75-9290516e8985/model/0/nsp_3040169000_02_s2_b.png",
                                },
                            },
                        },
                    },
                },
                Abilities =
                {
                    WorldOfDeathAndLove(cooldown: 7),
                    Beloved(cooldown: 6),
                    new Ability
                    {
                        Name = "Last Love",
                        Cooldown = 4,
                        ModelMetadata = new ModelMetadata
                        {
                            JsAssetPath = "npc/0269f30f-3c61-45ac-9c75-9290516e8985/abilities/2/ab_3040169000_02.js",
                            ConstructorName = "mc_ab_3040169000_02",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "ab_3040169000_02",
                                    Path = "npc/0269f30f-3c61-45ac-9c75-9290516e8985/abilities/2/ab_3040169000_02.png",
                                },
                            },
                        },
                        ShouldRepositionSpriteAnimation = true,
                        RepositionOnTarget = true,
                        AbilityTargetting = AbilityTargettingType.TargetSingleAliveFrontLineMember,
                        Effects =
                        {
                            new AbilityEffect
                            {
                                Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                                ExtraData = new ApplyStatusEffect
                                {
                                    Id = StatusEffectLibrary.ChargeAttackReactivation,
                                    IsBuff = true,
                                    OnSelectedTarget = true,
                                    TurnDuration = int.MaxValue,
                                }.ToByteString(),
                            },
                        },
                        ProcessEffects = (nier, target, raidActions) =>
                        {
                            IncrementLoveRedemption(nier, -1, raidActions);
                        },
                        AnimationName = "ab_motion",
                    },
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        RequiredLevel = 55,
                        Ability = WorldOfDeathAndLove(cooldown: 6),
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        RequiredLevel = 75,
                        Ability = Beloved(cooldown: 5),
                        UpgradedAbilityIndex = 1,
                    },
                },
                PassiveAbilities =
                {
                    new PassiveAbility
                    {
                        Name = "Will to Love",
                        Description = "Love's Redemption lowers by 2 each turn. Nier will be knocked out when its count reaches 0. DMG taken is lowered while in effect.",
                    },
                    new PassiveAbility
                    {
                        Name = "Death Reversed",
                        Description = "When Sub Ally: When above 25% HP and Dark element, the main character can withstand lethal damage.",
                        Type = PassiveAbility.Types.PassiveAbilityType.BacklineEffect,
                    },
                    new PassiveAbility
                    {
                        Name = "The Lovers Upright",
                        Description = "When Switching to Main Ally: All Dark allies gain Thirsting.",
                        Type = PassiveAbility.Types.PassiveAbilityType.TriggerOnEnteringFrontline,
                    },
                },
                OnActionStart = (nier, raidActions) => ProcessLoveRedemptionEffects(nier),
                OnSetup = (nier, allies, loadout) => SetupLoveRedemptionStacks(nier),
                OnTurnEnd = (nier, raidActions) =>
                {
                    if (!nier.IsAlive() || nier.PositionInFrontline >= 4)
                    {
                        return;
                    }

                    IncrementLoveRedemption(nier, -2, raidActions);

                    if (nier.GetStatusEffectStacks(LoveRedemptionId) == 0)
                    {
                        nier.Kill(raidActions);
                    }
                },
                OnAbilityEnd = (nier, ability, raidActions) =>
                {
                    if (nier.IsAlive() && nier.PositionInFrontline < 4 && nier.GetStatusEffectStacks(LoveRedemptionId) == 0)
                    {
                        nier.Kill(raidActions);
                    }
                },
                OnDeath = (nier, raidActions) =>
                {
                    if (nier.GetStatusEffectStacks(LoveRedemptionId) > 0)
                    {
                        unfinishedBusiness.Cast(nier, raidActions);
                    }
                },
                OnEnteringFrontline = (nier, raidActions) =>
                {
                    SetupLoveRedemptionStacks(nier);

                    if (nier.GlobalState.ContainsKey("nonce"))
                    {
                        return;
                    }

                    nier.GlobalState["nonce"] = TypedValue.FromBool(true);

                    ability4Sprite.Cast(nier, raidActions);
                    foreach (var hero in nier.Raid.Allies)
                    {
                        if (!hero.IsAlive() || hero.PositionInFrontline >= 4 || hero.Element != Element.Dark)
                        {
                            continue;
                        }

                        hero.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = ThirstingId,
                                IsBuff = true,
                                IsUndispellable = true,
                                TurnDuration = int.MaxValue,
                            },
                            raidActions);

                        hero.ApplyStatusEffectsFromTemplate(
                            new StatusEffectSnapshot
                            {
                                IsBuff = true,
                                IsUndispellable = true,
                                TurnDuration = int.MaxValue,
                                IsUsedInternally = true,
                            },
                            ($"{ThirstingId}/auto_revive", ModifierLibrary.AutoRevive, 50),
                            ($"{ThirstingId}/absorb", ModifierLibrary.DamageAbsorption, 30));
                    }
                },
            };
        }

        public static void RegisterWorldOfDeathAndLoveFieldEffect()
        {
            FieldEffectLibrary.AddNewFieldEffect(WorldOfDeathAndLoveId, () => new FieldEffect
            {
                Id = WorldOfDeathAndLoveId,
                IsLocal = true,
                TurnDuration = 3,
                ProcessEffects = (raid, raidActions) =>
                {
                    foreach (var entity in raid.Allies.Concat(raid.Enemies))
                    {
                        entity.ApplyStatusEffect(new StatusEffectSnapshot
                        {
                            Id = $"{WorldOfDeathAndLoveId}/atk_up",
                            TurnDuration = 1,
                            IsBuff = true,
                            IsUsedInternally = true,
                            Modifier = ModifierLibrary.FlatAttackBoost,
                            Strength = 20,
                            IsPassiveEffect = true,
                        });
                    }

                    foreach (var entity in raid.Allies)
                    {
                        entity.ApplyStatusEffect(new StatusEffectSnapshot
                        {
                            Id = $"{WorldOfDeathAndLoveId}/echo",
                            TurnDuration = 1,
                            IsBuff = true,
                            IsUsedInternally = true,
                            Modifier = ModifierLibrary.AdditionalDamage,
                            Strength = 30,
                            IsPassiveEffect = true,
                        });
                    }
                },
            });
        }

        private static Ability WorldOfDeathAndLove(uint cooldown)
        {
            return new Ability
            {
                Name = "World of Death and Love",
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath =
                        "npc/0269f30f-3c61-45ac-9c75-9290516e8985/abilities/0/ab_all_3040169000_01.js",
                    ConstructorName = "mc_ab_all_3040169000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040169000_01",
                            Path = "npc/0269f30f-3c61-45ac-9c75-9290516e8985/abilities/0/ab_all_3040169000_01.png",
                        },
                    },
                },
                ProcessEffects = (nier, targetPositionInFrontline, raidActions) =>
                {
                    nier.Raid.AddFieldEffect(WorldOfDeathAndLoveId);
                },
                AnimationName = "ab_motion",
            };
        }

        private static Ability Beloved(uint cooldown)
        {
            return new Ability
            {
                Name = "Beloved",
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    JsAssetPath = "npc/0269f30f-3c61-45ac-9c75-9290516e8985/abilities/1/ab_3040169000_01.js",
                    ConstructorName = "mc_ab_3040169000_01",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_3040169000_01",
                            Path = "npc/0269f30f-3c61-45ac-9c75-9290516e8985/abilities/1/ab_3040169000_01.png",
                        },
                    },
                },
                ShouldRepositionSpriteAnimation = true,
                RepositionOnTarget = true,
                AbilityTargetting = AbilityTargettingType.TargetSingleAliveFrontLineMemberExcludingSelf,
                Effects =
                {
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = BelovedId,
                            IsBuff = true,
                            IsUndispellable = true,
                            OnSelf = true,
                            TurnDuration = 4,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.ApplyStatusEffect,
                        ExtraData = new ApplyStatusEffect
                        {
                            Id = BelovedId,
                            IsBuff = true,
                            IsUndispellable = true,
                            OnSelectedTarget = true,
                            TurnDuration = 4,
                        }.ToByteString(),
                    },
                    ApplyStatusEffect.FromTemplate(
                        new ApplyStatusEffect
                        {
                            IsBuff = true,
                            IsUndispellable = true,
                            OnSelf = true,
                            TurnDuration = 4,
                            IsUsedInternally = true,
                        },
                        (StatusEffectLibrary.TripleAttackRateUpNpc, double.MaxValue),
                        (StatusEffectLibrary.DamageReductionUpNpc, 50)),
                    ApplyStatusEffect.FromTemplate(
                        new ApplyStatusEffect
                        {
                            IsBuff = true,
                            IsUndispellable = true,
                            OnSelectedTarget = true,
                            TurnDuration = 4,
                            IsUsedInternally = true,
                        },
                        (StatusEffectLibrary.TripleAttackRateUpNpc, double.MaxValue),
                        (StatusEffectLibrary.DamageReductionUpNpc, 50)),
                },
                ProcessEffects = (nier, target, raidActions) =>
                {
                    // The effect can't be granted to more than one other ally
                    foreach (var ally in nier.Raid.Allies)
                    {
                        if (ally.PositionInFrontline == target || ally.PositionInFrontline == nier.PositionInFrontline)
                        {
                            continue;
                        }

                        if (ally.RemoveStatusEffect(BelovedId))
                        {
                            break;
                        }
                    }

                    IncrementLoveRedemption(nier, -2, raidActions);
                },
                AnimationName = "ab_motion",
            };
        }

        private static void IncrementLoveRedemption(EntitySnapshot nier, int count, IList<RaidAction> raidActions)
        {
            nier.OverrideStatusEffect(
                new StatusEffectSnapshot
                {
                    Id = $"{LoveRedemptionId}_13",
                    Strength = 13,
                    IsBuff = true,
                    IsUndispellable = true,
                    TurnDuration = int.MaxValue,
                },
                LoveRedemptionId,
                (previousStatusEffect, newStatusEffect) =>
                {
                    var remainingStacks = (int)previousStatusEffect.Strength + count;
                    newStatusEffect.Strength = remainingStacks;
                    newStatusEffect.Id = $"{LoveRedemptionId}_{remainingStacks}";
                    return remainingStacks > 0;
                },
                raidActions);
        }

        private static void ProcessLoveRedemptionEffects(EntitySnapshot nier)
        {
            if (!nier.IsAlive() || nier.PositionInFrontline >= 4)
            {
                return;
            }

            var loveRedemptionStacks = nier.GetStatusEffectStacks(LoveRedemptionId);
            nier.ApplyStatusEffectsFromTemplate(
                new StatusEffectSnapshot
                {
                    IsBuff = true,
                    IsUsedInternally = true,
                    IsUndispellable = true,
                    TurnDuration = 1,
                },
                ($"{LoveRedemptionId}/ca_up", ModifierLibrary.FlatChargeAttackDamageBoost, (14 - loveRedemptionStacks) * 10),
                ($"{LoveRedemptionId}/ca_cap_up", ModifierLibrary.FlatChargeAttackDamageCapBoost, (14 - loveRedemptionStacks) * 5),
                ($"{LoveRedemptionId}/dmg_reduction", ModifierLibrary.DamageReductionBoost, 90));
        }

        private static void SetupLoveRedemptionStacks(EntitySnapshot nier)
        {
            // Love redemption stacks are frozen when Nier is relegated to the backrow.
            // Nier starts with 13 stacks after being revived.
            if (nier.GetStatusEffectStacks(LoveRedemptionId) == 0)
            {
                nier.ApplyStatusEffect(new StatusEffectSnapshot
                {
                    Id = $"{LoveRedemptionId}_13",
                    Strength = 13,
                    IsBuff = true,
                    IsUndispellable = true,
                    TurnDuration = int.MaxValue,
                });
            }

            ProcessLoveRedemptionEffects(nier);
        }
    }
}
