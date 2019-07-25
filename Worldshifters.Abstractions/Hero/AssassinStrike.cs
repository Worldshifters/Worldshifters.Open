// <copyright file="AssassinStrike.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

#pragma warning disable CA1034 // Nested types should not be visible

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;

    public class AssassinStrike
    {
        public long DamageCap { get; set; }

        public Types.ActivationCondition ActivationCondition { get; set; }

        public double ChargeAttackDamageBoost { get; set; }

        public double ChargeAttackDamageCap { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }

        public static class Types
        {
            public enum ActivationCondition
            {
                None,
                TargetInOverdriveMode,
                TargetInBreakMode,
            }
        }
    }
}