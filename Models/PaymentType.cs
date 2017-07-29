using System.ComponentModel.DataAnnotations;

/*  
* Class: PaymentType
 * Purpose: The PaymentType Class holds PaymentType information.
 * Author: One-to-What(Dylan)
 * Properties:
 *  PaymentTypeId: Unique identifier for each PaymentType
    Type: String designating the type of payment method.
    CustomerId:Stores the Id of the customer that the payment type belongs to.
 */

namespace BangazonAPI.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }
        [Required]
        public string Type { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer {get; set;}
    }
}