using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eLibrary_project.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Book Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the author")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Book Author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter the genre")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Book Genre")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Please enter the release date")]
        [Range(0, 2022)]
        [Display(Name = "Release Year")]
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "Please enter the cover image link")]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Cover Image")]
        public string CoverImg { get; set; }
    }
}