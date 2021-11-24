using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OCER.Web.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OCER.Service;
using AutoMapper;
using OCER.Common.Models;

namespace OCER.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IEquipmentService _equipmentService;


        public HomeController(ILogger<HomeController> logger, IEquipmentService equipmentService, IMapper mapper)
        {
            _logger = logger;
            _equipmentService = equipmentService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var equipments = _equipmentService.AllEquipments().ToList();

            var equipmentViews = _mapper.Map<List<Equipment>, List<EquipmentViewModel>>(equipments);

            var homeViewModel = new HomeViewModel
            {
                Equipments = equipmentViews
            };

            return View(homeViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
