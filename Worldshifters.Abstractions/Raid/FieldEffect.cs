// <copyright file="FieldEffect.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Raid
{
    using System;
    using System.Collections.Generic;

    public class FieldEffect
    {
        public string Id { get; set; }

        public bool IsLocal { get; set; }

        public Action<RaidSnapshot, IList<RaidAction>> ProcessEffects { get; set; }

        public long RemainingDurationInSeconds { get; set; }

        public int TurnDuration { get; set; }
    }
}
