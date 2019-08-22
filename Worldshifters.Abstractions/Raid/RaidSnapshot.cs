// <copyright file="RaidSnapshot.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

#pragma warning disable CA1034 // Nested types should not be visible

namespace Worldshifters.Data.Raid
{
    using System;
    using System.Collections.Generic;
    using Google.Protobuf;
    using Google.Protobuf.Collections;
    using Worldshifters.Data.Hero;

    public class RaidSnapshot
    {
        /// <summary>
        /// The heroes the current player controls plus the other heroes of friendly parties on the same stage.
        /// </summary>
        /// <remarks>Does not include empty slots and sorted by <see cref="EntitySnapshot.PositionInFrontline"/>.</remarks>
        public EntitySnapshot[] Allies { get; set; }

        /// <remarks>Does not include empty slots and sorted by <see cref="EntitySnapshot.PositionInFrontline"/>.</remarks>
        public EntitySnapshot[] Enemies { get; set; }

        public bool IsPvp { get; set; }

        public int NumParticipants { get; set; }

        public int SelectedTarget { get; set; }

        public int Turn { get; set; }

        public void AddFieldEffect(string fieldEffectId)
        {
            throw new NotImplementedException();
        }

        public ISet<string> GetActiveFieldEffectIds()
        {
            throw new NotImplementedException();
        }

        public int GetNumSpecialAttacksUsedThisTurn()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the last ability used.
        /// </summary>
        /// <param name="heroIdToExclude">If the last ability used was cast by a hero with <see cref="Inventory.Types.Hero.Id"/> different from <see cref="heroIdToExclude"/>, return null.</param>
        /// <returns>null if no ability matching the search criteria was found.</returns>
        public Ability GetLastAbilityUsed(ByteString heroIdToExclude = null)
        {
            throw new NotImplementedException();
        }

        public static class Types
        {
            public class Loadout
            {
                public RepeatedField<ByteString> EquipmentIds { get; }

                public RepeatedField<ByteString> SummonIds { get; }
            }
        }
    }
}
