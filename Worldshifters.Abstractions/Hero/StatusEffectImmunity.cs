// <copyright file="StatusEffectImmunity.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;
    using Worldshifters.Data.Raid;

    public class StatusEffectImmunity
    {
        /// <summary>
        /// The <see cref="StatusEffectSnapshot.Id"/> to which the character will be immune to.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The <see cref="Modifier"/> to which the character will be immune to.
        /// </summary>
        public Modifier Modifier { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}