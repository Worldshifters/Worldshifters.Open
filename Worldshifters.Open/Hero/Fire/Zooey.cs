// <copyright file="Zooey.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Assets.Hero.Fire
{
    using System;
    using Google.Protobuf;
    using Worldshifters.Data;
    using Worldshifters.Data.Hero;

    public static class Zooey
    {
        public static Guid Id = Guid.Parse("60d4c46a-f1bd-4d11-b39b-e18835d5e21d");

        public static Hero NewInstance()
        {
            var zooey = Dark.Zooey.NewInstance();
            zooey.Id = ByteString.CopyFrom(Id.ToByteArray());
            zooey.Element = Element.Fire;
            zooey.Abilities[0] = Dark.Zooey.Resolution(cooldown: 9, damageModifier: 6, damageElement: Element.Fire);
            zooey.Abilities[2] = Dark.Zooey.Thunder(damageElement: Element.Fire);
            zooey.UpgradedAbilities[0].Ability = Dark.Zooey.Resolution(cooldown: 8, damageModifier: 9, damageElement: Element.Fire);
            return zooey;
        }
    }
}