// <copyright file="Revitalize.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;

    public class Revitalize
    {
        public long HealingCap { get; set; }

        /// <summary>
        /// Whether to treat the <see cref="Worldshifters.Data.Raid.StatusEffectSnapshot.Strength"/> of a <see cref="StatusEffectLibrary.RevitalizeNpc"/>
        /// effect as a percentage or a flat HP amount.
        /// </summary>
        public bool IsPercentageBased { get; set; }

        /// <summary>
        /// If set to true, the character with this status effect will gain 10 charge gauge instead if his or her HP is maxed out already.
        /// </summary>
        public bool BoostChargeGaugeAtFullHp { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}