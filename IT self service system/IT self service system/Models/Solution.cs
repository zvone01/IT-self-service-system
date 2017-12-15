using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_self_service_system.Models
{
    public class Solution
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Pleas enter valid title")]
        [StringLength(255)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Pleas enter description")]
        public string Description { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? CreateDate { get; set; }

        public ApplicationUser CreatedBy { get; set; }

       // [Display(Name = "Created by")]
      //  public string ApplicationUserId { get; set; }
        
    }
}