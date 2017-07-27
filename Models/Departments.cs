using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


// * Class: Department
// * Purpose: The Department class is used to store all Department information.
//  * Author: Team One to What
//  * Properties:
//      - DepartmentId: A unique idetification number for each Department
//      - Name: name of the specific department
//      - ExpenseBudget: dollar amount budget of the expenses for the department


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