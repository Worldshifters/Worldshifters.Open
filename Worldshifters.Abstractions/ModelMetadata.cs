// <copyright file="ModelMetadata.cs" company="Worldshifters">
// Copyright (c) Worldshifters. All rights reserved.
// </copyright>

namespace Worldshifters.Data
{
    using Google.Protobuf.Collections;

    public class ModelMetadata
    {
        public string ConstructorName { get; set; }

        public RepeatedField<ImageAsset> ImageAssets { get; }

        public string JsAssetPath { get; set; }
    }
}
