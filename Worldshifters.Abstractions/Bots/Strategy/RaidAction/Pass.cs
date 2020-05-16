// <copyright file="Pass.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Bots.Strategy.RaidAction
{
    public class Pass : NextRaidAction
    {
        public static readonly Pass Action = new Pass();

        public override ActionType Type => ActionType.Pass;
    }
}
