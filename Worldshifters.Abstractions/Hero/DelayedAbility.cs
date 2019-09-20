// <copyright file="DelayedAbility.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;

    /// <summary>
    /// A delayed ability triggered after a certain number of turns.
    /// </summary>
    public class DelayedAbility
    {
        public int TurnsLeftBeforeActivation { get; set; }

        /// <summary>
        /// The ability which will be cast after <see cref="TurnsLeftBeforeActivation"/>.
        /// </summary>
        public Ability Ability { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}