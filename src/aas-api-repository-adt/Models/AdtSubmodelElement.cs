﻿using System.Text.Json.Serialization;

namespace AAS.API.Repository.Adt.Models
{
    public class AdtSubmodelElement : AdtReferable
    {
        [JsonPropertyName("kind")]
        public AdtHasKind? Kind { get; set; }

        [JsonPropertyName("semanticIdValue")]
        public string? SemanticIdValue { get; set; }
    }
}
