// <copyright file="Npc.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Npc
{
    using System;
    using System.Collections.Generic;
    using Google.Protobuf;
    using Worldshifters.Data.Raid;

    public sealed class Npc
    {
        /// <summary>
        /// The first method called before processing an action. Input parameters: this (the current NPC).
        /// </summary>
        /// <remarks>Called even if the character is dead.</remarks>
        public Action<EntitySnapshot, IList<RaidAction>> OnActionStart { get; set; }

        /// <summary>
        /// Input parameters: this.
        /// </summary>
        public Action<EntitySnapshot, IList<RaidAction>> OnTurnEnd { get; set; }

        public ByteString Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long Attack { get; set; }

        public long MaxHp { get; set; }

        public int Level { get; set; }

        public Element Element { get; set; }

        public Gender Gender { get; set; }

        public ModelMetadata ModelMetadata { get; set; }

        public ModelMetadata OnHitEffectModelMetadata { get; set; }

        public double Defense { get; set; }

        public double BaseDoubleAttackRate { get; set; }

        public double BaseTripleAttackRate { get; set; }

        /// <summary>
        /// Scaling factor applied to the duration of the normal attack animation.
        /// </summary>
        public double AttackAnimationScaling { get; set; }

        /// <summary>
        /// Delay between the attack animation start and the rendering of the on-hit effect. Defaults to 0 (no delay).
        /// </summary>
        public int OnHitDelayInMs { get; set; }
    }
}