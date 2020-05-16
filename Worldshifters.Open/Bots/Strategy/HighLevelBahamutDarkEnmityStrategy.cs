// <copyright file="HighLevelBahamutDarkEnmityStrategy.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Bots.Strategy
{
    using System;
    using System.Collections.Generic;
    using Worldshifters.Bots.Strategy.RaidAction;
    using Worldshifters.Data.Raid;

    public sealed class HighLevelBahamutDarkEnmityStrategy : RaidStrategy
    {
        // Use mock IDs for example purposes
        private static readonly int MercenaryJobId = 0;
        private static readonly Guid ZooeyId = Assets.Hero.Dark.Zooey.Id;
        private static readonly Guid NierId = Assets.Hero.Dark.Nier.Id;
        private static readonly Guid KoluluId = Guid.Empty;

        private static readonly Guid Freikugel = Guid.Empty;
        private static readonly Guid Sunya = Guid.Empty;
        private static readonly Guid Gisla = Guid.Empty;
        private static readonly Guid Blutgang = Guid.Empty;
        private static readonly Guid KatanaOfRepudiation = Guid.Empty;
        private static readonly Guid QilinBow = Guid.Empty;
        private static readonly Guid ScalesOfDominion = Guid.Empty;
        private static readonly Guid CelesteClawOmega = Guid.Empty;
        private static readonly Guid Parazonium = Guid.Empty;
        private static readonly Guid ZweiSchaedel = Guid.Empty;

        private static readonly Guid HadesSummonId = Guid.Empty;
        private static readonly Guid SarielSummonId = Guid.Empty;
        private static readonly Guid BelialSummonId = Guid.Empty;
        private static readonly Guid DeathSummonId = Guid.Empty;
        private static readonly Guid QilinSummonId = Guid.Empty;
        private static readonly Guid ShivaSummonId = Guid.Empty;

        /// <summary>
        /// <remarks>Validation is performed by the core library.</remarks>
        /// </summary>
        protected override IReadOnlyList<Guid> GetEquipmentLoadout()
        {
            // Main hand + rest of the grid (9 slots)
            return new[]
            {
                Freikugel, // Main hand
                Gisla,
                ScalesOfDominion,
                KatanaOfRepudiation,
                QilinBow,
                Sunya,
                Blutgang,
                CelesteClawOmega,
                Parazonium,
                ZweiSchaedel,
            };
        }

        /// <summary>
        /// <remarks>Validation is performed by the core library.</remarks>
        /// </summary>
        protected override (int classId, IReadOnlyList<Guid> heroIds) GetHeroLayout()
        {
            return (MercenaryJobId, new[] { KoluluId, ZooeyId, NierId });
        }

        /// <summary>
        /// <remarks>Validation is performed by the core library.</remarks>
        /// </summary>
        protected override IReadOnlyList<Guid> GetSummonLoadout()
        {
            // Main summon + rest of the summons + support summon
            return new[] { HadesSummonId, BelialSummonId, DeathSummonId, SarielSummonId, ShivaSummonId, QilinSummonId };
        }

        /// <summary>
        /// <remarks>Any raised exception will terminate the strategy.</remarks>
        /// </summary>
        protected override NextRaidAction GetNextRaidAction(RaidSnapshot raidSnapshot)
        {
            if (raidSnapshot.Turn == 0)
            {
                return EnableChargeAttack.Action.ContinueWith(_ =>
                    _.GetHeroById(ZooeyId).UseAbility(1).ContinueWith(_1 =>
                    _1.GetHeroById(NierId).UseAbility(0).ContinueWith(_2 =>
                    // Cast charge attack reactivation on the avatar
                    _2.GetHeroById(NierId).UseAbility(1, 0).ContinueWith(_3 =>
                    _3.GetHeroById(KoluluId).UseAbility(1).ContinueWith(_4 =>
                    _4.GetAvatar().UseAbility(0).ContinueWith(_5 =>
                    _5.UseSummon(DeathSummonId).ContinueWith(_6 =>
                    _6.Attack())))))));
            }

            if (raidSnapshot.Turn == 12)
            {
                raidSnapshot.UseSummon(ShivaSummonId).ContinueWith(_ => _.Attack());
            }

            if (!raidSnapshot.Enemies[0].CantMove())
            {
                return Wait.For(50);
            }

            return raidSnapshot.Attack();
        }
    }
}
