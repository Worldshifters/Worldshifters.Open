// <copyright file="Ability.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

#pragma warning disable CA1034 // Nested types should not be visible

namespace Worldshifters.Data.Hero
{
    using System;
    using System.Collections.Generic;
    using Google.Protobuf.Collections;
    using Worldshifters.Data.Raid;

    public enum AbilityTargettingType
    {
        TargetNone,
        TargetSingleAliveFrontLineMember,
        TargetSingleDeadPartyMember,
        TargetSingleAliveFrontLineMemberExcludingSelf,
    }

    public class Ability
    {
        public AbilityTargettingType AbilityTargetting { get; set; }

        public string AnimationName { get; set; }

        public int Cooldown { get; set; }

        public string Description { get; set; }

        public RepeatedField<AbilityEffect> Effects { get; }

        public int InitialCooldown { get; set; }

        public ModelMetadata ModelMetadata { get; set; }

        public string Name { get; set; }

        public bool RenderOnAllPartyMembers { get; set; }

        public bool RepositionOnTarget { get; set; }

        public bool ShouldRepositionSpriteAnimation { get; set; }

        public Types.AbilityType Type { get; set; }

        /// <summary>
        /// Input parameters: caster, target index.
        /// </summary>
        public Action<EntitySnapshot, int, IList<RaidAction>> ProcessEffects { get; set; }

        /// <summary>
        /// A delegate method which returns a pair where the first element is true if the ability can be used,
        /// and false otherwise. The second element of the pair is an optional (nullable) error message which will
        /// be displayed to the player when the ability can't be used.
        /// </summary>
        /// <remarks>
        /// Regardless whether <see cref="CanCast"/> is provided or not, the ability cooldown and selected target
        /// are evaluated first and will have the precedence to determine whether the ability can be used or not.
        /// </remarks>
        public Func<EntitySnapshot, (bool canUse, string errorMessage)> CanCast { get; set; }

        public void Cast(EntitySnapshot caster, int targetIndex, IList<RaidAction> raidActions)
        {
            throw new NotImplementedException();
        }

        public static class Types
        {
            public enum AbilityType
            {
                Offensive,
                Healing,
                Defensive,
                Support,
            }
        }
    }
}
