// <copyright file="MultihitDamage.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using System.Collections.Generic;
    using Google.Protobuf;
    using Worldshifters.Data.Raid;

    public class MultihitDamage
    {
        public long DamageCap { get; set; }

        public double DamageModifier { get; set; }

        public Element Element { get; set; }

        public bool HitAllTargets { get; set; }

        public int HitNumber { get; set; }

        public bool RandomTargets { get; set; }

        public void ProcessEffects(EntitySnapshot caster, IList<RaidAction> raidActions)
        {
            throw new NotImplementedException();
        }

        public void ProcessEffects(EntitySnapshot caster, int targetPositionInFrontline, IList<RaidAction> raidActions)
        {
            throw new NotImplementedException();
        }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}