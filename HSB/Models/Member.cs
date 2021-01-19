using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HSB.Services.Validations;

namespace HSB.Models
{
    public class Member
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

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Ugildig CPR-nummer")]
        public int? Cpr { get; set; }

        [Required]
        [Phone]
        //[RegularExpression(@"^[0-9]{8}$")]
        [StringLength(12, MinimumLength = 8)]
        [Display(Name = "Telefonnummer")]
        public string  PhoneNo { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 6)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Ugyldig e-mail")]
        //[DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Adresse")]
        public string Address { get; set; }


        //XXX
        [Required]
        //[RegularExpression(@"^\d{10}$")]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Index")]
        public string Zip { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "By")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Nyhedsbrev")]
        [DefaultValue(false)]
        public bool Subscribed { get; set; }

       
        [MustBeTrue (ErrorMessage = "Du skal acceptere vores vedtægter.")]
        [Display(Name = "Vedtægter")]
        public bool Conditions { get; set; }

       
        [MustBeTrue (ErrorMessage = "Du skal acceptere vores persondatapolitik.")]
        [Display(Name = "Persondatapolitik")]
        public bool PrivacyNotice { get; set; }

        [Required]
        [DefaultValue(false)]
        [Display(Name = "MobilePay Request")]
        public bool MobilePay { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Active { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Medlem siden")]
        public DateTime FromDate { get;  set; }
    }
}
