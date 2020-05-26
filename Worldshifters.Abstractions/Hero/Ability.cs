﻿// <copyright file="Ability.cs" company="Worldshifters">
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

        /// <summary>
        /// Whether to render the hero ability casting animation or not.
        /// </summary>
        public bool DoNotRenderAbilityCastEffect { get; set; }

        /// <summary>
        /// Whether the ability animation should be rendered for all allied raid participants or not.
        /// </summary>
        public bool RenderForAllAllies { get; set; }

        public bool CantRecast { get; set; }

        public Types.AbilityType Type { get; set; }

        /// <summary>
        /// Callback called when an ability is cast, before any of its <see cref="Effects"/> is applied. Input parameters: caster, target position in frontline.
        /// </summary>
        public Action<EntitySnapshot, int, IList<RaidAction>> ProcessEffects { get; set; }

        /// <summary>
        /// A delegate method which returns a pair where the first element is true if the ability can be used,
        /// and false otherwise. The second element of the pair is an optional (nullable) error message which will
        /// be displayed to the player when the ability can't be used.
        /// Inputs: the caster, the target position in frontline (0-indexed).
        /// </summary>
        /// <remarks>
        /// Regardless whether <see cref="CanCast"/> is provided or not, the ability cooldown and selected target
        /// are evaluated first and will have the precedence to determine whether the ability can be used or not.
        /// </remarks>
        public Func<EntitySnapshot, int, (bool canUse, string errorMessage)> CanCast { get; set; }

        /// <summary>
        /// Cast an ability targetting the caster or with no target.
        /// </summary>
        /// <param name="caster">The ability caster.</param>
        /// <param name="raidActions"></param>
        /// <param name="doNotRenderCastAbilityEffect">Optional boolean to toggle on or off the "cast ability" animation when this <see cref="Ability"/> is used.</param>
        public void Cast(EntitySnapshot caster, IList<RaidAction> raidActions, bool? doNotRenderCastAbilityEffect = null)
        {
            throw new NotImplementedException();
        }

        public void Cast(EntitySnapshot caster, int targetPositionInFrontline, IList<RaidAction> raidActions, bool? doNotRenderCastAbilityEffect = null)
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
