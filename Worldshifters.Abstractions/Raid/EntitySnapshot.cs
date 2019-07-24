﻿// <copyright file="EntitySnapshot.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Raid
{
    using System;
    using System.Collections.Generic;
    using Google.Protobuf.Collections;
    using Hero = Worldshifters.Data.Inventory.Types.Hero;

    public class EntitySnapshot
    {
        public enum AttackResult
        {
            Single,
            Double,
            Triple,
            MultiAttack,
            SpecialAttack,
        }

        public bool Attacked { get; set; }

        /// <summary>
        /// Stores custom key-value pairs whose lifetime spans the course of an action, allowing data sharing between trigger callbacks.
        /// </summary>
        public Dictionary<string, object> ActionLocalDataStore { get; }

        public Hero Hero { get; set; }

        public int NumHitsReceived { get; set; }

        public int NumSpecialAttacksUsedThisTurn { get; set; }

        public int PositionInFrontline { get; set; }

        public RaidSnapshot Raid { get; }

        public Element Element { get; }

        public long Hp { get; set; }

        public long MaxHp { get; set; }

        public double HpPercentage { get; }

        public int ChargeGauge { get; set; }

        public int MaxChargeGauge { get; set; }

        public RepeatedField<int> AbilityCooldowns { get; }

        public MapField<string, TypedValue> GlobalState { get; }

        /// <returns>Local and global status effects.</returns>
        public IEnumerable<StatusEffectSnapshot> GetStatusEffects()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Attacks <see cref="RaidSnapshot.SelectedTarget"/> and process side effects such as death, repel, and drain effects.
        /// </summary>
        public void Attack(IList<RaidAction> raidActions, double customDamageModifier = 1, bool forceSingleAttack = false, bool disableSpecialAttack = false)
        {
            throw new NotImplementedException();
        }

        /// <param name="effect">
        /// Effects which have <see cref="StatusEffectSnapshot.IsUsedInternally"/> set to true won't be
        /// rendered on the player side (but are still taken into account for server-side calculations).
        /// </param>
        /// <param name="raidActions">
        /// The list of raid updates for the current action. No visual effects for the status effect will be rendered
        /// if null is passed.
        /// </param>
        public void ApplyStatusEffect(StatusEffectSnapshot effect, IList<RaidAction> raidActions = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Apply <see cref="StatusEffectSnapshot"/>s matching a template <see cref="StatusEffectSnapshot"/>.
        /// </summary>
        /// <param name="template">A template <see cref="ApplyStatusEffect"/>.</param>
        /// <param name="idsAndModifiersAndStrength">A list of triplets of <see cref="StatusEffectSnapshot.Id"/>s, <see cref="Modifier"/>s and <see cref="StatusEffectSnapshot.Strength"/>s.</param>
        public void ApplyStatusEffectsFromTemplate(StatusEffectSnapshot template, params (string, Modifier, double)[] idsAndModifiersAndStrength)
        {
            throw new NotImplementedException();
        }

        /// <param name="amount"></param>
        /// <param name="raidActions"></param>
        /// <param name="caster">The source of the heals: the caster's healing boosts may increase the default healed amount.</param>
        public void Heal(long amount, IList<RaidAction> raidActions, EntitySnapshot caster = null)
        {
            throw new NotImplementedException();
        }

        public bool IsAlive()
        {
            throw new NotImplementedException();
        }

        public bool DiedThisTurn()
        {
            throw new NotImplementedException();
        }

        /// <returns>
        /// A <see cref="RaidAction"/> to queue to the list of raid updates for the current action, in order
        /// to force a visual update of this <see cref="EntitySnapshot"/> charge bar before the action finishes
        /// rendering on the player side.
        /// Example scenario: updating charge bars of other party members after a charge attack.
        /// </returns>
        public RaidAction AddChargeGauge(int amount)
        {
            throw new NotImplementedException();
        }

        public void Die(IList<RaidAction> raidActions)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deal raw damage to the character without taking into account damage mitigation. Charge bar won't be gained either fro, the damage received.
        /// </summary>
        public void DealRawDamage(long amount, Element element, IList<RaidAction> raidActions)
        {
            throw new NotImplementedException();
        }

        public int GetStatusEffectStacks(string id)
        {
            throw new NotImplementedException();
        }

        public void RemoveStatusEffects(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        /// <returns>true if one or more status effects were removed.</returns>
        public bool RemoveStatusEffect(string id)
        {
            throw new NotImplementedException();
        }

        /// <param name="effect"></param>
        /// <param name="baseStatusEffectId"></param>
        /// <param name="onPreviousStatusEffectOverride">
        /// Delegate method called if a previous status effect matching baseStatusEffectId exists.
        /// Input parameters: the previous status effect, the new status effect.
        /// Returns true if the new status effect (modified by the callback) should be applied.
        /// If false is returned, the previous status effect will be removed and no new effect will be applied.</param>
        /// <param name="raidActions"></param>
        public void OverrideStatusEffect(
            StatusEffectSnapshot effect,
            string baseStatusEffectId,
            Func<StatusEffectSnapshot, StatusEffectSnapshot, bool> onPreviousStatusEffectOverride,
            IList<RaidAction> raidActions)
        {
            throw new NotImplementedException();
        }
    }
}
