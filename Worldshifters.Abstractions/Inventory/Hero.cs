﻿// <copyright file="Hero.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

#pragma warning disable CA1034 // Nested types should not be visible

namespace Worldshifters.Data.Inventory
{
    using System;
    using Worldshifters.Data.Hero;

    public static partial class Types
    {
        public class Hero
        {
            public int Level { get; set; }

            public int Rank { get; set; }

            public Ability[] GetAbilities()
            {
                throw new NotImplementedException();
            }

            /// <returns>The rank of the hero's extended mastery perk support skill.</returns>
            public int GetSupportSkillRank()
            {
                throw new NotImplementedException();
            }
        }
    }
}
