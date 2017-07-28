using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// * Class: Customer Controller
// * Purpose: Provides methods to handle http requests involving    instances of the customer class.
// * Author: Team One to What
// * Properties:
// *   Get(): Retrieves a list of all customer’s from DB
//     Get(int id): Retrieves a list of a single customer specified by Id in the url or the request
//     Post: Creates a new instance of the customer class and add’s it to the Db
//     CustomerExists: used by Post and Put methods to see if a specific instance of the customer class exists already
//     Put: Modifies a single customer instance specified by Id in the url request
// */

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
        
        // public int PaymentTypeId { get; set; }
        // public PaymentType PaymentType { get; set; }

        public string CreatedOn { get; set; }        
    }
}