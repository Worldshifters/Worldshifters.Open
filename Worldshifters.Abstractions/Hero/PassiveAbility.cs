// <copyright file="PassiveAbility.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

#pragma warning disable CA1034 // Nested types should not be visible

namespace Worldshifters.Data.Hero
{
    public class PassiveAbility
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Types.PassiveAbilityType Type { get; set; }

        public static class Types
        {
            public enum PassiveAbilityType
            {
                SupportSkill,
                BacklineEffect,
                TriggerOnEnteringFrontline,
            }
        }
    }
}
