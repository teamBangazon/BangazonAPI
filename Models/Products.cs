using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get; set;}

        // public int ProductTypeId {get; set;}

        // public ProductType ProductType {get; set;}

        [Required]
        public string Title {get; set;}

        [Required]
        public int Price {get; set;}

        [Required]
        public string Description {get; set;}

        // public int CustomerId {get; set;}

        // public Customer Customer {get; set;}

        
    }
}