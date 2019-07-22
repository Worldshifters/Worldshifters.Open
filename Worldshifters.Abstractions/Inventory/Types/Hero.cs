// <copyright file="Hero.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Inventory.Types
{
    using System;
    using Worldshifters.Data.Hero;

    public class Hero
    {
        public Data.Hero.Hero HeroData { get; }

        public int Level { get; set; }

        public int Rank { get; set; }

        public Ability[] GetAbilities()
        {
            throw new NotImplementedException();
        }
    }
}
