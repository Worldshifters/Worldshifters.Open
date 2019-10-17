// <copyright file="Hero.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using System.Collections.Generic;
    using Google.Protobuf;
    using Google.Protobuf.Collections;
    using Worldshifters.Data.Raid;

    public sealed class Hero
    {
        public RepeatedField<Ability> Abilities { get; }

        /// <summary>
        /// Attack at level 80 for characters whose max level is 100.
        /// </summary>
        public RepeatedField<long> AttackLevels { get; }

        public double BaseDoubleAttackRate { get; set; }

        public double BaseTripleAttackRate { get; set; }

        public string Description { get; set; }

        public Element Element { get; set; }

        public Gender Gender { get; set; }

        /// <summary>
        /// HP at level 80 for characters whose max level is 100.
        /// </summary>
        public RepeatedField<long> HpLevels { get; }

        public ByteString Id { get; set; }

        public long MaxAttack { get; set; }

        public int MaxChargeGauge { get; set; }

        public long MaxHp { get; set; }

        public int MaxLevel { get; set; }

        public RepeatedField<ModelMetadata> ModelMetadata { get; }

        public RepeatedField<ModelMetadata> OnHitEffectModelMetadata { get; }

        public string Name { get; set; }

        public RepeatedField<PassiveAbility> PassiveAbilities { get; }

        public RepeatedField<Race> Races { get; set; }

        public SpecialAbility SpecialAbility { get; set; }

        public RepeatedField<AbilityUpgrade> UpgradedAbilities { get; }

        public RepeatedField<PassiveAbilityUpgrade> UpgradedPassiveAbilities { get; }

        public RepeatedField<EquipmentType> WeaponProficiencies { get; }

        /// <summary>
        /// The list of extended mastery perks that the hero can master.
        /// Refer to <see cref="ExtendedMasteryPerks"/> for a list of perk IDs.
        /// </summary>
        public RepeatedField<int> AvailablePerkIds { get; }

        /// <summary>
        /// The first method called after creating or joining a raid. It will run only once.
        /// Invoked with 'this', the other party members, the party loadout chosen when joining the raid.
        /// </summary>
        public Action<EntitySnapshot, IEnumerable<EntitySnapshot>, RaidSnapshot.Types.Loadout> OnSetup { get; set; }

        /// <summary>
        /// The first method called before processing an action. Input parameters: this (the current attacker).
        /// </summary>
        /// <remarks>Called even if the character is dead.</remarks>
        public Action<EntitySnapshot, IList<RaidAction>> OnActionStart { get; set; }

        /// <summary>
        /// Callback method called before casting an <see cref="Ability"/>. It won't be called for abilities instantiated explicitly and invoked with <see cref="Ability.Cast"/>. Input parameters: this (the caster).
        /// </summary>
        /// <remarks>The ability cooldown is updated before <see cref="OnAbilityStart"/> is called. <see cref="OnAbilityStart"/> won't be called if the ability can't be cast.</remarks>
        /// <remarks>Called even if the character is dead.</remarks>
        public Action<EntitySnapshot, IList<RaidAction>> OnAbilityStart { get; set; }

        /// <summary>
        /// Callback method called before performing an attack. It won't be called if the hero can't attack. Input parameters: this.
        /// </summary>
        /// <remarks>Called even if the character is dead.</remarks>
        public Action<EntitySnapshot, IList<RaidAction>> OnAttackStart { get; set; }

        /// <summary>
        /// Input parameters: this (the current attacker).
        /// Returns a triplet (damage multiplier applied on top of the current damage, false if the attack should be aborted or true otherwise, true if the attack should hit all the foes or false otherwise).
        /// 1: no damage change. Greater than 1: damage increase. Less than 1: damage reduction.
        /// </summary>
        /// <example>Mercenary class where each hit depends on the remaining loaded bullets.</example>
        /// <remarks>Called before applying drain and repel effects.</remarks>
        public Func<EntitySnapshot, IList<RaidAction>, (double, bool, bool)> BeforeNormalAttackHit { get; set; }

        /// <summary>
        /// Input parameters: this (the current attacker), the attack type.
        /// </summary>
        /// <remarks>Called before applying drain and repel effects.</remarks>
        public Action<EntitySnapshot, EntitySnapshot.AttackResult, IList<RaidAction>> OnAttackEnd { get; set; }

        /// <summary>
        /// While <see cref="OnAttackEnd"/> is called after each single/double/triple/charge attack (once for each time the character attacks, which can be
        /// several times during a same turn for characters affected by Double/Triple strike effects for instance or who use their special attacks more than once
        /// in the same turn, <see cref="OnAttackActionEnd"/> is called once the character finished all his attacks. Input parameters: this (the current attacker), the attack type.
        /// </summary>
        public Action<EntitySnapshot, IList<RaidAction>> OnAttackActionEnd { get; set; }

        /// <summary>
        /// Input parameters: this. Ability and summon cooldowns are updated after <see cref="OnTurnEnd"/> is called.
        /// </summary>
        public Action<EntitySnapshot, IList<RaidAction>> OnTurnEnd { get; set; }

        /// <summary>
        /// Input parameters: this (the caster), the ability.
        /// </summary>
        public Action<EntitySnapshot, Ability, IList<RaidAction>> OnAbilityEnd { get; set; }

        /// <summary>
        /// Callback method called after another ally cast an ability. Input parameters: this, the caster (different from this), the ability which was cast.
        /// </summary>
        public Action<EntitySnapshot, EntitySnapshot, Ability, IList<RaidAction>> OnOtherAllyAbilityEnd { get; set; }

        /// <summary>
        /// Input parameters: this, the enemy who targetted 'this'.
        /// </summary>
        public Action<EntitySnapshot, EntitySnapshot, IList<RaidAction>> OnReceiveDamageFromEnemy { get; set; }

        /// <summary>
        /// Input parameters: this.
        /// </summary>
        public Action<EntitySnapshot, IList<RaidAction>> OnDeath { get; set; }

        /// <summary>
        /// Callback called whenever the hero enters the frontline, either from the backrow or after being revived.
        /// Input parameters: this.
        /// </summary>
        public Action<EntitySnapshot, IList<RaidAction>> OnEnteringFrontline { get; set; }
    }
}
