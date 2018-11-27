using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class BookList
    {
        [Key]
        public int BookListID { get; set; }

        [Required(ErrorMessage = "Indicate Book List Name.")]
        [StringLength(55, ErrorMessage = "Book Club List cannot be longer than 25 characters.")]
        [Display(Name = "BookListName")]
        public string BookListName { get; set; }

        [Required]
        [Display(Name = "BookList Type")] /* enum?*/
        public string BookListType { get; set; }

        [Required(ErrorMessage = "This BookList contains....")]
        [Display(Name = "BookClub Content")]
        public string BookListContent { get; set; }

        [Required(ErrorMessage = "Please select the Genre type")]
        [Display(Name = "Genre Type")]
        public GenreType GenreType { get; set; }

        //not linking at this stage
    }
}