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
        public string Name { get; set; }
    }
}