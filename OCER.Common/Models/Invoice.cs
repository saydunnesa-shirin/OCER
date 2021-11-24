using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCER.Common.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [ForeignKey("RentId")]
        public virtual Rent Rent { get; set; }
        [Required]
        public int RentId { get; set; }

    }
}
