// <copyright file="Bahamut.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Npc.Dark
{
    using System.Collections.Generic;
    using System.Linq;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;
    using Worldshifters.Data.Npc;
    using Worldshifters.Data.Npc.Abilities;
    using Worldshifters.Data.Raid;
    using Worldshifters.Data.Utils;

    public static class Bahamut
    {
        public static ByteString Id = ByteString.CopyFromUtf8("bahamut");

        private const string RagnarokFieldId = "bahamut/ragnarok_field";
        private const int InitialForm = 0;
        private const int FireForm = 1;
        private const int WaterForm = 2;
        private const int EarthForm = 3;
        private const int WindForm = 4;
        private const int DarkForm = 5;
        private const int FinalForm = 6;

        public static Npc NewInstance()
        {
            return new Npc
            {
                Id = Id,
                Name = "Bahamut",
                Gender = Gender.Unknown,
                Attack = 0,
                MaxHp = 1_500_000_000,
                Level = 150,
                Description = string.Empty,
                Defense = 20,
                Element = Element.Dark,
                MaxChargeDiamonds = 3,
                ModelMetadata = new ModelMetadata
                {
                    ConstructorName = "mc_enemy_7300293",
                    JsAssetPath = "npc/bahamut/model/enemy_7300293.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "enemy_7300293_a",
                            Path = "npc/bahamut/model/enemy_7300293_a.png",
                        },
                        new ImageAsset
                        {
                            Name = "enemy_7300293_b",
                            Path = "npc/bahamut/model/enemy_7300293_b.png",
                        },
                    },
                    DisplayRegistrationPointX = 80,
                    DisplayRegistrationPointY = -120,
                },
                OnHitEffectModelMetadata = new ModelMetadata
                {
                    ConstructorName = "mc_ehit_7300213_all_effect",
                    JsAssetPath = "npc/bahamut/model/ehit_7300213_all.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ehit_7300213_all",
                            Path = "npc/bahamut/model/ehit_7300213_all.png",
                        },
                    },
                },
                OnSetup = (bahamut) =>
                {
                    bahamut.GlobalState.Add("form", TypedValue.FromLong(InitialForm));
                    bahamut.MaxChargeDiamonds = 3;
                },
                OnActionStart = (bahamut, raidActions) =>
                {
                },
                OnSpecialAttackStart = (bahamut, raidActions) =>
                {
                    if (bahamut.GlobalState["form"].IntegerValue == InitialForm)
                    {
                        Reginleiv(bahamut, raidActions);
                    }
                    else if (bahamut.GlobalState["form"].IntegerValue == FireForm)
                    {
                        if (bahamut.IsInOverdriveMode())
                        {
                            if (ThreadSafeRandom.NextDouble() < 0.5)
                            {
                                FireIV(bahamut, raidActions);
                            }
                            else
                            {
                                ScarletRain(bahamut, raidActions);
                            }
                        }
                        else
                        {
                            FireIV(bahamut, raidActions);
                        }
                    }
                    else if (bahamut.GlobalState["form"].IntegerValue == WaterForm)
                    {
                        if (bahamut.IsInOverdriveMode())
                        {
                            if (ThreadSafeRandom.NextDouble() < 0.5)
                            {
                                FreezeIV(bahamut, raidActions);
                            }
                            else
                            {
                                SilverWave(bahamut, raidActions);
                            }
                        }
                        else
                        {
                            FreezeIV(bahamut, raidActions);
                        }
                    }
                },
                OnAttackStart = (bahamut, raidActions) =>
                {
                    if (bahamut.Raid.Turn == 0)
                    {
                        RagnarokFieldII(bahamut, raidActions);
                        bahamut.NoChargeDiamondGainThisTurn = true;
                        return false;
                    }

                    return true;
                },
                OnTurnEnd = (bahamut, raidActions) =>
                {
                    foreach (var enemy in bahamut.Raid.Enemies)
                    {
                        if (enemy.IsAlive() && enemy.PositionInFrontline < 4 && enemy.GetStatusEffects().Any(e => e.Id == RagnarokFieldId))
                        {
                            enemy.DealRawDamage((long)(enemy.MaxHp * 0.05 / bahamut.Raid.NumParticipants), Element.Null, raidActions);
                        }
                    }

                    if (bahamut.HpPercentage <= 25)
                    {
                        ChangeToFinalForm(bahamut, raidActions);
                    }
                    else if (bahamut.HpPercentage <= 50)
                    {
                        ChangeToDarkForm(bahamut, raidActions);
                    }
                    else if (bahamut.HpPercentage <= 60)
                    {
                        ChangeToWindForm(bahamut, raidActions);
                    }
                    else if (bahamut.HpPercentage <= 70)
                    {
                        ChangeToEarthForm(bahamut, raidActions);
                    }
                    else if (bahamut.HpPercentage <= 80)
                    {
                        ChangeToWaterForm(bahamut, raidActions);
                    }
                    else if (bahamut.HpPercentage <= 90)
                    {
                        ChangeToFireForm(bahamut, raidActions);
                    }
                },
                OnHitEffectDelaysInMs = { 180, 180, 180 },
            };
        }

        private static void ChangeToFireForm(EntitySnapshot bahamut, IList<RaidAction> raidActions)
        {
            if (bahamut.GlobalState.ContainsKey("fire_form"))
            {
                return;
            }

            bahamut.GlobalState.Add("fire_form", TypedValue.FromBool(true));
            bahamut.GlobalState["form"] = TypedValue.FromLong(FireForm);
            bahamut.Element = Element.Fire;

            bahamut.PlayAnimation("form_change", raidActions, applyToAllRaidParticipants: true);
            bahamut.ChangeForm(
                new ModelMetadata
                {
                    ConstructorName = "mc_enemy_7300253",
                    JsAssetPath = "npc/bahamut/model/enemy_7300253.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "enemy_7300253_a",
                            Path = "npc/bahamut/model/enemy_7300253_a.png",
                        },
                        new ImageAsset
                        {
                            Name = "enemy_7300253_b",
                            Path = "npc/bahamut/model/enemy_7300253_b.png",
                        },
                    },
                    DisplayRegistrationPointX = 80,
                    DisplayRegistrationPointY = -120,
                }, raidActions);

            bahamut.Raid.ChangeBackground("npc/bahamut/model/common_014.jpg", raidActions, applyToAllRaidParticipants: true);
            bahamut.FillDiamonds(raidActions, applyToAllRaidParticipants: true);
        }

        private static void ChangeToWaterForm(EntitySnapshot bahamut, IList<RaidAction> raidActions)
        {
            if (bahamut.GlobalState.ContainsKey("water_form"))
            {
                return;
            }

            bahamut.GlobalState.Add("water_form", TypedValue.FromBool(true));
            bahamut.GlobalState["form"] = TypedValue.FromLong(WaterForm);
            bahamut.Element = Element.Water;

            bahamut.PlayAnimation("form_change", raidActions, applyToAllRaidParticipants: true);
            bahamut.ChangeForm(
                new ModelMetadata
                {
                    ConstructorName = "mc_enemy_7300263",
                    JsAssetPath = "npc/bahamut/model/enemy_7300263.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "enemy_7300263_a",
                            Path = "npc/bahamut/model/enemy_7300263_a.png",
                        },
                        new ImageAsset
                        {
                            Name = "enemy_7300263_b",
                            Path = "npc/bahamut/model/enemy_7300263_b.png",
                        },
                    },
                    DisplayRegistrationPointX = 80,
                    DisplayRegistrationPointY = -120,
                }, raidActions);

            bahamut.Raid.ChangeBackground("npc/bahamut/model/common_016.jpg", raidActions, applyToAllRaidParticipants: true);
            bahamut.FillDiamonds(raidActions, applyToAllRaidParticipants: true);
        }

        private static void ChangeToEarthForm(EntitySnapshot bahamut, IList<RaidAction> raidActions)
        {
            if (bahamut.GlobalState.ContainsKey("earth_form"))
            {
                return;
            }

            bahamut.GlobalState.Add("earth_form", TypedValue.FromBool(true));
            bahamut.GlobalState["form"] = TypedValue.FromLong(EarthForm);
            bahamut.Element = Element.Earth;

            bahamut.PlayAnimation("form_change", raidActions, applyToAllRaidParticipants: true);
            bahamut.ChangeForm(
                new ModelMetadata
                {
                    ConstructorName = "mc_enemy_7300273",
                    JsAssetPath = "npc/bahamut/model/enemy_7300273.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "enemy_7300273_a",
                            Path = "npc/bahamut/model/enemy_7300273_a.png",
                        },
                        new ImageAsset
                        {
                            Name = "enemy_7300273_b",
                            Path = "npc/bahamut/model/enemy_7300273_b.png",
                        },
                    },
                    DisplayRegistrationPointX = 80,
                    DisplayRegistrationPointY = -120,
                }, raidActions);

            bahamut.Raid.ChangeBackground("npc/bahamut/model/common_018.jpg", raidActions, applyToAllRaidParticipants: true);
            bahamut.FillDiamonds(raidActions, applyToAllRaidParticipants: true);
        }

        private static void ChangeToWindForm(EntitySnapshot bahamut, IList<RaidAction> raidActions)
        {
            if (bahamut.GlobalState.ContainsKey("wind_form"))
            {
                return;
            }

            bahamut.GlobalState.Add("wind_form", TypedValue.FromBool(true));
            bahamut.GlobalState["form"] = TypedValue.FromLong(WindForm);
            bahamut.Element = Element.Wind;

            bahamut.PlayAnimation("form_change", raidActions, applyToAllRaidParticipants: true);
            bahamut.ChangeForm(
                new ModelMetadata
                {
                    ConstructorName = "mc_enemy_7300283",
                    JsAssetPath = "npc/bahamut/model/enemy_7300283.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "enemy_7300283_a",
                            Path = "npc/bahamut/model/enemy_7300283_a.png",
                        },
                        new ImageAsset
                        {
                            Name = "enemy_7300283_b",
                            Path = "npc/bahamut/model/enemy_7300283_b.png",
                        },
                    },
                    DisplayRegistrationPointX = 80,
                    DisplayRegistrationPointY = -120,
                }, raidActions);

            bahamut.Raid.ChangeBackground("npc/bahamut/model/common_012.jpg", raidActions, applyToAllRaidParticipants: true);
            bahamut.FillDiamonds(raidActions, applyToAllRaidParticipants: true);
        }

        private static void ChangeToDarkForm(EntitySnapshot bahamut, IList<RaidAction> raidActions)
        {
            if (bahamut.GlobalState.ContainsKey("dark_form"))
            {
                return;
            }

            bahamut.GlobalState.Add("dark_form", TypedValue.FromBool(true));
            bahamut.GlobalState["form"] = TypedValue.FromLong(DarkForm);
            bahamut.Element = Element.Dark;

            bahamut.PlayAnimation("form_change", raidActions, applyToAllRaidParticipants: true);
            bahamut.ChangeForm(
                new ModelMetadata
                {
                    ConstructorName = "mc_enemy_7300303",
                    JsAssetPath = "npc/bahamut/model/enemy_7300303.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "enemy_7300303_a",
                            Path = "npc/bahamut/model/enemy_7300303_a.png",
                        },
                        new ImageAsset
                        {
                            Name = "enemy_7300303_b",
                            Path = "npc/bahamut/model/enemy_7300303_b.png",
                        },
                        new ImageAsset
                        {
                            Name = "enemy_7300303_c",
                            Path = "npc/bahamut/model/enemy_7300303_c.png",
                        },
                    },
                    DisplayRegistrationPointX = 80,
                    DisplayRegistrationPointY = -120,
                },
                raidActions,
                new ModelMetadata
                {
                    ConstructorName = "mc_ehit_7300223_effect",
                    JsAssetPath = "npc/bahamut/model/ehit_7300223.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ehit_7300213_ef41",
                            Path = "npc/bahamut/model/ehit_7300213_ef41.png",
                        },
                    },
                });

            bahamut.Raid.ChangeBackground("npc/bahamut/model/common_024.jpg", raidActions, applyToAllRaidParticipants: true);
            bahamut.FillDiamonds(raidActions, applyToAllRaidParticipants: true);
        }

        private static void ChangeToFinalForm(EntitySnapshot bahamut, IList<RaidAction> raidActions)
        {
            if (bahamut.GlobalState.ContainsKey("final_form"))
            {
                return;
            }

            bahamut.GlobalState.Add("final_form", TypedValue.FromBool(true));
            bahamut.GlobalState["form"] = TypedValue.FromLong(FinalForm);
            bahamut.Element = Element.Dark;

            bahamut.PlayAnimation("form_change", raidActions, applyToAllRaidParticipants: true);
            bahamut.ChangeForm(
                new ModelMetadata
                {
                    ConstructorName = "mc_enemy_7300313",
                    JsAssetPath = "npc/bahamut/model/enemy_7300313.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "enemy_7300313_a",
                            Path = "npc/bahamut/model/enemy_7300313_a.png",
                        },
                        new ImageAsset
                        {
                            Name = "enemy_7300313_b",
                            Path = "npc/bahamut/model/enemy_7300313_b.png",
                        },
                        new ImageAsset
                        {
                            Name = "enemy_7300313_c",
                            Path = "npc/bahamut/model/enemy_7300313_c.png",
                        },
                    },
                    DisplayRegistrationPointX = 80,
                    DisplayRegistrationPointY = -120,
                },
                raidActions,
                new ModelMetadata
                {
                    ConstructorName = "mc_ehit_7300223_effect",
                    JsAssetPath = "npc/bahamut/model/ehit_7300223.js",
                    ImageAssets =
                    {
                        new ImageAsset
                        {
                            Name = "ehit_7300213_ef41",
                            Path = "npc/bahamut/model/ehit_7300213_ef41.png",
                        },
                    },
                });

            bahamut.Raid.ChangeBackground("npc/bahamut/model/common_024.jpg", raidActions, applyToAllRaidParticipants: true);
            bahamut.FillDiamonds(raidActions, applyToAllRaidParticipants: true);
        }

        private static void RagnarokFieldII(EntitySnapshot bahamut, IList<RaidAction> raidActions)
        {
            bahamut.PlayAnimation("mortal_C", raidActions);
            foreach (var enemy in bahamut.Raid.Enemies)
            {
                enemy.ApplyStatusEffectsFromTemplate(
                    new StatusEffectSnapshot
                    {
                        BaseAccuracy = double.MaxValue,
                        TurnDuration = 4,
                    },
                    raidActions,
                    (StatusEffectLibrary.Cursed, ModifierLibrary.CantBeHealed, 0),
                    (StatusEffectLibrary.ChargeAttackSealed, ModifierLibrary.CantUseChargeAttack, 0),
                    (StatusEffectLibrary.SkillSealed, ModifierLibrary.CantUseSkills, 0));

                enemy.ApplyStatusEffect(
                    new StatusEffectSnapshot
                    {
                        Id = RagnarokFieldId,
                        BaseAccuracy = double.MaxValue,
                        TurnDuration = int.MaxValue,
                    },
                    raidActions);
            }
        }

        private static void Reginleiv(EntitySnapshot bahamut, IList<RaidAction> raidActions)
        {
            bahamut.PerformChargeAttack(
                30,
                new ModelMetadata
                {
                    ConstructorName = "mc_esp_7300213_01_special",
                    JsAssetPath = "npc/bahamut/model/esp_7300213_01.js",
                },
                0.4,
                raidActions,
                isMultiElement: true);
        }

        private static void FireIV(EntitySnapshot bahamut, IList<RaidAction> raidActions)
        {
            bahamut.PerformChargeAttack(
                1,
                new ModelMetadata
                {
                    ConstructorName = "mc_esp_7300253_01_special",
                    JsAssetPath = "npc/bahamut/model/esp_7300253_01.js",
                },
                1,
                raidActions,
                onAllEnemies: true,
                attackElement: Element.Fire);

            bahamut.Raid.Enemies.ApplyStatusEffects(
                    new StatusEffectSnapshot
                    {
                        Id = StatusEffectLibrary.BurntNpc,
                        BaseAccuracy = 100,
                        TurnDuration = 6,
                        Strength = 5,
                        ExtraData = new Burn
                        {
                            IsPercentageBased = true,
                        }.ToByteString(),
                    },
                    raidActions);
        }

        private static void ScarletRain(EntitySnapshot bahamut, IList<RaidAction> raidActions)
        {
            bahamut.PerformChargeAttack(
                1,
                new ModelMetadata
                {
                    ConstructorName = "mc_esp_7300253_03_special",
                    JsAssetPath = "npc/bahamut/model/esp_7300253_03.js",
                },
                1,
                raidActions,
                onAllEnemies: true,
                attackElement: Element.Fire);

            bahamut.Raid.Enemies.ApplyStatusEffects(
                    new StatusEffectSnapshot
                    {
                        Id = StatusEffectLibrary.SkillSealed,
                        BaseAccuracy = 100,
                        TurnDuration = 6,
                    },
                    raidActions);
        }

        private static void FreezeIV(EntitySnapshot bahamut, IList<RaidAction> raidActions)
        {
            bahamut.PerformChargeAttack(
                1,
                new ModelMetadata
                {
                    ConstructorName = "mc_esp_7300263_01_special",
                    JsAssetPath = "npc/bahamut/model/esp_7300263_01.js",
                },
                1,
                raidActions,
                onAllEnemies: true,
                attackElement: Element.Water);

            foreach (var enemy in bahamut.Raid.Enemies)
            {
                if (enemy.IsAlive() && enemy.PositionInFrontline < 4)
                {
                    Abilities.ApplyGlaciateEffect(enemy, 5, raidActions);
                }
            }
        }

        private static void SilverWave(EntitySnapshot bahamut, IList<RaidAction> raidActions)
        {
            bahamut.PerformChargeAttack(
                1,
                new ModelMetadata
                {
                    ConstructorName = "mc_esp_7300263_03_special",
                    JsAssetPath = "npc/bahamut/model/esp_7300263_03.js",
                },
                1,
                raidActions,
                onAllEnemies: true,
                attackElement: Element.Fire);

            bahamut.Raid.Enemies.ApplyStatusEffects(
                    new StatusEffectSnapshot
                    {
                        Id = StatusEffectLibrary.Asleep,
                        BaseAccuracy = 50,
                        TurnDuration = 6 + (ThreadSafeRandom.Next() % 2),
                        ExtraData = new Asleep
                        {
                            DamageTakenAmplification = 25,
                            WakeUpOnTakingDamage = true,
                        }.ToByteString(),
                    },
                    raidActions);
        }

        private static void Skyfall(EntitySnapshot bahamut, IList<RaidAction> raidActions)
        {
            bahamut.PerformChargeAttack(
                1,
                new ModelMetadata
                {
                    ConstructorName = "mc_esp_7300223_03_special",
                    JsAssetPath = "npc/bahamut/model/esp_7300223_03.js",
                },
                999_999,
                raidActions,
                onAllEnemies: true,
                isFlatDamage: true);
        }
    }
}
