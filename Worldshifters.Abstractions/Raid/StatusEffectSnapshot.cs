// <copyright file="StatusEffectSnapshot.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Raid
{
    using Google.Protobuf;

    /// <summary>
    /// When neither <see cref="RemainingDurationInSeconds"/> not <see cref="TurnDuration"/> is provided, the status effect is considered to be turn based and will have a <see cref="TurnDuration"/> equal to 1.
    /// </summary>
    public class StatusEffectSnapshot
    {
        /// <summary>
        /// Restricts the effect to attacks with the given element. No element restriction by default.
        /// </summary>
        public Element AttackElementRestriction { get; set; }

        /// <summary>
        /// Gets or sets the percentage of chance to land the debuff. Buffs should leave <see cref="BaseAccuracy"/> to the default value 'null'.
        /// Debuffs with <see cref="BaseAccuracy"/> set to <see cref="double.MaxValue"/> will bypass <see cref="StatusEffectLibrary.Dodge"/> and <see cref="StatusEffectLibrary.Veil"/>.
        /// </summary>
        public double? BaseAccuracy { get; set; }

        /// <summary>
        /// Restricts the effect to characters with the given element. No element restriction by default.
        /// </summary>
        public Element ElementRestriction { get; set; }

        /// <summary>
        /// Status effects with the same <see cref="Id"/> stack or override each other depending on the effect strength, remaining duration and stacking rules.
        /// See <see cref="IsStackable"/>.
        /// </summary>
        public string Id { get; set; }

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

        /// <summary>
        /// Only one between <see cref="TurnDuration"/> and <see cref="RemainingDurationInSeconds"/> should be implemented.
        /// </summary>
        public int TurnDuration { get; set; }

        /// <remarks>
        /// Turn based status effects applied during an attack will have an <see cref="InitialTurnDuration"/> equal to <see cref="TurnDuration"/> - 1.
        /// </remarks>
        public int InitialTurnDuration { get; }

        /// <summary>
        /// Only one between <see cref="TurnDuration"/> and <see cref="RemainingDurationInSeconds"/> should be implemented.
        /// </summary>
        public long RemainingDurationInSeconds { get; set; }

        /// <summary>
        /// The status effect modifier is automatically inferred from <see cref="Id"/> for IDs defined in <see cref="StatusEffectLibrary"/>.
        /// </summary>
        public Modifier Modifier { get; set; }

        /// <summary>
        /// Passive effects can't be dispelled and are not removed on death (effects are still removed when their remaining duration reaches 0).
        /// </summary>
        public bool IsPassiveEffect { get; set; }

        /// <summary>
        /// Additional status effect data depending on the effect.
        /// </summary>
        public ByteString ExtraData { get; set; }

        public Types.TriggerCondition TriggerCondition { get; set; }

        public static class Types
        {
            public class TriggerCondition
            {
                public Types.Type Type { get; set; }

                public string Data { get; set; }

                public static class Types
                {
                    public enum Type
                    {
                        HasStatusEffect,
                        HasModifier,
                        TargetInBreakMode,
                        TargetInOverdriveMode,
                        TargetHasStatusEffect,
                        TargetHasDebuff,
                        TargetHasModifier,
                        OnTripleAttack,
                    }
                }
            }
        }
    }
}
