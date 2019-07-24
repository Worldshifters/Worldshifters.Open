// <copyright file="CriticalHit.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;

    public class CriticalHit
    {
        public double DamageMultiplier { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}