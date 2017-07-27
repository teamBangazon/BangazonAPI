using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// CLASS: TrainingProgram Models
// PURPOSE: Provides methods to handle http requests for the TrainingProgram class
// AUTHOR: Team ONE TO WHAT
// PROPERTIES: 
// Get(): Retrieves list of all TrainingProgram from Db.
// Get(int id): Retrieves list of a single TrainingProgram from Db as specified by the id.
// Post: Creates new instance of TrainingProgram class and adds it to the Db.
// Put: Edits a single TrainingProgram instance specified by the id in the url request.
// Customer Exists: used by Post and Put methods to see if a specific instance of the TrainingProgram class already exists. 

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
        
        // public DateTime lastInteraction { get; set; }

        [DefaultValue (false)]
        public bool Active { get; set; }
    }
}