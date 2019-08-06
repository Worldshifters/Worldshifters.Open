// <copyright file="Drain.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;

    public class Drain
    {
        /// <summary>
        /// Maximum healed amount. Only one between <see cref="HealingCap"/> and <see cref="HealingCapPercentage"/> must be provided.
        /// </summary>
        public long HealingCap { get; set; }

        /// <summary>
        /// Maximum healed amount as a percentage of the character max HP. Only one between <see cref="HealingCap"/> and <see cref="HealingCapPercentage"/> must be provided.
        /// </summary>
        public long HealingCapPercentage { get; set; }

        /// <summary>
        /// Whether to treat the <see cref="Raid.StatusEffectSnapshot.Strength"/> of a <see cref="ModifierLibrary.Drain"/> effect as a percentage or a flat HP amount.
        /// </summary>
        public bool IsPercentageBased { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}