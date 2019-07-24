// <copyright file="LinearAttackBoost.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;

    public class LinearAttackBoost
    {
        public double StrengthAtFullHp { get; set; }

        public double StrengthAt1Hp { get; set; }

        public double HpPercentageCutOff { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}