// <copyright file="SupportAbilities.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

#pragma warning disable SA1615 // Element return value should be documented

namespace Worldshifters.Data.Hero.Abilities
{
    using System;
    using Worldshifters.Data.Hero;

    public static class SupportAbilities
    {
        public enum StackingType
        {
            Npc,
            Weapon,
            Summon,
        }

        /// <returns>An <see cref="Ability"/> with the party fire attack up sprite animation.</returns>
        public static Ability FireAttackUpForParty()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a party wide fire attack up <see cref="Ability"/> with optional <see cref="extraEffects"/>.
        /// </summary>
        /// <param name="strength">The strength of the elemental attack up buff. Must be greater than 0.</param>
        /// <param name="turnDuration">The duration of the buff.</param>
        /// <param name="stackingType">The frame on which the buff will apply (used to resolve stacking effects).</param>
        /// <param name="extraEffects">Optional list of additional effects which will be applied on top of the elemental attack up buff.</param>
        public static Ability FireAttackUpForParty(uint strength, uint turnDuration, StackingType stackingType, params AbilityEffect[] extraEffects)
        {
           throw new NotImplementedException();
        }

        /// <returns>An <see cref="Ability"/> with the party water attack up sprite animation.</returns>
        public static Ability WaterAttackUpForParty()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a party wide water attack up <see cref="Ability"/> with optional <see cref="extraEffects"/>.
        /// </summary>
        /// <param name="strength">The strength of the elemental attack up buff. Must be greater than 0.</param>
        /// <param name="turnDuration">The duration of the buff.</param>
        /// <param name="stackingType">The frame on which the buff will apply (used to resolve stacking effects).</param>
        /// <param name="extraEffects">Optional list of additional effects which will be applied on top of the elemental attack up buff.</param>
        public static Ability WaterAttackUpForParty(uint strength, uint turnDuration, StackingType stackingType, params AbilityEffect[] extraEffects)
        {
            throw new NotImplementedException();
        }

        /// <returns>An <see cref="Ability"/> with the party earth attack up sprite animation.</returns>
        public static Ability EarthAttackUpForParty()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a party wide earth attack up <see cref="Ability"/> with optional <see cref="extraEffects"/>.
        /// </summary>
        /// <param name="strength">The strength of the elemental attack up buff. Must be greater than 0.</param>
        /// <param name="turnDuration">The duration of the buff.</param>
        /// <param name="stackingType">The frame on which the buff will apply (used to resolve stacking effects).</param>
        /// <param name="extraEffects">Optional list of additional effects which will be applied on top of the elemental attack up buff.</param>
        public static Ability EarthAttackUpForParty(uint strength, uint turnDuration, StackingType stackingType, params AbilityEffect[] extraEffects)
        {
            throw new NotImplementedException();
        }

        /// <returns>An <see cref="Ability"/> with the party wind attack up sprite animation.</returns>
        public static Ability WindAttackUpForParty()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a party wide wind attack up <see cref="Ability"/> with optional <see cref="extraEffects"/>.
        /// </summary>
        /// <param name="strength">The strength of the elemental attack up buff. Must be greater than 0.</param>
        /// <param name="turnDuration">The duration of the buff.</param>
        /// <param name="stackingType">The frame on which the buff will apply (used to resolve stacking effects).</param>
        /// <param name="extraEffects">Optional list of additional effects which will be applied on top of the elemental attack up buff.</param>
        public static Ability WindAttackUpForParty(uint strength, uint turnDuration, StackingType stackingType, params AbilityEffect[] extraEffects)
        {
            throw new NotImplementedException();
        }

        /// <returns>An <see cref="Ability"/> with the party light attack up sprite animation.</returns>
        public static Ability LightAttackUpForParty()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a party wide light attack up <see cref="Ability"/> with optional <see cref="extraEffects"/>.
        /// </summary>
        /// <param name="strength">The strength of the elemental attack up buff. Must be greater than 0.</param>
        /// <param name="turnDuration">The duration of the buff.</param>
        /// <param name="stackingType">The frame on which the buff will apply (used to resolve stacking effects).</param>
        /// <param name="extraEffects">Optional list of additional effects which will be applied on top of the elemental attack up buff.</param>
        public static Ability LightAttackUpForParty(uint strength, uint turnDuration, StackingType stackingType, params AbilityEffect[] extraEffects)
        {
            throw new NotImplementedException();
        }

        /// <returns>An <see cref="Ability"/> with the party dark attack up sprite animation.</returns>
        public static Ability DarkAttackUpForParty()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a party wide dark attack up <see cref="Ability"/> with optional <see cref="extraEffects"/>.
        /// </summary>
        /// <param name="strength">The strength of the elemental attack up buff. Must be greater than 0.</param>
        /// <param name="turnDuration">The duration of the buff.</param>
        /// <param name="stackingType">The frame on which the buff will apply (used to resolve stacking effects).</param>
        /// <param name="extraEffects">Optional list of additional effects which will be applied on top of the elemental attack up buff.</param>
        public static Ability DarkAttackUpForParty(uint strength, uint turnDuration, StackingType stackingType, params AbilityEffect[] extraEffects)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// An <see cref="Ability"/> with the attack up sprite animation (on a single character).
        /// </summary>
        /// <param name="extraEffects"></param>
        public static Ability AttackUpForSelf(params AbilityEffect[] extraEffects)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// An <see cref="Ability"/> with the charge boost sprite animation (on a single character).
        /// </summary>
        /// <param name="extraEffects"></param>
        public static Ability ChargeBarBoost(params AbilityEffect[] extraEffects)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// An <see cref="Ability"/> with the charmed sprite animation.
        /// </summary>
        public static Ability Charmed()
        {
            throw new NotImplementedException();
        }

        public static Ability Delay(double baseAccuracy)
        {
            throw new NotImplementedException();
        }
    }
}
