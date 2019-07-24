// <copyright file="Repel.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;

    public class Repel
    {
        /// <summary>
        /// The effect will fade off after <see cref="HitCount"/> hits.
        /// </summary>
        public int HitCount { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}