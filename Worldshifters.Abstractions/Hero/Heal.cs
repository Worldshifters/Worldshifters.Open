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

        /// <remarks>One and only one between <see cref="HpPercentageRecovered"/> and <see cref="HpRecovered"/> has to be greater than 0.</remarks>
        public double HpPercentageRecovered { get; set; }

        /// <remarks>One and only one between <see cref="HpPercentageRecovered"/> and <see cref="HpRecovered"/> has to be greater than 0.</remarks>
        public long HpRecovered { get; set; }

        /// <remarks>One and only one between <see cref="OnAllPartyMembers"/>, <see cref="OnSelf"/> and <see cref="OnSelectedTarget"/> has to be greater set to true.</remarks>
        public bool OnAllPartyMembers { get; set; }

        /// <remarks>One and only one between <see cref="OnAllPartyMembers"/>, <see cref="OnSelf"/> and <see cref="OnSelectedTarget"/> has to be greater set to true.</remarks>
        public bool OnSelectedTarget { get; set; }

        /// <remarks>One and only one between <see cref="OnAllPartyMembers"/>, <see cref="OnSelf"/> and <see cref="OnSelectedTarget"/> has to be greater set to true.</remarks>
        public bool OnSelf { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}