using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class LibraryItem
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Author { get; set; }
        
        public int? Pages { get; set; }
        
        [Display(Name = "Runtime in minutes")]
        public int? RunTimeMinutes { get; set; }
        
        [Display(Name = "Is Borrowable")]
        [Required]
        public byte IsBorrowable { get; set; }

        public string Borrower { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Borrow Date")]
        public DateTime? BorrowDate { get; set; }
        
        [Required]
        public string Type { get; set; }
        
        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
