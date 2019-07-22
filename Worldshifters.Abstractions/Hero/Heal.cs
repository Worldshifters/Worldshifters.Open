// <copyright file="Heal.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;

    public class Heal
    {
        public long HealingCap { get; set; }

        public double HpPercentageRecovered { get; set; }

        public long HpRecovered { get; set; }

        public bool OnAllPartyMembers { get; set; }

        public bool OnSelectedTarget { get; set; }

        public bool OnSelf { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}