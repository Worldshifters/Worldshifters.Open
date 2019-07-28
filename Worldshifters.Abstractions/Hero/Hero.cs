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

        public Race Race { get; set; }

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
        /// Input parameters: this (the caster), the ability.
        /// </summary>
        public Action<EntitySnapshot, Ability, IList<RaidAction>> OnAbilityEnd { get; set; }

        /// <summary>
        /// The first method called before processing an action. Input parameters: this.
        /// </summary>
        /// <remarks>Called even if the character is dead.</remarks>
        public Action<EntitySnapshot, IList<RaidAction>> OnActionStart { get; set; }

        /// <summary>
        /// Input parameters: this (the current attacker), the attack type.
        /// </summary>
        /// <remarks>Called before applying drain and repel effects.</remarks>
        public Action<EntitySnapshot, EntitySnapshot.AttackResult, IList<RaidAction>> OnAttackEnd { get; set; }

        /// <summary>
        /// While <see cref="OnAttackEnd"/> is called after each single/double/triple/charge attack (once for each time the character attacks, which can be
        /// several times during a same turn for characters affected by Double/Triple strike effects for instance or who use their special attacks more than once
        /// in the same turn, <see cref="OnAttackActionEnd"/> is called once the character finished all his attacks. Input parameters: this (the current attacker).
        /// </summary>
        public Action<EntitySnapshot, IList<RaidAction>> OnAttackActionEnd { get; set; }

        /// <summary>
        /// The first method called after creating or joining a raid. It will run only once.
        /// Invoked with 'this', the other party members, the party loadout chosen when joining the raid.
        /// </summary>
        public Action<EntitySnapshot, IEnumerable<EntitySnapshot>, RaidSnapshot.Types.Loadout> OnSetup { get; set; }

        /// <summary>
        /// Input parameters: this, the enemy who targetted 'this'.
        /// </summary>
        public Action<EntitySnapshot, EntitySnapshot, IList<RaidAction>> OnTargettedByEnemy { get; set; }

        /// <summary>
        /// Input parameters: this.
        /// </summary>
        public Action<EntitySnapshot, IList<RaidAction>> OnTurnEnd { get; set; }

        /// <summary>
        /// Input parameters: this.
        /// </summary>
        public Action<EntitySnapshot, IList<RaidAction>> OnDeath { get; set; }

        /// <summary>
        /// Callback called whenever the hero enters the frontline, either from the backrow or after being revived.
        /// When the hero is revived, <see cref="OnEnteringFrontline"/> will be called first, followed by <see cref="OnSetup"/>.
        /// Input parameters: this.
        /// </summary>
        public Action<EntitySnapshot, IList<RaidAction>> OnEnteringFrontline { get; set; }
    }
}
