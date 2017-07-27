using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string Type { get; set; }
    }
}