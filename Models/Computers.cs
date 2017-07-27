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

        // need to change strings to DateTime type
        // figure out how to input DateTime correctly through Postman

        [Required]
        public string PurchasedDate {get; set;}
        
        public string DecommisionedDate {get; set;}        
    }
}