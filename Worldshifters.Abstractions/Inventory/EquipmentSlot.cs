// <copyright file="EquipmentSlot.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

#pragma warning disable CA1034 // Nested types should not be visible

namespace Worldshifters.Data.Inventory
{
    using Google.Protobuf;

    public static partial class Types
    {
        public class EquipmentSlot
        {
            public ByteString ItemId { get; set; }
        }
    }
}
