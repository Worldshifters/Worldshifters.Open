// <copyright file="ModifierLibrary.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data
{
    using Worldshifters.Data.Raid;

    public static class ModifierLibrary
    {
        /// <summary>
        /// The default modifier. Does nothing.
        /// </summary>
        public static Modifier None;

        /// <summary>
        /// Strength values must be given in percentage.
        /// </summary>
        public static Modifier AttackBoost;

        /// <summary>
        /// Strength values must be given in percentage.
        /// </summary>
        public static Modifier FlatAttackBoost;

        /// <summary>
        /// Strength values must be given in percentage.
        /// </summary>
        public static Modifier ElementalAttackBoost;

        /// <summary>
        /// Strength values must be given in percentage.
        /// </summary>
        public static Modifier FlatDefenseBoost;

        public static Modifier DamageBoostWhenSuperiorElement;

        /// <summary>
        /// Strength values must be given in percentage.
        /// </summary>
        public static Modifier FlatDoubleAttackRateBoost;

        /// <summary>
        /// Strength values must be given in percentage.
        /// </summary>
        public static Modifier FlatTripleAttackRateBoost;

        /// <summary>
        /// Strength values must be given in percentage.
        /// </summary>
        public static Modifier DamageCutBoost;

        /// <summary>
        /// Strength values must be given in percentage.
        /// </summary>
        public static Modifier DamageReductionBoost;

        /// <summary>
        /// Strength values must be given in percentage.
        /// </summary>
        public static Modifier ElementalAttackBoostAmplification;

        /// <summary>
        /// Strength values must be given in percentage.
        /// </summary>
        public static Modifier FlatDamageCapBoost;

        /// <summary>
        /// Strength values must be given in percentage (chance to dodge damage).
        /// </summary>
        public static Modifier DodgeRateBoost;

        /// <summary>
        /// Strength values must be given in percentage.
        /// </summary>
        public static Modifier FlatChargeAttackDamageBoost;

        /// <summary>
        /// Strength values must be given in percentage.
        /// </summary>
        public static Modifier FlatChargeAttackDamageCapBoost;

        /// <summary>
        /// Values are given as a percentage subtracted from the base accuracy of debuff effects (percentage of chance to land a debuff).
        /// A debuff resistance greater than 0 means that the chance to land the debuff is lower.
        /// </summary>
        public static Modifier FlatDebuffResistanceBoost;

        /// <summary>
        /// Percentage based.
        /// </summary>
        public static Modifier HealingBoost;

        public static Modifier FlatHealingBoost;

        /// <summary>
        /// Percentage based.
        /// </summary>
        public static Modifier HealingCapBoost;

        public static Modifier FlatHealingCapBoost;

        public static Modifier FlatChainBurstDamageBoost;
        public static Modifier FlatChainBurstDamageCapBoost;
        public static Modifier Shield;
        public static Modifier ChargeBarSpedUp;

        /// <summary>
        /// The strength value of a status effect with this modifier is the max HP percentage which will be recovered.
        /// </summary>
        public static Modifier AutoRevive;

        /// <summary>
        /// The strength value of a status effect with this modifier is the additional damage which will be dealt as a percentage of the base damage.
        /// </summary>
        public static Modifier AdditionalDamage;

        /// <summary>
        /// The strength value of a status effect with this modifier is both the damage percentage reduction and recovered.
        /// </summary>
        public static Modifier DamageAbsorption;

        /// <summary>
        /// Every character has a base hostility score of 10. A character's chance to get hit is their hostility score over the party's sum total hostility score.
        /// </summary>
        public static Modifier HostilityBoost;

        /// <summary>
        /// Burn damage applies before refresh/revitalize effects.
        /// </summary>
        public static Modifier Burnt;

        public static Modifier SupplementalDamage;

        /// <summary>
        /// Strength values must be given in percentage.
        /// </summary>
        public static Modifier SkillDamageCap;
    }
}
