using System;
using System.Collections.Generic;

namespace OCER.Web.ViewModels
{
    public class InvoiceViewModel
    {
        public string Title { get; set; }
        public decimal TotalPrice { get; set; }
        public int BonusPoints { get; set; }
        public List<RentDetailViewModel> Rents { get; set; }
        public string CustomerName { get; set; }

        public DateTime RentDate { get; set; }
    }
}
