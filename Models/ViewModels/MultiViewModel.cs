using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website1.Models
{
    public class MultiViewModel
    {
        [Required(ErrorMessage = "A value is required")]
        [DisplayName("Value 1")]
        [Range(0,12, ErrorMessage = "Please enter a value between 0 and 12 for Value 1")]
        
        public int Int1 { get; set; }
        [Required(ErrorMessage = "A value is required")]
        [DisplayName("Value 2")]
        [Range(0, 12, ErrorMessage = "Please enter a value between 0 and 12 for Value 2")]
        
        public int Int2 { get; set; }
       
    }
}