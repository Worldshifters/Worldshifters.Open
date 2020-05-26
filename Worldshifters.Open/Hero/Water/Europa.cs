// <copyright file="Europa.cs" company="Worldshifters">
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

    public static class Europa
    {
        public static Guid Id = Guid.Parse("6da988da-cb06-4710-acd3-d8bd006ae7dd");

        private const string FountainLotusId = "europa/fountain_lotus";
        private const string StarSanctuaryId = "europa/star_sanctuary";

        public static Hero NewInstance()
        {
            return new Hero
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Name = "Europa",
                Races = { Race.Primal },
                Gender = Gender.Female,
                MaxAttack = 6800,
                MaxHp = 2000,
                MaxLevel = 80,
                BaseDoubleAttackRate = 6,
                BaseTripleAttackRate = 4.5,
                Description = "The maiden blessed by water descends to the sky realm. While setting out to fulfill a mission assigned to her by a dear primarch and to satisfy her own inner desires, Europa has an epiphany—that those who dwell in the mortal world possess a most charming luminosity about them. This remarkable discovery piques her curiosity regarding all things mortal and reinforces her desire to gaze upon further beauty.",
                Element = Element.Water,
                WeaponProficiencies = { EquipmentType.Staff },
                Abilities =
                {
                    ManaBlast(cooldown: 7),
                    TyrosAggeris(cooldown: 14),
                    new Ability
                    {
                        Name = "Pleiades",
                        Description = "Water damage to a foe. Deals triple attacks and additional Water DMG.",
                        Cooldown = 7,
                        Type = Ability.Types.AbilityType.Offensive,
                        ModelMetadata = new ModelMetadata
                        {
                            ConstructorName = "mc_ab_all_3040190000_03_effect",
                            JsAssetPath = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/abilities/2/ability.js",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "ab_all_3040190000_03",
                                    Path = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/abilities/2/ab_all_3040190000_03.png",
                                },
                            },
                        },
                        AnimationName = "ab_motion",
                        Effects =
                        {
                            new AbilityEffect
                            {
                                Type = AbilityEffect.Types.AbilityEffectType.MultihitDamage,
                                ExtraData = new MultihitDamage
                                {
                                    Element = Element.Water,
                                    HitNumber = 1,
                                    DamageModifier = 7,
                                    DamageCap = 1160000,
                                }.ToByteString(),
                            },
                            ApplyStatusEffect.FromTemplate(
                                new ApplyStatusEffect
                                {
                                    EffectTargettingType = EffectTargettingType.OnSelf,
                                },
                                (StatusEffectLibrary.TripleAttackRateUpNpc, 100),
                                (StatusEffectLibrary.AdditionalWaterDamageNpc, 70)),
                        },
                    },
                },
                UpgradedAbilities =
                {
                    new AbilityUpgrade
                    {
                        Ability = ManaBlast(cooldown: 6),
                        RequiredLevel = 55,
                        UpgradedAbilityIndex = 0,
                    },
                    new AbilityUpgrade
                    {
                        Ability = TyrosAggeris(cooldown: 12),
                        RequiredLevel = 75,
                        UpgradedAbilityIndex = 1,
                    },
                },
                PassiveAbilities =
                {
                    new PassiveAbility
                    {
                        Name = "Fountain Lotus",
                        Description = "Fountain Lotus lvl rises by 1 upon triple attack.",
                    },
                    new PassiveAbility
                    {
                        Name = "Heavenly Allure",
                        Description = "Allies gain an additional boost to Water ATK when affected by Water ATK UP.",
                    },
                },
                SpecialAbility = new SpecialAbility
                {
                    Name = "Taurus Blight",
                    ModelMetadata =
                    {
                        new ModelMetadata
                        {
                            ConstructorName = "mc_nsp_3040190000_01_s2_special",
                            JsAssetPath = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/model/0/nsp_3040190000_01_s2.js",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040190000_01_s2_a",
                                    Path = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/model/0/nsp_3040190000_01_s2_a.png",
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040190000_01_s2_b",
                                    Path = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/model/0/nsp_3040190000_01_s2_b.png",
                                },
                            },
                        },
                        new ModelMetadata
                        {
                            ConstructorName = "mc_nsp_3040190000_02_s2_special",
                            JsAssetPath = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/model/1/nsp_3040190000_02_s2.js",
                            ImageAssets =
                            {
                                new ImageAsset
                                {
                                    Name = "nsp_3040190000_02_s2_a",
                                    Path = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/model/1/nsp_3040190000_02_s2_a.png",
                                },
                                new ImageAsset
                                {
                                    Name = "nsp_3040190000_02_s2_b",
                                    Path = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/model/1/nsp_3040190000_02_s2_b.png",
                                },
                            },
                        },
                    },
                    HitCount = { 21, 21 },
                    ProcessEffects = (europa, raidActions) =>
                    {
                        europa.Raid.Allies.ApplyStatusEffects(
                            new StatusEffectSnapshot
                            {
                                Id = "europa/aldebaran_afterglow",
                                TurnDuration = 4,
                                Modifier = ModifierLibrary.FlatTripleAttackRateBoost,
                                Strength = 20,
                            }, raidActions);
                    },
                    FrameToSkipToOnAnimationSkip = { 80, 80 },
                    ConstructorNameOnAnimationSkip = { "mc_nsp_3040190000_01_s2_mortal_vibration", "mc_nsp_3040190000_01_s2_mortal_vibration" },
                },
                ModelMetadata =
                {
                    new ModelMetadata
                    {
                        ConstructorName = "mc_npc_3040190000_01",
                        JsAssetPath = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/model/0/npc_3040190000_01.js",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040190000_01",
                                Path = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/model/0/npc_3040190000_01.png",
                            },
                        },
                    },
                    new ModelMetadata
                    {
                        ConstructorName = "mc_npc_3040190000_02",
                        JsAssetPath = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/model/1/npc_3040190000_02.js",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "npc_3040190000_02",
                                Path = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/model/1/npc_3040190000_02.png",
                            },
                        },
                    },
                },
                OnHitEffectModelMetadata =
                {
                    new ModelMetadata
                    {
                        ConstructorName = "mc_phit_3040190000_02",
                        JsAssetPath = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/model/1/phit_3040190000_02.js",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040190000_02",
                                Path = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/model/1/phit_3040190000_02.png",
                            },
                        },
                    },
                    new ModelMetadata
                    {
                        ConstructorName = "mc_phit_3040190000_02",
                        JsAssetPath = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/model/1/phit_3040190000_02.js",
                        ImageAssets =
                        {
                            new ImageAsset
                            {
                                Name = "phit_3040190000_02",
                                Path = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/model/1/phit_3040190000_02.png",
                            },
                        },
                    },
                },
                OnActionStart = (europa, _, raidActions) => ProcessEuropaPassiveEffects(europa),
                OnEnteringFrontline = (europa, raidActions) => ProcessEuropaPassiveEffects(europa),
                OnAttackEnd = (europa, attackResult, raidActions) =>
                {
                    if (!europa.IsAlive())
                    {
                        return;
                    }

                    if (attackResult == EntitySnapshot.AttackResult.Triple)
                    {
                        europa.ApplyOrOverrideStatusEffectStacks(FountainLotusId, initialStackCount: 1, increment: 1, maxStackCount: 5, raidActions: raidActions, isUndispellable: true);
                    }

                    TryProcessFountainLotusEffects(europa);
                },
                OnDeath = (europa, raidActions) =>
                {
                    foreach (var hero in europa.Raid.Allies)
                    {
                        if (hero.PositionInFrontline < 4)
                        {
                            hero.RemoveStatusEffect(StatusEffectLibrary.WaterElementalAttackBoostAmplificationNpc);
                        }
                    }
                },
                OnTurnEnd = (europa, raidActions) =>
                {
                    foreach (var ally in europa.Raid.Allies)
                    {
                        if (!ally.IsAlive() || ally.PositionInFrontline >= 4 || !ally.TookDamageDuringTurn)
                        {
                            continue;
                        }

                        var stacks = ally.GetStatusEffectStacks(StarSanctuaryId);
                        if (stacks > 0)
                        {
                            if (!ally.OverrideStatusEffectStacks(StarSanctuaryId, increment: -1, maxStackCount: 2, raidActions: raidActions))
                            {
                                // The amount of Star Sanctuary stacks reached 0
                                ally.RemoveStatusEffects(new HashSet<string> { $"{StarSanctuaryId}/atk_up", $"{StarSanctuaryId}/dmg_reduction", StatusEffectLibrary.FireSwitch });
                            }
                        }
                    }
                },
            };
        }

        private static Ability ManaBlast(uint cooldown)
        {
            return new Ability
            {
                Name = "Mana Blast",
                Description = "3-hit Water damage to random foes. Restore all allies' HP and remove 1 debuff.",
                Type = Ability.Types.AbilityType.Offensive,
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    ConstructorName = "mc_ab_all_3040190000_01",
                    JsAssetPath = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/abilities/0/ability.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040190000_01",
                            Path =
                                "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/abilities/0/ab_all_3040190000_01.png",
                        },
                    },
                },
                AnimationName = "ab_motion",
                Effects =
                {
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.MultihitDamage,
                        ExtraData = new MultihitDamage
                        {
                            Element = Element.Water,
                            HitNumber = 3,
                            DamageModifier = 4,
                            DamageCap = 230000,
                            RandomTargets = true,
                        }.ToByteString(),
                    },
                    new AbilityEffect
                    {
                        Type = AbilityEffect.Types.AbilityEffectType.Healing,
                        ExtraData = new Heal
                        {
                            HpPercentageRecovered = 30,
                            HealingCap = 2000,
                            EffectTargettingType = EffectTargettingType.OnAllPartyMembers,
                        }.ToByteString(),
                    },
                },
            };
        }

        private static Ability TyrosAggeris(uint cooldown)
        {
            return new Ability
            {
                Name = "Tyros Aggeris",
                Description = "All allies gain Star Sanctuary.",
                Type = Ability.Types.AbilityType.Defensive,
                Cooldown = (int)cooldown,
                ModelMetadata = new ModelMetadata
                {
                    ConstructorName = "mc_ab_all_3040190000_02",
                    JsAssetPath = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/abilities/1/ability.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ab_all_3040190000_02",
                            Path = "npc/6da988da-cb06-4710-acd3-d8bd006ae7dd/abilities/1/ab_all_3040190000_02.png",
                        },
                    },
                },
                ProcessEffects = (europa, _, raidActions) =>
                {
                    foreach (var ally in europa.Raid.Allies)
                    {
                        if (!ally.IsAlive() || ally.PositionInFrontline >= 4)
                        {
                            continue;
                        }

                        ally.ApplyOrOverrideStatusEffectStacks(StarSanctuaryId, initialStackCount: 2, increment: 2, maxStackCount: 2, raidActions, isUndispellable: true);
                        ally.ApplyStatusEffect(
                            new StatusEffectSnapshot
                            {
                                Id = $"{StarSanctuaryId}/dmg_reduction",
                                TurnDuration = int.MaxValue,
                                IsUndispellable = true,
                                IsUsedInternally = true,
                                Modifier = ModifierLibrary.DamageReductionBoost,
                                AttackElementRestriction = Element.Fire,
                                Strength = 50,
                            });
                    }

                    europa.Raid.Allies.ApplyStatusEffectsFromTemplate(
                        new StatusEffectSnapshot
                        {
                            TurnDuration = int.MaxValue,
                            IsUndispellable = true,
                            IsUsedInternally = true,
                        },
                        ($"{StarSanctuaryId}/atk_up", ModifierLibrary.FlatAttackBoost, 15),
                        (StatusEffectLibrary.FireSwitch, ModifierLibrary.None, 0));
                },
                AnimationName = "ab_motion",
            };
        }

        private static void TryProcessFountainLotusEffects(EntitySnapshot europa)
        {
            if (!europa.IsAlive() || europa.PositionInFrontline >= 4)
            {
                return;
            }

            var fountainLotusStacks = europa.GetStatusEffectStacks(FountainLotusId);
            europa.ApplyStatusEffectsFromTemplate(
                new StatusEffectSnapshot
                {
                    IsUndispellable = true,
                    IsUsedInternally = true,
                },
                ($"{FountainLotusId}/atk_up", ModifierLibrary.FlatAttackBoost, fountainLotusStacks * 10),
                ($"{FountainLotusId}/healing_up", ModifierLibrary.HealingBoost, fountainLotusStacks * 20),
                ($"{FountainLotusId}/healing_cap_up", ModifierLibrary.HealingCapBoost, fountainLotusStacks * 20));
        }

        private static void ProcessEuropaPassiveEffects(EntitySnapshot europa)
        {
            if (!europa.IsAlive() || europa.PositionInFrontline >= 4)
            {
                return;
            }

            TryProcessFountainLotusEffects(europa);

            foreach (var hero in europa.Raid.Allies)
            {
                if (hero.IsAlive() && hero.PositionInFrontline < 4)
                {
                    hero.ApplyStatusEffect(new StatusEffectSnapshot
                    {
                        Strength = 30,
                        Id = StatusEffectLibrary.WaterElementalAttackBoostAmplificationNpc,
                        IsPassiveEffect = true,
                        IsUsedInternally = true,
                    });
                }
            }
        }
    }
}
