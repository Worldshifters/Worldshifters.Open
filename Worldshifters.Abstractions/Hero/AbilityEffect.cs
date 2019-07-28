// <copyright file="AbilityEffect.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

#pragma warning disable CA1034 // Nested types should not be visible

namespace Worldshifters.Data.Hero
{
    using Google.Protobuf;

    public class AbilityEffect
    {
        public Types.AbilityEffectType Type { get; set; }

        /// <summary>
        /// Additional ability effect data depending on the ability.
        /// </summary>
        public ByteString ExtraData { get; set; }

        public static class Types
        {
            public enum AbilityEffectType
            {
                ApplyStatusEffect,
                Healing,
                MultihitDamage,
            }
        }
    }
}
