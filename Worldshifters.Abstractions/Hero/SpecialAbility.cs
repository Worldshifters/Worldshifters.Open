// <copyright file="SpecialAbility.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using System.Collections.Generic;
    using Google.Protobuf.Collections;
    using Worldshifters.Data.Raid;

    public class SpecialAbility
    {
        public string AnimationName { get; set; }

        public string Description { get; set; }

        public RepeatedField<AbilityEffect> Effects { get; }

        public RepeatedField<int> HitCount { get; }

        public RepeatedField<ModelMetadata> ModelMetadata { get; }

        public string Name { get; set; }

        public bool ShouldRepositionSpriteAnimation { get; set; }

        public RepeatedField<AbilityEffectUpgrade> UpradedEffects { get; }

        /// <summary>
        /// Input parameters: current attacker.
        /// </summary>
        public Action<EntitySnapshot, IList<RaidAction>> ProcessEffects { get; set; }
    }
}
