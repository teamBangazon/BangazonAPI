using System.ComponentModel.DataAnnotations;

/*  
* Class: ProductType
 * Purpose: The ProductType Class holds ProductType information.
 * Author: One-to-What(Willie)
 * Properties:
 *  ProductTypeId: Unique identifier for each ProductType
    Type: String designating the Type of product.
 */

namespace BangazonAPI.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string Type { get; set; }
    }
}
