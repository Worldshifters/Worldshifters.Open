// <copyright file="ApplyStatusEffect.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
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

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}