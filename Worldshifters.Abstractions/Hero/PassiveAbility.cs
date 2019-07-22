// <copyright file="PassiveAbility.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

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
