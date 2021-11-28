using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OCER.Service;
using OCER.Web.ViewModels;
using OCER.Common.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace OCER.Web.Controllers
{
    public class RentController : Controller
    {
        private readonly ILogger<RentController> _logger;
        private readonly IMapper _mapper;
        private readonly IRentService _rentService;
        private readonly IEquipmentService _equipmentService;
        

        public RentController(ILogger<RentController> logger, IMapper mapper, IRentService rentService,  IEquipmentService equipmentService)
        {
            _logger = logger;
            _mapper = mapper;
            _rentService = rentService;
            _equipmentService = equipmentService;
        }

        public ViewResult Index()
        {
            return View();
        }

        public void RentEquipments(List<EquipmentViewModel> equipments)
        {
            List<EquipmentViewModel> rentedEquipments = equipments.Where(x => x.Days > 0).ToList();
            rentedEquipments.ForEach
            (
                x =>
                {
                    RentDetail rentDetail = _mapper.Map<RentDetail>(x); // x == EquipmentViewModel
                    _rentService.AddToRent(rentDetail);
                    _equipmentService.StockOutEquipment(rentDetail.EquipmentId);
                }
            );
        }

        public void ConfirmRent(List<EquipmentViewModel> equipments)
        {
            var rentDetails = _rentService.GetRentDetails();

            //var result = from r in rentDetails
            //             join e in equipments
            //             on r.Id equals e.Id
            //            select new
            //            {
            //                e
            //            };

            var list = rentDetails;

            foreach (var item in list)
            {
                if(!equipments.Exists(q=>q.Id == item.Id))
                {
                    var rentDetail = rentDetails.FirstOrDefault(q => q.Id == item.Id);
                    _rentService.DeleteFromRent(rentDetail);
                    _equipmentService.StockInEquipment(rentDetail.EquipmentId);
                }
            }
        }

        public void DeleteEquipment(int id)
        {
            _equipmentService.StockInEquipment(id);
        }

        public JsonResult GetData()
        {
            RentViewModel rentViewModel = GetRentData();
            var json = JsonSerializer.Serialize(rentViewModel.Rents);
            return Json(json);
        }

        private RentViewModel GetRentData()
        {
            var equipments = _equipmentService.AllEquipments().ToList();
            var rentDetails = _rentService.GetRentDetails();
            var rentViewModel = new RentViewModel { Rents = new List<RentDetailViewModel>() };

            if (rentDetails != null)
            {
                rentDetails.ForEach
                (x =>
                    rentViewModel.Rents.Add
                    (
                        new RentDetailViewModel
                        {
                            EquipmentName = equipments.First(y => y.Id == x.EquipmentId).Name,
                            Id = x.Id,
                            Days = x.Days,
                            RentId = x.RentId,
                            Price = _rentService.CalculatePrice((int)equipments.Find(q => q.Id == x.EquipmentId).EquipmentType, x.Days),
                            BonusPoint = 10 // implement service method
                        }
                     )
                );
            }

            return rentViewModel;
        }
    }
}
