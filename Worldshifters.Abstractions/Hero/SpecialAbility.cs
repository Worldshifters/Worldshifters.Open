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

        /// <summary>
        /// One <see cref="ModelMetadata"/> per character outfit.
        /// </summary>
        public RepeatedField<ModelMetadata> ModelMetadata { get; }

        public string Name { get; set; }

        public RepeatedField<AbilityEffectUpgrade> UpradedEffects { get; }

        public bool ShouldRepositionSpriteAnimationOnTarget { get; set; }

        /// <summary>
        /// The frame to skip to when special attack animations are skipped. 1-1 match with <see cref="ModelMetadata"/>.
        /// </summary>
        public RepeatedField<int> FrameToSkipToOnAnimationSkip { get; }

        public RepeatedField<string> ConstructorNameOnAnimationSkip { get; }

        /// <summary>
        /// Input parameters: current attacker.
        /// </summary>
        public Action<EntitySnapshot, IList<RaidAction>> ProcessEffects { get; set; }
    }
}
