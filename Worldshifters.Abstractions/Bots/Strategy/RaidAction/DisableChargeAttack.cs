// <copyright file="DisableChargeAttack.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Bots.Strategy.RaidAction
{
    public class DisableChargeAttack : NextRaidAction
    {
        public static readonly DisableChargeAttack Action = new DisableChargeAttack();

        public override ActionType Type => ActionType.DisableChargeAttack;
    }
}
