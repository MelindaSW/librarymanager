using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class LibraryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int? Pages { get; set; }
        public int? RunTimeMinutes { get; set; }
        public byte IsBorrowable { get; set; }
        public string Borrower { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BorrowDate { get; set; }
        public string Type { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
