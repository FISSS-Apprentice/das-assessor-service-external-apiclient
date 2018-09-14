﻿namespace SFA.DAS.AssessorService.ExternalApi.Core.Models.Certificates
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public sealed class SubmitCertificate : IEquatable<SubmitCertificate>
    {
        [Range(1000000000, 9999999999, ErrorMessage = "The apprentice's ULN should contain exactly 10 numbers")]
        public long Uln { get; set; }

        [Range(0, short.MaxValue, ErrorMessage = "A standard should be selected")]
        public int StandardCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the apprentice's last name")]
        public string FamilyName { get; set; }

        #region GetHashCode, Equals and IEquatable
        public override int GetHashCode()
        {
            unchecked
            {
                const int hashBase = (int)2166136261;
                const int multiplier = 16777619;

                int hash = hashBase;
                hash = (hash * multiplier) ^ Uln.GetHashCode();
                hash = (hash * multiplier) ^ StandardCode.GetHashCode();
                hash = (hash * multiplier) ^ (FamilyName is null ? 0 : FamilyName.GetHashCode());

                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return IsEqual((SubmitCertificate)obj);
        }

        public bool Equals(SubmitCertificate other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return IsEqual(other);
        }

        private bool IsEqual(SubmitCertificate other)
        {
            return Equals(Uln, other.Uln)
                && Equals(StandardCode, other.StandardCode)
                && string.Equals(FamilyName, other.FamilyName);
        }

        public static bool operator ==(SubmitCertificate left, SubmitCertificate right)
        {
            if (left is null) return right is null;
            return left.Equals(right);
        }

        public static bool operator !=(SubmitCertificate left, SubmitCertificate right)
        {
            return !(left == right);
        }
        #endregion

        #region DataAnnotations 
        public bool IsValid(out ICollection<ValidationResult> validationResults)
        {
            validationResults = new List<ValidationResult>();

            ValidationContext validationContent = new ValidationContext(this);
            return Validator.TryValidateObject(validationContent.ObjectInstance, validationContent, validationResults, true);
        }
        #endregion
    }
}