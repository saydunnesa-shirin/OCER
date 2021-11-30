using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OCER.Service;
using OCER.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OCER.Web.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ILogger<RentController> _logger;
        private readonly IRentService _rentService;
        private readonly IEquipmentService _equipmentService;
        private readonly ICustomerService _customerService;

        public InvoiceController(ILogger<RentController> logger, IRentService rentService, IEquipmentService equipmentService, ICustomerService customerService)
        {
            _logger = logger;
            _rentService = rentService;
            _equipmentService = equipmentService;
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View(GetInvoiceData());
        }

        public InvoiceViewModel GetInvoiceData()
        {
            try
            {
                var equipments = _equipmentService.AllEquipments().ToList();
                var invoiceViewModel = new InvoiceViewModel { Rents = new List<RentDetailViewModel>() };
                var rent = _rentService.GetRent();

                if (rent != null && rent.RentDetails.Count > 0)
                {
                    invoiceViewModel.Title = "Online Construction Equipment Rental";
                    invoiceViewModel.CustomerName = _customerService.GetCustomerById(rent.CustomerId).Name;
                    invoiceViewModel.RentDate = rent.RentDate;

                    if (rent.RentDetails != null)
                    {
                        rent.RentDetails.ForEach
                        (x =>
                            invoiceViewModel.Rents.Add
                            (
                                new RentDetailViewModel
                                {
                                    EquipmentName = equipments.First(y => y.Id == x.EquipmentId).Name,
                                    Id = x.Id,
                                    Days = x.Days,
                                    RentId = x.RentId,
                                    Price = _rentService.CalculatePrice((int)equipments.Find(q => q.Id == x.EquipmentId).EquipmentType, x.Days),
                                    BonusPoint = _rentService.CalculateBonus((int)equipments.Find(q => q.Id == x.EquipmentId).EquipmentType)
                                }
                             )
                        );
                    }
                    invoiceViewModel.TotalPrice = invoiceViewModel.Rents.Sum(x => x.Price);
                    invoiceViewModel.BonusPoints = invoiceViewModel.Rents.Sum(x => x.BonusPoint);
                }

                return invoiceViewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating invoice");
                throw;
            }
            
        }
    }
}
