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
    public class Case
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
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Postnr")]
        public string Zip { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "By")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fødselsdag")]
        public DateTime Birthdate { get; set; }

        [Required]
        [Phone]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "Ugyldigt nummer")]
        [Display(Name = "Telefon")]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 6)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Ugyldig e-mail")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 6)]
        [Display(Name = "Diagnose")]
        public string Diagnosis { get; set; }

        [Required]
        [StringLength(10000, MinimumLength = 6)]
        [Display(Name = "Beskrivelse")]
        public string Story { get; set; }

        [Required]
        [DefaultValue(false)]
        [Display(Name = "Aktiv")]
        public bool Active { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 6)]
        [Display(Name = "Forælder")]
        public string Parent { get; set; }

        [MustBeTrue (ErrorMessage = "Du skal acceptere vores vedtægter.")]
        [Display(Name = "Vedtægter")]
        public bool Conditions { get; set; }

       
        [MustBeTrue (ErrorMessage = "Du skal acceptere vores persondatapolitik.")]
        [Display(Name = "Persondatapolitik")]
        public bool PrivacyNotice { get; set; }

    }
}
