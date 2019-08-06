// <copyright file="EntitySnapshotExtensions.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Utils
{
    using System;
    using System.Collections.Generic;
    using Worldshifters.Data.Raid;

    public static class EntitySnapshotExtensions
    {
        /// Throws <exception cref="ArgumentException"> when there is no entity at the target position.</exception>
        /// <returns>The <see cref="EntitySnapshot"/> at <see cref="position"/>.</returns>
        public static EntitySnapshot AtPosition(this IEnumerable<EntitySnapshot> entities, int position)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Apply status effects to alive allies on the frontline.
        /// </summary>
        public static void ApplyStatusEffects(this IEnumerable<EntitySnapshot> entities, StatusEffectSnapshot statusEffect, IList<RaidAction> raidActions = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Apply status effects to alive allies on the frontline.
        /// </summary>
        public static void ApplyStatusEffectsFromTemplate(this IEnumerable<EntitySnapshot> entities, StatusEffectSnapshot statusEffect, IList<RaidAction> raidActions, params (string, Modifier, double)[] idsAndModifiersAndStrength)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Apply status effects to alive allies on the frontline.
        /// </summary>
        public static void ApplyStatusEffectsFromTemplate(this IEnumerable<EntitySnapshot> entities, StatusEffectSnapshot statusEffect, params (string, Modifier, double)[] idsAndModifiersAndStrength)
        {
            throw new NotImplementedException();
        }
    }
}
