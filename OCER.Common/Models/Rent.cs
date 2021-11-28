using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCER.Common.Models
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        //[Column(TypeName = "date")]
        [DataType(DataType.DateTime)]
        public DateTime RentDate { get; set; }

        public List<RentDetail> RentDetails { get; set; }
    }
}
