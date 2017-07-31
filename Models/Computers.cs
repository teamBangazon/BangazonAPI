using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*  
* Class: Computer
 * Purpose: The Computer Class holds Computer information.
 * Author: One-to-What(Willie)
 * Properties:
 *  ComputerId: Unique identifier for each Computer
    PurchasedDate: Date Computer was purchased
    DecommisionedDate: Date Computer is decommisioned
 */

namespace BangazonAPI.Models
{
    public class Computer
    {
        [Key]
        public int ComputerId {get; set;}

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PurchasedDate {get; set;}
        
        public int?  DecommisionedDate {get; set;}        
    }
}