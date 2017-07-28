using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

// * Class: Product
// * Purpose: The Product class is used to store all Product information.
//  * Author: Team One to What
//  * Properties:
//      - ProductId: A unique idetification number for each Product
//      - ProductTypeId: this is the first foreign key for Product, gives type of product
//      - ProductType: ProductType
//      - Title: name of the Product
//      - Price: price for the Product
//      - Description: description of the Product
//      - CustomerId: second foreign key for Product, ID for the customer
//      - Customer: customer


namespace BangazonAPI.Models
{

    public class Product
    {
        //Primary key = ProductId
        [Key]
        public int ProductId {get; set;}

        // Foreign Key #1 is ProductTypeId

        public int ProductTypeId {get; set;}

        public ProductType ProductType {get; set;}

        [Required]
        public string Title {get; set;}

        [Required]
        public int Price {get; set;}

        [Required]
        public string Description {get; set;}

        //Foreign Key #2 is CustomerId -- Required automatically
        public int CustomerId {get; set;}

        public Customer Customer {get; set;}

        
    }
}