// <copyright file="EnableChargeAttack.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Bots.Strategy.RaidAction
{
    public class EnableChargeAttack : NextRaidAction
    {
        public static readonly EnableChargeAttack Action = new EnableChargeAttack();

        public override ActionType Type => ActionType.EnableChargeAttack;
    }
}
