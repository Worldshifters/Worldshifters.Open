// <copyright file="Armored.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data.Hero
{
    using System;
    using Google.Protobuf;

    public class Armored
    {
        public double PercentageChanceOfTriggering { get; set; }

        public ByteString ToByteString()
        {
            throw new NotImplementedException();
        }
    }
}