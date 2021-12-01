using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLibrary_project.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Book Id")]
        public int BookId { get; set; }

        [Required]
        [Display(Name = "User Id")]
        public string UserId { get; set; }
    }
}