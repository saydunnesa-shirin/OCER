using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCER.Common.Models
{
    public class RentDetail
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("RentId")]
        //public virtual Rent Rent { get; set; }
        [Required]
        public int RentId { get; set; }

        //[ForeignKey("EquipmentId")]
        //public virtual Equipment Equipment { get; set; }
        [Required]
        public int EquipmentId { get; set; }

        [Required]
        public int Days { get; set; }
    }
}
