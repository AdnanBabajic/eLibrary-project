using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eLibrary_project.Models
{
    public class PhysicalBook : Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter book location")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Book Location")]
        public String Location { get; set; }

        [Required]
        [Display(Name = "Available?")]
        public Boolean IsAvailable { get; set; } = true;
    }
}