// <copyright file="HighLevelBahamutFireTrailblazerStrategy.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Bots.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Worldshifters.Bots.Strategy.RaidAction;
    using Worldshifters.Data.Raid;

    public class HighLevelBahamutFireTrailblazerStrategy : RaidStrategy
    {
        // Use mock IDs for example purposes
        private static readonly int ElysianJobId = 0;
        private static readonly Guid NayaId = Assets.Hero.Fire.Naya.Id;
        private static readonly Guid ShivaId = Guid.Empty;
        private static readonly Guid TienId = Guid.Empty;
        private static readonly Guid JeanneDArcId = Guid.Empty;

        private static readonly Guid Ullikummi = Guid.Empty;
        private static readonly Guid IxabaId = Guid.Empty;
        private static readonly Guid ScytheOfRenunciation = Guid.Empty;
        private static readonly Guid SolRemnant = Guid.Empty;

        private static readonly Guid AgniSummonId = Guid.Empty;
        private static readonly Guid MichaelSummonId = Guid.Empty;
        private static readonly Guid ShivaSummonId = Guid.Empty;
        private static readonly Guid TheSunSummonId = Guid.Empty;

        private bool burstSetupComplete = false;

        /// <summary>
        /// <remarks>Validation is performed by the core library.</remarks>
        /// </summary>
        protected override IReadOnlyList<Guid> GetEquipmentLoadout()
        {
            // Main hand + rest of the grid (9 slots)
            return new[]
            {
                Ullikummi, // Main hand
                IxabaId,
                IxabaId,
                IxabaId,
                IxabaId,
                IxabaId,
                IxabaId,
                IxabaId,
                ScytheOfRenunciation,
                SolRemnant,
            };
        }

        /// <summary>
        /// <remarks>Validation is performed by the core library.</remarks>
        /// </summary>
        protected override (int classId, IReadOnlyList<Guid> heroIds) GetHeroLayout()
        {
            return (ElysianJobId, new[] { ShivaId, TienId, JeanneDArcId, NayaId });
        }

        protected override IReadOnlyList<Guid> GetSummonLoadout()
        {
            // Main summon + rest of the summons + support summon
            return new[] { AgniSummonId, ShivaSummonId, ShivaSummonId, MichaelSummonId, TheSunSummonId, ShivaSummonId };
        }

        protected override NextRaidAction GetNextRaidAction(RaidSnapshot raidSnapshot)
        {
            if (raidSnapshot.Turn == 0)
            {
                return DisableChargeAttack.Action.ContinueWith(_1 =>
                    _1.GetAvatar().UseAbility(0).ContinueWith(_2 =>
                    _2.GetHeroById(JeanneDArcId).UseAbility(3).ContinueWith(_3 =>
                    _3.GetHeroById(ShivaId).UseAbility(0).ContinueWith(_4 =>
                    _4.GetHeroById(NayaId).UseAbility(2).ContinueWith(_5 =>
                    _5.UseSummon(TheSunSummonId).ContinueWith(_6 =>
                    _6.Attack()))))));
            }

            if (raidSnapshot.Turn <= 10 && ShouldLeaveRaid(raidSnapshot))
            {
                return Terminate.Action;
            }

            if (raidSnapshot.Turn == 6)
            {
                return raidSnapshot.GetHeroById(NayaId).UseAbility(0).ContinueWith(_ => _.Attack());
            }

            if (raidSnapshot.Turn == 9)
            {
                // Shiva party buff -> Triple attack burst time
                return raidSnapshot.GetHeroById(ShivaId).UseAbility(1).ContinueWith(_1 =>
                    _1.GetHeroById(NayaId).UseAbility(1).ContinueWith(_2 =>
                    _2.UseSummon(ShivaSummonId).ContinueWith(_3 =>
                    _3.Attack())));
            }

            if (raidSnapshot.Turn == 10)
            {
                // Tien assassin break burst time
                if (!this.burstSetupComplete)
                {
                    raidSnapshot.GetAvatar().UseAbility(0).ContinueWith(_1 =>
                        _1.GetHeroById(TienId).UseAbility(1).ContinueWith(_2 =>
                        _2.GetHeroById(TienId).UseAbility(3).ContinueWith(_3 =>
                        _3.UseSummon(TheSunSummonId).ContinueWith(_ =>
                            {
                                this.burstSetupComplete = true;
                                return Pass.Action;
                            }))));
                }

                // If for some reason Bahamut has still not moved into its wind phase, wait for it to for damage optimization
                return raidSnapshot.Enemies[0].HpPercentage > 60 ? (NextRaidAction)Wait.For(50) : raidSnapshot.Attack();
            }

            if (raidSnapshot.Turn == 11)
            {
                return raidSnapshot.UseSummon(ShivaSummonId).ContinueWith(_ => _.Attack());
            }

            if (raidSnapshot.Turn == 12)
            {
                // Stack up Tien's ability 3 echoes
                raidSnapshot.GetHeroById(TienId).UseAbility(2).ContinueWith(_1 =>
                    _1.UseSummon(ShivaSummonId).ContinueWith(_2 =>
                    _2.Attack()));
            }

            return new Attack
            {
                TargetIndex = 0,
                EnableChargeAttack = false,
            };
        }

        /// <summary>
        /// Leave the raid if win condition is gone (front line alive)
        /// </summary>
        private static bool ShouldLeaveRaid(RaidSnapshot raidSnapshot)
        {
            return raidSnapshot.Allies.Any(hero => !hero.IsAlive());
        }
    }
}
