using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eLibrary_project.Models
{
    public class EBook : Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter book link")]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = ".pdf Link")]
        public string PdfLink { get; set; }
    }
}