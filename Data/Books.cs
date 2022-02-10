using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.Data
{
    public class Books
    {
        public int Id { get; set; }
        [StringLength(100,MinimumLength =5)]
        [Required(ErrorMessage ="please enter the title of your book")]
        public string Title { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "please enter the author of your book")]
        public string Author { get; set; }
        [StringLength(300, MinimumLength = 30)]
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }

        [Required(ErrorMessage = "please enter the Total Pages of your book")]
        [Display(Name ="Total Pages Of Book")] //Customer msg
        public int? TotalPages { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
