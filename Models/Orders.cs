using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// * Class: Customer Controller
// * Purpose: Provides methods to handle http requests involving    instances of the customer class.
// * Author: Team One to What
//  * Properties:
//      - OrderId: A unique idetification number for each Order 
//      - CustomerId: A unique identifier for each customer
//      - PaymentTypeId: nullable value, unique identifier for PaymentType
//      - PaymentType: PaymentType
//      - CreatedOn: time of creation of the order

namespace BangazonAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        // need to change strings to DateTime type
        // figure out how to input DateTime correctly through Postman

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer {get; set;}
        
        public int? PaymentTypeId { get; set; }

        public PaymentType PaymentType { get; set; }

        [DataType(DataType.DateTime)]  
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }        
    }
}