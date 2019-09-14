// <copyright file="Npc.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Npc
{
    using System;
    using System.Collections.Generic;
    using Google.Protobuf;
    using Google.Protobuf.Collections;
    using Worldshifters.Data.Raid;

    public sealed class Npc
    {
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
        /// Delay between the attack animation start and the rendering of the on-hit effect. Defaults to no delay.
        /// </summary>
        public RepeatedField<int> OnHitEffectDelaysInMs { get; set; }

        public int MaxChargeDiamonds { get; set; }

        /// <summary>
        /// The first method called before processing an action. Input parameters: this (the current NPC).
        /// </summary>
        /// <remarks>Called even if the character is dead.</remarks>
        public Action<EntitySnapshot, IList<RaidAction>> OnActionStart { get; set; }

        /// <summary>
        /// The first method called when the raid is created. Called only once.
        /// </summary>
        public Action<EntitySnapshot> OnSetup { get; set; }

        /// <summary>
        /// Callback called when a player joins the raid (raid host included). Called only once per raid participant.
        /// </summary>
        public Action<EntitySnapshot, IList<RaidAction>> OnRaidJoin { get; set; }

        /// <summary>
        /// Callback called when the npc is about to attack.
        /// Input parameters: this. Returns true if the normal attack processing behaviour should be followed afterwards, false otherwise.
        /// </summary>
        public Func<EntitySnapshot, IList<RaidAction>, bool> OnAttackStart { get; set; }

        /// <summary>
        /// Callback called when the npc charge diamonds are full and a charge attack can be performed. No normal attack will be performed afterwards during the same turn.
        /// Input parameters: this.
        /// </summary>
        public Action<EntitySnapshot, IList<RaidAction>> OnSpecialAttackStart { get; set; }

        /// <summary>
        /// Input parameters: this.
        /// </summary>
        public Action<EntitySnapshot, IList<RaidAction>> OnTurnEnd { get; set; }
    }
}