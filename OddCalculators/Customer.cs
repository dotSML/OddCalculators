using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OddCalculators
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }


    }
}