// <copyright file="Attack.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Bots.Strategy.RaidAction
{
    public class Attack : NextRaidAction
    {
        public override ActionType Type => ActionType.Attack;

        public int TargetIndex { get; set; }

        public bool EnableChargeAttack { get; set; }
    }
}
