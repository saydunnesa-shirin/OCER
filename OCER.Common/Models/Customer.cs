using System.ComponentModel.DataAnnotations;

namespace OCER.Common.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public int? LoyaltyPoint { get; set; }
    }
}
