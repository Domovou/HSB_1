using HSB.Services.Validations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HSB.Models
{
    public class Donor
    {
        [HiddenInput(DisplayValue = false)]
        public Guid ID { get; set; }

        [Timestamp]
        [HiddenInput(DisplayValue = false)]
        public byte[] RowVersion { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Fornavn")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Efternavn")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        //[RegularExpression(@"^[0-9]{8}$")]
        [StringLength(12, MinimumLength = 8)]
        [Display(Name = "Telnummer")]
        public string PhoneNo { get; set; }


        [Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Ugildig CPR-nummer")]
        public int Cpr { get; set; }

        [MustBeTrue (ErrorMessage = "Du skal acceptere vores vedtægter.")]
        [Display(Name = "Vedtægter")]
        public bool Conditions { get; set; }

       
        [MustBeTrue (ErrorMessage = "Du skal acceptere vores persondatapolitik.")]
        [Display(Name = "Persondatapolitik")]
        public bool PrivacyNotice { get; set; }

    }
}
