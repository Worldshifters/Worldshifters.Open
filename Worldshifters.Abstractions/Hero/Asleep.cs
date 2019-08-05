// <copyright file="Asleep.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;

    public class Asleep
    {
        /// <summary>
        /// Percentage of additional damage taken.
        /// </summary>
        public double DamageTakenAmplification { get; set; }

        public bool WakeUpOnTakingDamage { get; set; }

        public double WakeUpPercentageChanceOnTakingDamage { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}
