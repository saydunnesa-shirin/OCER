using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OCER.Service;
using OCER.Web.ViewModels;
using OCER.Common.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System;

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
            try
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
            catch(Exception ex)
            {
            }
        }

        public void ConfirmRent(List<RentDetailViewModel> equipments)
        {
            try
            {
                var rentDetails = _rentService.GetRentDetails();

                var deatils = new List<RentDetail>();

                foreach (var item in rentDetails)
                {
                    if (!equipments.Exists(q => q.Id == item.Id))
                    {
                        _equipmentService.StockInEquipment(item.EquipmentId);
                    }
                    else 
                    {
                        deatils.Add(item);
                    }
                }

                _rentService.DeleteAllRentDetails();

                _logger.LogInformation("Delete all rented items from rent detail.");

                deatils.ForEach
                (
                    x =>
                    {
                        _rentService.AddToRent(x);
                        _equipmentService.StockOutEquipment(x.EquipmentId);
                    }
                );
            }
            catch(Exception ex)
            {

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
            var rentViewModel = new RentViewModel { Rents = new List<RentDetailViewModel>() };
            try
            {
                var equipments = _equipmentService.AllEquipments().ToList();
                var rentDetails = _rentService.GetRentDetails();

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
                                EquipmentType = equipments.First(y => y.Id == x.EquipmentId).EquipmentType.ToString(),
                                Price = _rentService.CalculatePrice((int)equipments.Find(q => q.Id == x.EquipmentId).EquipmentType, x.Days),
                                BonusPoint = _rentService.CalculateBonus((int)equipments.Find(q => q.Id == x.EquipmentId).EquipmentType)
                            }
                         )
                    );
                }

                return rentViewModel;
            }
            catch (Exception ex)
            {

            }

            return rentViewModel;
        }
    }
}
