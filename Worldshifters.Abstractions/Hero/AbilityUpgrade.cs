// <copyright file="AbilityUpgrade.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    public class AbilityUpgrade
    {
        public Ability Ability { get; set; }

        public int RequiredLevel { get; set; }

        public int UpgradedPassiveAbilityIndex { get; set; }

        public int UpgradedAbilityIndex { get; set; }
    }
}
