// <copyright file="StatusEffectSnapshot.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Raid
{
    public class StatusEffectSnapshot
    {
        /// <summary>
        /// Restricts the effect to attacks with the given element. No element restriction by default.
        /// </summary>
        public Element AttackElementRestriction { get; set; }

        /// <summary>
        /// The percentage of chance to land a debuff.
        /// </summary>
        public double BaseAccuracy { get; set; }

        /// <summary>
        /// Restricts the effect to characters with the given element. No element restriction by default.
        /// </summary>
        public Element ElementRestriction { get; set; }

        /// <summary>
        /// Status effects with the same <see cref="Id"/> stack or override each other depending on the effect strength, remaining duration and stacking rules.
        /// See <see cref="IsStackable"/>.
        /// </summary>
        public string Id { get; set; }

        public bool IsBuff { get; set; }

        public bool IsLocal { get; set; }

        /// <summary>
        /// Stackable effects will increase the strength of the existing effect up to <see cref="StackingCap"/>.
        /// </summary>
        public bool IsStackable { get; set; }

        public bool IsUndispellable { get; set; }

        /// <summary>
        /// Status effects used internally are not rendered on the player side but are still taken into account for server side calculations.
        /// </summary>
        public bool IsUsedInternally { get; set; }

        public double StackingCap { get; set; }

        public double Strength { get; set; }

        public int TurnDuration { get; set; }

        /// <summary>
        /// The status effect modifier is automatically inferred from <see cref="StatusEffectSnapshot.Id"/> for IDs defined in <see cref="StatusEffectLibrary"/>.
        /// </summary>
        public Modifier Modifier { get; set; }
    }
}
