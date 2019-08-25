// <copyright file="ApplyStatusEffect.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using System.Collections.Generic;
    using Google.Protobuf;

    public class ApplyStatusEffect
    {
        /// <summary>
        /// The percentage of chance to land a debuff.
        /// </summary>
        public double BaseAccuracy { get; set; }

        /// <summary>
        /// Additional status effect data depending on the effect.
        /// </summary>
        public ByteString ExtraData { get; set; }

        public string Id { get; set; }

        public bool IsBuff { get; set; }

        public bool IsLocal { get; set; }

        public bool IsStackable { get; set; }

        public bool IsUndispellable { get; set; }

        public bool OnAllEnemies { get; set; }

        public bool OnAllPartyMembers { get; set; }

        public bool OnSelectedTarget { get; set; }

        public bool OnSelf { get; set; }

        public double StackingCap { get; set; }

        public double Strength { get; set; }

        /// <remarks>One and only one between <see cref="TurnDuration"/> and <see cref="DurationInSeconds"/> has to be greater than 0.</remarks>
        public int DurationInSeconds { get; set; }

        /// <remarks>One and only one between <see cref="TurnDuration"/> and <see cref="DurationInSeconds"/> has to be greater than 0.</remarks>
        public int TurnDuration { get; set; }

        /// <summary>
        /// Status effects used internally are not rendered on the player side but are still taken into account for server side calculations.
        /// </summary>
        public bool IsUsedInternally { get; set; }

        /// <summary>
        /// Passive effects can't be dispelled and are not removed on death (effects are still removed when their remaining duration reaches 0).
        /// </summary>
        public bool IsPassiveEffect { get; set; }

        /// <summary>
        /// Build a list of <see cref="AbilityEffect"/>s matching a template <see cref="ApplyStatusEffect"/>.
        /// </summary>
        /// <param name="template">A template <see cref="ApplyStatusEffect"/>.</param>
        /// <param name="idsAndStrengths">A list of pairs of <see cref="Raid.StatusEffectSnapshot.Id"/>s and <see cref="Raid.StatusEffectSnapshot.Strength"/>s.</param>
        /// <returns>A list of <see cref="AbilityEffect"/>s with the provided <see cref="idsAndStrengths"/> and matching the <see cref="template"/>.</returns>
        public static IEnumerable<AbilityEffect> FromTemplate(ApplyStatusEffect template, params (string, double)[] idsAndStrengths)
        {
            throw new NotImplementedException();
        }

        public static ApplyStatusEffect ParseFrom(ByteString data)
        {
            throw new NotImplementedException();
        }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}