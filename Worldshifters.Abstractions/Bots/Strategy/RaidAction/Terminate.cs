// <copyright file="Terminate.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Bots.Strategy.RaidAction
{
    public class Terminate : NextRaidAction
    {
        public static readonly Terminate Action = new Terminate();

        public override ActionType Type => ActionType.Terminate;
    }
}
