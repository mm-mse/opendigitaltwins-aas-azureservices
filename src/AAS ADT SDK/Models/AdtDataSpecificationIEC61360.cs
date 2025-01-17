﻿using System.Text.Json.Serialization;

namespace AAS.ADT.Models
{
    public class AdtDataSpecificationIEC61360 : AdtDataSpecificationContent
    {
        [JsonPropertyName("definition")]
        public AdtLanguageString Definition { get; set; }

        [JsonPropertyName("preferredName")]
        public AdtLanguageString PreferredName { get; set; }

        [JsonPropertyName("shortName")]
        public AdtLanguageString ShortName { get; set; }

        [JsonPropertyName("dataType")]
        public string? DataType { get; set; }

        [JsonPropertyName("levelType")]
        public string? LevelType { get; set; }

        [JsonPropertyName("sourceOfDefinition")]
        public string? SourceOfDefinition { get; set; }

        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }

        [JsonPropertyName("unit")]
        public string? Unit { get; set; }

        [JsonPropertyName("unitIdValue")]
        public string? UnitIdValue { get; set; }
        
        [JsonPropertyName("value")]
        public string? Value { get; set; }

        [JsonPropertyName("valueFormat")]
        public string? ValueFormat { get; set; }

    }
}
