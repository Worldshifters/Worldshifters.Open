// <copyright file="Retreat.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Bots.Strategy.RaidAction
{
    public class Retreat : NextRaidAction
    {
        public static readonly Retreat Action = new Retreat();

        public override ActionType Type => ActionType.Retreat;
    }
}
