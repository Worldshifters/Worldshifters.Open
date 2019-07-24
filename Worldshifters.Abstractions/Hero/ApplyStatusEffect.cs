﻿// <copyright file="ApplyStatusEffect.cs" company="Worldshifters">
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

        public int DurationInSeconds { get; set; }

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

        public int TurnDuration { get; set; }

        /// <summary>
        /// Status effects used internally are not rendered on the player side but are still taken into account for server side calculations.
        /// </summary>
        public bool IsUsedInternally { get; set; }

        /// <summary>
        /// Build a list of <see cref="AbilityEffect"/>s matching a template <see cref="ApplyStatusEffect"/>.
        /// </summary>
        /// <param name="template">A template <see cref="ApplyStatusEffect"/>.</param>
        /// <param name="idsAndStrength">A list of pairs of <see cref="Worldshifters.Data.Raid.StatusEffectSnapshot.Id"/>s and <see cref="Worldshifters.Data.Raid.StatusEffectSnapshot.Strength"/>s.</param>
        /// <returns>A list of <see cref="AbilityEffect"/>s with the provided <see cref="idsAndStrength"/> and matching the <see cref="template"/>.</returns>
        public static IEnumerable<AbilityEffect> FromTemplate(ApplyStatusEffect template, params (string, double)[] idsAndStrength)
        {
            throw new NotImplementedException();
        }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}