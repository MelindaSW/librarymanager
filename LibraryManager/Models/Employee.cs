using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public double Salary { get; set; }
        public bool IsCEO { get; set; }
        public bool IsManager { get; set; }
        public int? ManagerId { get; set; }
    }
}
