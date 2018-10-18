using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class BookClub
    {
        [Key]
        public int BookClubID { get; set; }

        [Required(ErrorMessage = "Indicate Book Club Name.")]
        [StringLength(55, ErrorMessage = "Book Club Name cannot be longer than 25 characters.")]
        [Display(Name = "Book Club Name")]
        public string BookClubName { get; set; }

        [Required]
        [Display(Name = "BookClub Admin email address")]
        public string AdminEmail { get; set; }

        [Required(ErrorMessage = "Tell us about your Book Club....")]
        [Display(Name = "BookClub Profile")]
        public string Profile { get; set; }

        [Required(ErrorMessage = "Indicate if the Book Club is open or closed for new members.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "What province is your Book Club in?")]
        public string Province { get; set; }

        [Required(ErrorMessage = "What County is your Book Club in?")]
        public string County { get; set; }


        [Required(ErrorMessage = "What Area within yourCounty is your Book Club in?")]
        public string Area { get; set; }

        [Required(ErrorMessage = "Select the local Library linked with your Book Club")]
        public string LibraryName { get; set; }

        [Required(ErrorMessage = "Set the Next Meeting Details for your Book Club")]
        public string NextMeeting { get; set; }

        [Required(ErrorMessage = "Set the Current Read for your Book Club")]
        public string CurrentRead { get; set; }

        [Required(ErrorMessage = "List last 10 books readby your Book Club")]
        public IList ReadList { get; set; }

        public virtual ICollection<BookClub> BookClubs { get; set; }
    }
}