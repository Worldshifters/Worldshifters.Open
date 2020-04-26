// <copyright file="Wait.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Bots.Strategy.RaidAction
{
    using System;

    public class Wait : NextRaidAction
    {
        public override ActionType Type => ActionType.Wait;

        public int DurationInMilliseconds { get; set; }

        public static Wait For(int durationInMilliseconds)
        {
            throw new NotImplementedException();
        }
    }
}
