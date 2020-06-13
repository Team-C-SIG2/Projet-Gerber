﻿using System.ComponentModel.DataAnnotations;

namespace IdentityServerAspNetIdentity.ViewModels
{
    public class PhoneNumberCheckViewModel
    {
        private string _countryCodeSelected;

        [Required]
        [Display(Name = "Issuing Country")]
        public string CountryCodeSelected
        {
            get => _countryCodeSelected;
            set => _countryCodeSelected = value.ToUpperInvariant();
        }

        [Required]
        [Display(Name = "Number to Check")]
        public string PhoneNumberRaw { get; set; }

        // Holds the validation response. Not for data entry.
        [Display(Name = "Valid Number")]
        public bool Valid { get; set; }

        // Holds the validation response. Not for data entry.
        [Display(Name = "Has Extension")]
        public bool HasExtension { get; set; }
    }
}
