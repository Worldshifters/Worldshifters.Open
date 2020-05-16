// <copyright file="NextRaidAction.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Bots.Strategy.RaidAction
{
    using System;
    using Worldshifters.Data.Raid;

    public abstract class NextRaidAction
    {
        public enum ActionType
        {
            Attack,
            UseSummon,
            UseAbility,
            Wait,
            Retreat,
            Terminate,
            EnableChargeAttack,
            DisableChargeAttack,
            Pass,
        }

        public abstract ActionType Type { get; }

        public NextRaidAction ContinueWith(Func<RaidSnapshot, NextRaidAction> continuation)
        {
            throw new NotImplementedException();
        }
    }
}
