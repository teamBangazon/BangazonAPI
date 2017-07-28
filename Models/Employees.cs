using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// * Class: Employee
// * Purpose: The Employee class is used to store all Employee information.
//  * Author: Team One to What
//  * Properties:
//      - EmployeeId: A unique idetification number for each Employee 
//      - FirstName: First name of the Employee being added
//      - LastName: Last name of the employee being added
//      - DateHired: date of hire for the employee
//      - DepartmentId: ID of the department to which the employee belongs
//      - Department: department
//      - Supervisor: this is a Default Value which is a boolean, defaults to False unless otherwise specified

namespace BangazonAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId {get; set;}
        [Required]
        public string FirstName {get; set;}
        [Required]
        public string LastName {get; set;}
        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateHired {get; set;}
        public int DepartmentId {get; set;}
        public Department Department {get; set;}  
        [DefaultValue (false)]
        public bool Supervisor {get; set;}
    }
}