// <copyright file="TypedValue.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data
{
    using System;

    public class TypedValue
    {
        private TypedValue()
        {
        }

        public bool BooleanValue { get; set; }

        public double DoubleValue { get; set; }

        public long IntegerValue { get; set; }

        public string StringValue { get; set; }

        public static TypedValue FromBool(bool b)
        {
            throw new NotImplementedException();
        }

        public static TypedValue FromDouble(double b)
        {
            throw new NotImplementedException();
        }

        public static TypedValue FromLong(long b)
        {
            throw new NotImplementedException();
        }

        public static TypedValue FromString(string b)
        {
            throw new NotImplementedException();
        }
    }
}
