// <copyright file="RaidStrategy.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Bots.Strategy
{
    using Worldshifters.Bots.Strategy.RaidAction;
    using Worldshifters.Data.Raid;

    /// <summary>
    /// The strategy to use by a bot in a raid. Processing is done asynchronously; the next action is evaluated as soon as the lockout timer of the last action expires.
    /// </summary>
    public abstract class RaidStrategy
    {
        public abstract NextRaidAction GetNextRaidAction(RaidSnapshot raidSnapshot);
    }
}
