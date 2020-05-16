﻿// <copyright file="EntitySnapshot.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Raid
{
    using System;
    using System.Collections.Generic;
    using Google.Protobuf.Collections;
    using Worldshifters.Data.Hero;
    using Hero = Worldshifters.Data.Inventory.Types.Hero;

    /// <summary>
    /// Represents a raid character (allie and enemies included).
    /// </summary>
    public sealed class EntitySnapshot
    {
        public enum AttackResult
        {
            None,
            Single,
            Double,
            Triple,
            MultiAttack,
            SpecialAttack,
        }

        /// <summary>
        /// Gets the hero encapsulated by this <see cref="EntitySnapshot"/>.
        /// </summary>
        public Hero Hero { get; }

        /// <summary>
        /// The value of <see cref="NumHitsReceived"/> is reset at the beginning of each turn to 0.
        /// </summary>
        public int NumHitsReceived { get; }

        /// <summary>
        /// The value of <see cref="NumDebuffsReceived"/> is reset at the beginning of each turn to 0.
        /// </summary>
        public int NumDebuffsReceived { get; }

        public int NumSpecialAttacksUsedThisTurn { get; }

        /// <summary>
        /// The value of <see cref="DodgedDamage"/> is reset at the beginning of each turn to false.
        /// </summary>
        public bool DodgedDamage { get; }

        /// <summary>
        /// The value of <see cref="DodgedDamageOrDebuff"/> is reset at the beginning of each turn to false.
        /// </summary>
        public bool DodgedDamageOrDebuff { get; }

        /// <summary>
        /// The value of <see cref="TookDamageDuringTurn"/> is reset at the beginning of each turn to false.
        /// </summary>
        public bool TookDamageDuringTurn { get; }

        /// <summary>
        /// The value of <see cref="TookTurnBaseDamage"/> is reset at the beginning of each turn to false.
        /// </summary>
        public bool TookTurnBaseDamage { get; }

        /// <remarks>0-indexed: the first ally/enemy has <see cref="PositionInFrontline"/> set to 0.</remarks>
        public int PositionInFrontline { get; }

        /// <summary>
        /// Position in the frontline of the enemy target for the character who is currently performing an action.
        /// </summary>
        public int CurrentTargetPositionInFrontline { get; }

        /// <summary>
        /// A snapshot of the raid this character belongs to. Example usages include getting raid data and interacting with other allies and enemies.
        /// </summary>
        public RaidSnapshot Raid { get; }

        public Element Element { get; set; }

        public long Hp { get; set; }

        public long MaxHp { get; set; }

        public double HpPercentage { get; }

        public int ChargeGauge { get; set; }

        public int MaxChargeGauge { get; set; }

        /// <remarks>Only applicable to npcs.</remarks>
        public int ChargeDiamonds { get; set; }

        /// <remarks>Only applicable to npcs.</remarks>
        public int MaxChargeDiamonds { get; set; }

        /// <remarks>Only applicable to npcs. Automatically reset to false at the beginning of each turn.</remarks>
        public bool NoChargeDiamondGainThisTurn { get; set; }

        /// <summary>
        /// Reset to false at the beginning of a new action, whether it is an attack, an ability or a summon.
        /// </summary>
        public bool WasTargettedByStatusEffect { get; set; }

        /// <remarks>1-1 mapping with <see cref="Inventory.Types.Hero.GetAbilities"/>.</remarks>
        public RepeatedField<int> AbilityCooldowns { get; }

        /// <summary>
        /// Stores custom key-value pairs whose lifetime spans the course of an action, allowing data sharing between trigger callbacks.
        /// </summary>
        public Dictionary<string, object> ActionLocalDataStore { get; }

        /// <summary>
        /// Dictionary of values whose lifetime spans the whole duration of a raid. Used to communicate events between different actions for instance.
        /// </summary>
        public MapField<string, TypedValue> GlobalState { get; }

        /// <returns>Local and global status effects.</returns>
        public IEnumerable<StatusEffectSnapshot> GetStatusEffects()
        {
            throw new NotImplementedException();
        }

        /// <returns>The current <see cref="StatusEffectSnapshot"/> for <see cref="id"/> or null if no such status effect could be found.</returns>
        public StatusEffectSnapshot GetStatusEffect(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatusEffectSnapshot> GetBuffs()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatusEffectSnapshot> GetDebuffs()
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

        public bool CantMove()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// <remarks>For npcs only.</remarks>
        /// </summary>
        /// <param name="totalHitCount">The number of hits of the charge attack.</param>
        /// <param name="modelMetadata">The sprite of the charge attack, if any.</param>
        /// <param name="damageModifier"></param>
        /// <param name="raidActions"></param>
        /// <param name="onAllEnemies">Whether each hit of the charge attack should hit all the enemies or not.</param>
        /// <param name="isFlatDamage">If true, the damage won't be affected by attack and defense status effects and will be equal to <see cref="damageModifier"/>. Damage cuts still apply.</param>
        /// <param name="attackElement">Optional attack element override.</param>
        /// <param name="isMultiElement">If true, each hit will be of a random element taken from a uniform distribution.</param>
        public void PerformChargeAttack(
            uint totalHitCount,
            ModelMetadata modelMetadata,
            double damageModifier,
            IList<RaidAction> raidActions,
            bool onAllEnemies = false,
            bool isFlatDamage = false,
            Element? attackElement = null,
            bool isMultiElement = false)
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
        /// Apply a status effect buff to the character with a stack count (for instance, Dark Opus weapon crests).
        /// </summary>
        public void ApplyStatusEffectStacks(string id, uint numStacks, IList<RaidAction> raidActions, int turnDuration = int.MaxValue, bool isUndispellable = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Apply a status effect buff to the character with a stack count (for instance, Dark Opus weapon crests).
        /// </summary>
        /// <param name="id">The base ID of the status effect.</param>
        /// <param name="initialStackCount">The initial number of stacks of the status effect if no previous instance exists.</param>
        /// <param name="increment">The number of stacks (signed integer) to add to the existing status effect, if any.</param>
        /// <param name="maxStackCount">The maximum number of stacks.</param>
        /// <param name="raidActions"></param>
        /// <param name="turnDuration">The duration of the status effect in number of turns.</param>
        /// <param name="isUndispellable">Whether the status effect can be dispelled or not.</param>
        /// <returns>False if the effect was removed due to its stack count reaching 0, true otherwise.</returns>
        public bool ApplyOrOverrideStatusEffectStacks(string id, uint initialStackCount, int increment, uint maxStackCount, IList<RaidAction> raidActions, int turnDuration = int.MaxValue, bool isUndispellable = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Override a status effect buff to the character with a stack count (for instance, Dark Opus weapon crests).
        /// </summary>
        /// <param name="id">The base ID of the status effect.</param>
        /// <param name="increment">The number of stacks (signed integer) to add to the existing status effect, if any.</param>
        /// <param name="maxStackCount">The maximum number of stacks.</param>
        /// <param name="raidActions"></param>
        /// <param name="turnDuration">The duration of the status effect in number of turns.</param>
        /// <param name="isUndispellable">Whether the status effect can be dispelled or not.</param>
        /// <returns>False if the effect was removed due to its stack count reaching 0 or if no existing status effect was found, true otherwise.</returns>
        public bool OverrideStatusEffectStacks(string id, int increment, uint maxStackCount, IList<RaidAction> raidActions, int turnDuration = int.MaxValue, bool isUndispellable = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Apply <see cref="StatusEffectSnapshot"/>s matching a template <see cref="StatusEffectSnapshot"/>.
        /// </summary>
        /// <param name="template">A template <see cref="ApplyStatusEffect"/>.</param>
        /// <param name="raidActions">The list of raid actions to process on the player's side.</param>
        /// <param name="idsAndModifiersAndStrength">A list of triplets of <see cref="StatusEffectSnapshot.Id"/>s, <see cref="Modifier"/>s and <see cref="StatusEffectSnapshot.Strength"/>s.</param>
        public void ApplyStatusEffectsFromTemplate(StatusEffectSnapshot template, IList<RaidAction> raidActions, params (string, Modifier, double)[] idsAndModifiersAndStrength)
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

        /// <param name="effect"></param>
        /// <param name="raidActions"></param>
        /// <param name="caster">The source of the heals: the caster's healing boosts may increase the default healed amount.</param>
        public void Heal(Heal effect, IList<RaidAction> raidActions, EntitySnapshot caster = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Grants a status effect which will trigger an ability after <see cref="turnsBeforeActivation"/>.
        /// </summary>
        /// <param name="effectId">The ID of the status effect.</param>
        /// <param name="ability">The <see cref="Ability"/> to trigger.</param>
        /// <param name="turnsBeforeActivation">The number of turns before the ability is triggered.</param>
        /// <param name="raidActions"></param>
        /// <param name="isUsedInternally">Whether to render the status effect on the client side or not.</param>
        /// <param name="isUndispellable"> Whether the status effect is undispellable or not.</param>
        /// <param name="isPassiveEffect">
        /// Whether the status effect should be treated as a passive effect or not.
        /// Passive effects are undispellable and remain when the character dies.
        /// </param>
        public void PrepareDelayedAbility(
            string effectId,
            Ability ability,
            int turnsBeforeActivation,
            IList<RaidAction> raidActions,
            bool isUsedInternally = false,
            bool isUndispellable = false,
            bool isPassiveEffect = false)
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

        public bool IsInBreakMode()
        {
            throw new NotImplementedException();
        }

        public bool IsInOverdriveMode()
        {
            throw new NotImplementedException();
        }

        public void AddChargeGauge(int amount, IList<RaidAction> raidActions = null)
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
        /// <param name="amount"></param>
        /// <param name="element"></param>
        /// <param name="raidActions"></param>
        /// <param name="countAsDamage">If set to false, the damage dealt won't count towards <see cref="EntitySnapshot.TookDamageDuringTurn"/>.</param>
        public void DealRawDamage(long amount, Element element, IList<RaidAction> raidActions, bool countAsDamage = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deal <see cref="Hp"/> null damage to the character.
        /// </summary>
        public void Kill(IList<RaidAction> raidActions)
        {
            throw new NotImplementedException();
        }

        public int GetStatusEffectStacks(string id)
        {
            throw new NotImplementedException();
        }

        public void RemoveDebuff()
        {
            throw new NotImplementedException();
        }

        public void RemoveStatusEffects(ISet<string> ids)
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
            IList<RaidAction> raidActions = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the enemy at position <see cref="targetPositionInFrontline"/> if it is alive or else the first other enemy still alive.
        /// </summary>
        /// <returns>A resolved enemy target or null if there are no enemies left.</returns>
        public EntitySnapshot ResolveEnemyTarget(int targetPositionInFrontline)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Replace the current sprite of the character with a new one.
        /// </summary>
        /// <param name="newModel">The new character sprite after his or her form changed.</param>
        /// <param name="raidActions">Required parameter to render the updated character sprite on the client side.</param>
        /// <param name="onHitEffectModel">Optional new on hit effect sprite of the character after his or her form changed.</param>
        /// <param name="specialAbility">
        /// Optional new special attack sprite of the character after his or her form changed.
        /// <remarks>The <see cref="SpecialAbility.ProcessEffects"/> value of <see cref="specialAbility"/> will be ignored. Only the <see cref="SpecialAbility.ProcessEffects"/> value of <see cref="Hero.SpecialAbility"/> is used.></remarks>
        /// </param>
        public void ChangeForm(ModelMetadata newModel, IList<RaidAction> raidActions, ModelMetadata onHitEffectModel = null, SpecialAbility specialAbility = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Replace the (<see cref="abilityIndex"/> + 1)-th ability icon with <see cref="imageUrl"/>.
        /// </summary>
        public void ChangeAbilityIcon(int abilityIndex, string imageUrl)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Override the total contribution of the equipment towards the party's <see cref="ModifierLibrary.DamageBoostWhenSuperiorElement"/> if
        /// the value of <see cref="strength"/> is stronger.
        /// </summary>
        /// <param name="strength"></param>
        public void OverrideWeaponSeraphicModifier(double strength)
        {
            throw new NotImplementedException();
        }

        /// <param name="animationName"></param>
        /// <param name="raidActions"></param>
        /// <param name="applyToAllRaidParticipants">If set to true, the animation will also be rendered for each connected raid participant, after any ongoing action finishes rendering.</param>
        public void PlayAnimation(string animationName, IList<RaidAction> raidActions, bool applyToAllRaidParticipants = false)
        {
            throw new NotImplementedException();
        }
    }
}
