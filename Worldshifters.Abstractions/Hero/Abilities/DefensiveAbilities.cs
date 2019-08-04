// <copyright file="DefensiveAbilities.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero.Abilities
{
    using System;

    public static class DefensiveAbilities
    {
        public enum StackingType
        {
            Npc,
            Weapon,
            Summon,
        }

        public static Ability DamageCutForParty(uint strength, StackingType stackingType)
        {
            throw new NotImplementedException();
        }
    }
}
