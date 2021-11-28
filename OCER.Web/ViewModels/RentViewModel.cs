using System;
using System.Collections.Generic;

namespace OCER.Web.ViewModels
{
    public class RentViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public List<RentDetailViewModel> Rents { get; set; }
    }

    public class RentDetailViewModel
    {
        public int Id { get; set; }
        public int RentId { get; set; }
        public string EquipmentName { get; set; }
        public int Days { get; set; }
        public decimal Price { get; set; }
        public int BonusPoint { get; set; }
    }
}
