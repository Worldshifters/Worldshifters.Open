// <copyright file="EquipmentSlot.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Inventory.Types
{
    using Google.Protobuf;

    public class EquipmentSlot
    {
        public ByteString ItemId { get; set; }
    }
}
