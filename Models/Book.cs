using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models
{
    public class Book
    {
        [DataType(DataType.DateTime)]
        [Display(Name ="Choose Date and Time")]
        public string MyField { get; set; }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }

       public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        [Required]
        public int TotalPages { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }


    }
}
