/*
 * DotAAS Part 2 | HTTP/REST | Entire API Collection
 *
 * The entire API collection as part of Details of the Asset Administration Shell Part 2
 *
 * OpenAPI spec version: V1.0RC03
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace AAS.API.Models
{ 
        /// <summary>
        /// Gets or Sets ReferenceTypes
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum ReferenceTypes
        {
            /// <summary>
            /// Enum GlobalReferenceEnum for GlobalReference
            /// </summary>
            [EnumMember(Value = "GlobalReference")]
            GlobalReferenceEnum = 0,
            /// <summary>
            /// Enum ModelReferenceEnum for ModelReference
            /// </summary>
            [EnumMember(Value = "ModelReference")]
            ModelReferenceEnum = 1        }
}
