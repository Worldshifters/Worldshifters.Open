// <copyright file="Hero.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

#pragma warning disable CA1034 // Nested types should not be visible

namespace Worldshifters.Data.Inventory
{
    using System;
    using Google.Protobuf;
    using Worldshifters.Data.Hero;

    public static partial class Types
    {
        public class Hero
        {
            /// <summary>
            /// The unique id the hero. The same hero will have a different <see cref="Id"/> if it is owned by another player.
            /// </summary>
            public ByteString Id { get; }

            public int Level { get; }

            public int Rank { get; }

            public Race Race { get; }

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
