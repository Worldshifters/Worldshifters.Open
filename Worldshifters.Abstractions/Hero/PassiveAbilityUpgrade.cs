// <copyright file="PassiveAbilityUpgrade.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    public class PassiveAbilityUpgrade
    {
        public PassiveAbility Ability { get; set; }

        public int RequiredLevel { get; set; }

        public int RequiredRank { get; set; }

        public int UpgradedPassiveAbilityIndex { get; set; }
    }
}
