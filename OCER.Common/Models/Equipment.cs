using System.ComponentModel.DataAnnotations;

namespace OCER.Common.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public EquipmentType EquipmentType { get; set; }

        [Required]
        public bool InStock { get; set; }

    }
}
