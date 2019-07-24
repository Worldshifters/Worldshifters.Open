// <copyright file="Drain.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;

    public class Drain
    {
        public long HealingCap { get; set; }

        /// <summary>
        /// Whether to treat the <see cref="Worldshifters.Data.Raid.StatusEffectSnapshot.Strength"/> of a <see cref="StatusEffectLibrary.DrainNpc"/>
        /// or <see cref="StatusEffectLibrary.DrainWeapon"/> effect as a percentage or a flat HP amount.
        /// </summary>
        public bool IsPercentageBased { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}