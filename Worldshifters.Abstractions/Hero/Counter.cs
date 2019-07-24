// <copyright file="Counter.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;

    public class Counter
    {
        /// <summary>
        /// The effect will fade off after <see cref="HitCount"/> hits.
        /// </summary>
        public int HitCount { get; set; }

        /// <summary>
        /// The base damage multiplier applied to each countered hit.
        /// </summary>
        public double DamageModifier { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}