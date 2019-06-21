using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBoard.WEB.ViewModels
{
    public class WorkTaskViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "TitleRequired")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "DescriptionRequired")]
        public string Description { get; set; }

        [Display(Name = "TaskState")]
        public string TaskState { get; set; }


        public string AuthorUserId { get; set; }
        [Display(Name = "AuthorName")]
        public string AuthorName { get; set; }


        
        public string LastModifiedUserId { get; set; }
        [Display(Name = "LastModifiedUserName")]
        public string LastModifiedUserName { get; set; }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "UpdatedDate")]
        public DateTime UpdatedDate { get; set; }
    }
}
