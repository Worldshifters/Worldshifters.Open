// <copyright file="UseSummon.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Bots.Strategy.RaidAction
{
    public class UseSummon : NextRaidAction
    {
        public override ActionType Type => ActionType.UseSummon;

        public int SummonIndex { get; set; }
    }
}
