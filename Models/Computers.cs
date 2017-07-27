using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class Computer
    {
        [Key]
        public int ComputerId {get; set;}

        // need to change strings to DateTime type
        // figure out how to input DateTime correctly through Postman

        [Required]
        public DateTime PurchasedDate {get; set;}
        
        public int?  DecommisionedDate {get; set;}        
    }
}