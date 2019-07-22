// <copyright file="AbilityEffectUpgrade.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    public class AbilityEffectUpgrade
    {
        public AbilityEffect Effect { get; set; }

        public int UpgradedAbilityEffectIndex { get; set; }

        public int RequiredLevel { get; set; }

        public int RequiredRank { get; set; }
    }
}
