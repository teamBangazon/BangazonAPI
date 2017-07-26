using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId {get; set;}

        [Required]
        public string Name {get; set;}

        public double ExpenseBudget {get; set;}

        
    }
}