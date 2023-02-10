﻿using System.Text.Json.Serialization;
using Azure.DigitalTwins.Core;

namespace AAS.API.Repository.Adt.Models;

public class AdtLanguageString
{
    [JsonPropertyName("langString")] 
    public Dictionary<string, string>? LangStrings { get; set; }

    [JsonPropertyName(DigitalTwinsJsonPropertyNames.DigitalTwinMetadata)]
    public DigitalTwinMetadata Metadata { get; set; }
}