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
    /// 
    /// </summary>
    [DataContract]
    public partial class AssetAdministrationShellDescriptor : Descriptor, IEquatable<AssetAdministrationShellDescriptor>
    { 
        /// <summary>
        /// Gets or Sets Administration
        /// </summary>

        [DataMember(Name="administration")]
        public AdministrativeInformation Administration { get; set; }

        /// <summary>
        /// Gets or Sets Descriptions
        /// </summary>

        [DataMember(Name="descriptions")]
        public List<LangString> Descriptions { get; set; }

        /// <summary>
        /// Gets or Sets DisplayNames
        /// </summary>

        [DataMember(Name="displayNames")]
        public List<LangString> DisplayNames { get; set; }

        /// <summary>
        /// Gets or Sets GlobalAssetId
        /// </summary>

        [DataMember(Name="globalAssetId")]
        public Reference GlobalAssetId { get; set; }

        /// <summary>
        /// Gets or Sets IdShort
        /// </summary>

        [DataMember(Name="idShort")]
        public string IdShort { get; set; }

        /// <summary>
        /// Gets or Sets Identification
        /// </summary>
        [Required]

        [DataMember(Name="identification")]
        public string Identification { get; set; }

        /// <summary>
        /// Gets or Sets SpecificAssetIds
        /// </summary>

        [DataMember(Name="specificAssetIds")]
        public SpecificAssetId SpecificAssetIds { get; set; }

        /// <summary>
        /// Gets or Sets SubmodelDescriptors
        /// </summary>

        [DataMember(Name="submodelDescriptors")]
        public List<SubmodelDescriptor> SubmodelDescriptors { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AssetAdministrationShellDescriptor {\n");
            sb.Append("  Administration: ").Append(Administration).Append("\n");
            sb.Append("  Descriptions: ").Append(Descriptions).Append("\n");
            sb.Append("  DisplayNames: ").Append(DisplayNames).Append("\n");
            sb.Append("  GlobalAssetId: ").Append(GlobalAssetId).Append("\n");
            sb.Append("  IdShort: ").Append(IdShort).Append("\n");
            sb.Append("  Identification: ").Append(Identification).Append("\n");
            sb.Append("  SpecificAssetIds: ").Append(SpecificAssetIds).Append("\n");
            sb.Append("  SubmodelDescriptors: ").Append(SubmodelDescriptors).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public  new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((AssetAdministrationShellDescriptor)obj);
        }

        /// <summary>
        /// Returns true if AssetAdministrationShellDescriptor instances are equal
        /// </summary>
        /// <param name="other">Instance of AssetAdministrationShellDescriptor to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AssetAdministrationShellDescriptor other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Administration == other.Administration ||
                    Administration != null &&
                    Administration.Equals(other.Administration)
                ) && 
                (
                    Descriptions == other.Descriptions ||
                    Descriptions != null &&
                    Descriptions.SequenceEqual(other.Descriptions)
                ) && 
                (
                    DisplayNames == other.DisplayNames ||
                    DisplayNames != null &&
                    DisplayNames.SequenceEqual(other.DisplayNames)
                ) && 
                (
                    GlobalAssetId == other.GlobalAssetId ||
                    GlobalAssetId != null &&
                    GlobalAssetId.Equals(other.GlobalAssetId)
                ) && 
                (
                    IdShort == other.IdShort ||
                    IdShort != null &&
                    IdShort.Equals(other.IdShort)
                ) && 
                (
                    Identification == other.Identification ||
                    Identification != null &&
                    Identification.Equals(other.Identification)
                ) && 
                (
                    SpecificAssetIds == other.SpecificAssetIds ||
                    SpecificAssetIds != null &&
                    SpecificAssetIds.Equals(other.SpecificAssetIds)
                ) && 
                (
                    SubmodelDescriptors == other.SubmodelDescriptors ||
                    SubmodelDescriptors != null &&
                    SubmodelDescriptors.SequenceEqual(other.SubmodelDescriptors)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Administration != null)
                    hashCode = hashCode * 59 + Administration.GetHashCode();
                    if (Descriptions != null)
                    hashCode = hashCode * 59 + Descriptions.GetHashCode();
                    if (DisplayNames != null)
                    hashCode = hashCode * 59 + DisplayNames.GetHashCode();
                    if (GlobalAssetId != null)
                    hashCode = hashCode * 59 + GlobalAssetId.GetHashCode();
                    if (IdShort != null)
                    hashCode = hashCode * 59 + IdShort.GetHashCode();
                    if (Identification != null)
                    hashCode = hashCode * 59 + Identification.GetHashCode();
                    if (SpecificAssetIds != null)
                    hashCode = hashCode * 59 + SpecificAssetIds.GetHashCode();
                    if (SubmodelDescriptors != null)
                    hashCode = hashCode * 59 + SubmodelDescriptors.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(AssetAdministrationShellDescriptor left, AssetAdministrationShellDescriptor right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AssetAdministrationShellDescriptor left, AssetAdministrationShellDescriptor right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
