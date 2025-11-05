using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {
        //[Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a title!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters!")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a content!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Content must be between 3 and 100 characters!")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public Boolean IsActive { get; set; } = true;
    }
}
