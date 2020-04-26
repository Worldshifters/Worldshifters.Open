// <copyright file="UseAbility.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Bots.Strategy.RaidAction
{
    public class UseAbility : NextRaidAction
    {
        public override ActionType Type => ActionType.UseAbility;

        public int HeroIndex { get; set; }

        public int AbilityIndex { get; set; }

        public int TargetIndex { get; set; }
    }
}
