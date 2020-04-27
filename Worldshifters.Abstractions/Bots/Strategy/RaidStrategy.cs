// <copyright file="RaidStrategy.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Bots.Strategy
{
    using System;
    using System.Collections.Generic;
    using Worldshifters.Bots.Strategy.RaidAction;
    using Worldshifters.Data.Raid;

    /// <summary>
    /// The strategy to use by a bot in a raid. Processing is done asynchronously; the next action is evaluated as soon as the lockout timer of the last action expires.
    /// </summary>
    public abstract class RaidStrategy
    {
        /// <summary>
        /// Return the equipment IDs to use in the raid to join. Exactly 10 values are expected to be returned.
        /// </summary>
        protected abstract IReadOnlyList<Guid> GetEquipmentLoadout();

        /// <summary>
        /// Return the avatar class and up to 5 party members who to join the raid with.
        /// </summary>
        protected abstract (int classId, IReadOnlyList<Guid> heroIds) GetHeroLayout();

        /// <summary>
        /// Return the summons to use in the raid join. Exactly 6 values are expected to be returned: main summon, 4 sub-summons, support summon.
        /// </summary>
        protected abstract IReadOnlyList<Guid> GetSummonLoadout();

        /// <summary>
        /// <remarks>Any raised exception will terminate the strategy.</remarks>
        /// </summary>
        protected abstract NextRaidAction GetNextRaidAction(RaidSnapshot raidSnapshot);
    }
}
