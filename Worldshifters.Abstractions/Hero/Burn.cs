// <copyright file="Burn.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;

    public class Burn
    {
        public long DamageCap { get; set; }

        /// <summary>
        /// Whether to treat the <see cref="Raid.StatusEffectSnapshot.Strength"/> of a <see cref="StatusEffectLibrary.BurntNpc"/>
        /// effect as a percentage or a flat HP amount.
        /// </summary>
        public bool IsPercentageBased { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}