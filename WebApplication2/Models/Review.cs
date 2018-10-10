using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        public string UserID { get; set; }

        [Required(ErrorMessage = "Please select Book.")]
        [Display(Name = "Book Title")]
        public int BookISBN { get; set; }

        public virtual Book Book { get; set; }

        [Required(ErrorMessage = "Please enter a Rating")]
        [Range(1, 10)]
        public int Rating { get; set; }

        [StringLength(200, ErrorMessage = "Comment can only be 200 characters.")]
        public string Comment { get; set; }


       
    }
}