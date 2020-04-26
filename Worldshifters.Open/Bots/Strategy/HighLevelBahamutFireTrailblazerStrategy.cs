// <copyright file="HighLevelBahamutFireTrailblazerStrategy.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Bots.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Worldshifters.Bots.Strategy.RaidAction;
    using Worldshifters.Data.Bots.Strategy.RaidAction;
    using Worldshifters.Data.Raid;

    public class HighLevelBahamutFireTrailblazerStrategy : RaidStrategy
    {
        // Use mock IDs for example purposes
        private static readonly int NekomancerJobId = 0;
        private static readonly Guid NayaId = Assets.Hero.Fire.Naya.Id;
        private static readonly Guid ShivaId = Guid.Parse("----");
        private static readonly Guid TienId = Guid.Parse("----");
        private static readonly Guid YayaId = Guid.Parse("----");
        private static readonly Guid SevastienId = Guid.Parse("----");

        private static readonly Guid ColossusCaneOmega = Guid.Parse("----");
        private static readonly Guid IxabaId = Guid.Parse("----");
        private static readonly Guid ScytheOfRenunciation = Guid.Parse("----");
        private static readonly Guid SolRemnant = Guid.Parse("----");

        private static readonly Guid AgniSummonId = Guid.Parse("----");
        private static readonly Guid MichaelSummonId = Guid.Parse("----");
        private static readonly Guid ShivaSummonId = Guid.Parse("----");
        private static readonly Guid TheSunSummonId = Guid.Parse("----");

        /// <summary>
        /// <remarks>Validation is performed by the core library.</remarks>
        /// </summary>
        public IReadOnlyList<Guid> GetEquipmentLoadout()
        {
            // Main hand + rest of the grid (9 slots)
            return new[]
            {
                ColossusCaneOmega, // Main hand
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
        public (int classId, IReadOnlyList<Guid> heroIds) GetHeroLayout()
        {
            return (NekomancerJobId, new[] { NayaId, ShivaId, TienId, YayaId, SevastienId });
        }

        /// <summary>
        /// <remarks>Validation is performed by the core library.</remarks>
        /// </summary>
        public IReadOnlyList<Guid> GetSummonLoadout()
        {
            // Main summon + rest of the summons + support summon
            return new[] { AgniSummonId, ShivaSummonId, ShivaSummonId, ShivaSummonId, MichaelSummonId, TheSunSummonId, ShivaId };
        }

        /// <summary>
        /// <remarks>Any raised exception will terminate the strategy.</remarks>
        /// </summary>
        public override NextRaidAction GetNextRaidAction(RaidSnapshot raidSnapshot)
        {
            if (raidSnapshot.Turn == 1)
            {
                return Turn1Setup(raidSnapshot);
            }

            if (raidSnapshot.Turn <= 11 && ShouldLeaveRaid(raidSnapshot))
            {
                return Terminate.Action;
            }

            if (raidSnapshot.Turn == 7)
            {
                return raidSnapshot.GetHeroById(NayaId).UseAbility(0);
            }

            if (raidSnapshot.Turn == 10)
            {
                // Shiva party buff -> Triple attack burst time
                return raidSnapshot.GetHeroById(ShivaId).UseAbility(1).ContinueWith(_1 =>
                    _1.GetHeroById(NayaId).UseAbility(1).ContinueWith(_2 =>
                    _2.UseSummon(ShivaSummonId).ContinueWith(_3 =>
                    _3.Attack())));
            }

            if (raidSnapshot.Turn == 11)
            {
                // Tien assassin break burst time
                raidSnapshot.GetHeroById(TienId).UseAbility(1).ContinueWith(_1 =>
                    _1.GetHeroById(TienId).UseAbility(3).ContinueWith(_2 =>
                    _2.UseSummon(TheSunSummonId).ContinueWith(_3 =>
                    // If for some reason Bahamut has still not moved into its wind phase, wait for it to for damage optimization
                    _3.Enemies[0].HpPercentage > 60 ? (NextRaidAction)Wait.For(50) : _3.Attack())));
            }

            if (raidSnapshot.Turn == 12)
            {
                return raidSnapshot.UseSummon(ShivaSummonId).ContinueWith(_ => _.Attack());
            }

            if (raidSnapshot.Turn == 13)
            {
                // Stack up Tien's ability 2 echoes
                raidSnapshot.GetHeroById(TienId).UseAbility(1).ContinueWith(_1 =>
                    _1.UseSummon(ShivaSummonId).ContinueWith(_2 =>
                    _2.Attack()));
            }

            if (raidSnapshot.Turn == 14)
            {
                return raidSnapshot.UseSummon(ShivaSummonId).ContinueWith(_ => _.Attack());
            }

            return new Attack
            {
                TargetIndex = 0,
                EnableChargeAttack = false,
            };
        }

        // Disable charge attack -> Shiva ability 1 -> Naya ability 2 -> Summon the Sun -> Attack
        private static NextRaidAction Turn1Setup(RaidSnapshot raidSnapshot)
        {
            return DisableChargeAttack.Action.ContinueWith(_1 =>
                _1.GetHeroById(ShivaId).UseAbility(0).ContinueWith(_2 =>
                _2.GetHeroById(NayaId).UseAbility(2).ContinueWith(_3 =>
                _3.UseSummon(TheSunSummonId).ContinueWith(_4 =>
                _4.Attack()))));
        }

        /// <summary>
        /// Leave the raid if win condition is gone (front line alive)
        /// </summary>
        private static bool ShouldLeaveRaid(RaidSnapshot raidSnapshot)
        {
            return raidSnapshot.Allies.All(hero => hero.IsAlive());
        }
    }
}
