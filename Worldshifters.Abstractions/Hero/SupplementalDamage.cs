// <copyright file="SupplementalDamage.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;

    public class SupplementalDamage
    {
        public double DamageCap { get; set; }

        public bool IsPercentageBased { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}
