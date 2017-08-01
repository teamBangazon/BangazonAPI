using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// CLASS: TrainingProgram Models
// PURPOSE: Provides methods to handle http requests for the TrainingProgram class
// AUTHOR: Team ONE TO WHAT
// PROPERTIES:
// * TrainingProgramId: sets a unique identifier for each training program
// * StartDate: start date for training program
// * EndDate: end date for training program
// * MaxAttendees: maximum capacity by number of people for specific training program


namespace BangazonAPI.Models
{
    public class TrainingProgram
    {
        [Key]
        public int TrainingProgramId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int MaxAttendees { get; set; }
    }
}