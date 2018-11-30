using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class BookClubMember
    {
        [Key]
        public int MemberID { get; set; }

        //navigation key
        public virtual BookClub BookClub { get; set; }

        [Required(ErrorMessage = "What is your first name.")]
        [StringLength(55, ErrorMessage = "First Name cannot be longer than 25 characters.")]
        [Display(Name = "Member First Name")]
        public string MemberFirstName { get; set; }


        [Required(ErrorMessage = "What is your last name.")]
        [StringLength(55, ErrorMessage = "Last Name cannot be longer than 25 characters.")]
        [Display(Name = "Member Last Name")]
        public string MemberLastName { get; set; }

        [Required(ErrorMessage = "What is you email address?")]
        [Display(Name = "Member email address")]
        public string MemberEmail { get; set; }

        public virtual ICollection<BookClubMember> BookClubMembers { get; set; }
        public virtual ICollection<BookClub> BookClubs { get; set; }
    }
}