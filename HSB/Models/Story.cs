using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Http;
using System.Threading.Tasks;

namespace HSB.Models
{
    public class Story
    {
        [HiddenInput(DisplayValue = false)]
        public Guid ID { get; set; }
        [Timestamp]
        [HiddenInput(DisplayValue = false)]
        public byte[] RowVersion { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Overskrift")]
        public string Headline { get; set; }

        [Required]
        [Display(Name = "Historie")]
        public string MyStory { get; set; }

        [Display(Name = "Billede")]
        public string ImagePath { get; set; }
    }
}
