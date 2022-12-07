﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AAS.API.Models;

namespace AdtModels.AdtModels
{
    public class AdtSubmodel : AdtBase
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("kind/kind")]
        public ModelingKind Kind { get; set; }

    }
}