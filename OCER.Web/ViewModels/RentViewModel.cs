using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCER.Web.ViewModels
{
    public class RentViewModel
    {
        public List<RentDetailViewModel> Rents { get; set; }
    }

    public class RentDetailViewModel
    {
        public int Id { get; set; }
        public int RentId { get; set; }
        public string EquipmentName { get; set; }
        public int Days { get; set; }
        public decimal Price { get; set; }
    }
}
