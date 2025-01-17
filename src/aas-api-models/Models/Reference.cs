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
    public partial class Reference : ReferenceParent, IEquatable<Reference>
    { 
        /// <summary>
        /// Gets or Sets ReferredSemanticId
        /// </summary>

        [DataMember(Name="referredSemanticId")]
        public ReferenceParent ReferredSemanticId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Reference {\n");
            sb.Append("  ReferredSemanticId: ").Append(ReferredSemanticId).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Reference)obj);
        }

        /// <summary>
        /// Returns true if Reference instances are equal
        /// </summary>
        /// <param name="other">Instance of Reference to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Reference other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    ReferredSemanticId == other.ReferredSemanticId ||
                    ReferredSemanticId != null &&
                    ReferredSemanticId.Equals(other.ReferredSemanticId)
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
                    if (ReferredSemanticId != null)
                    hashCode = hashCode * 59 + ReferredSemanticId.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Reference left, Reference right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Reference left, Reference right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
