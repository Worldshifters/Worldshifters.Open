// <copyright file="MultihitDamage.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;

    public class MultihitDamage
    {
        public long DamageCap { get; set; }

        public double DamageModifier { get; set; }

        public Element Element { get; set; }

        public bool HitAllTargets { get; set; }

        public int HitNumber { get; set; }

        public bool RandomTargets { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}