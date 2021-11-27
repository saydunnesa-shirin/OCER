using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using OCER.Common.Models;
using OCER.Repository;

namespace OCER.Service
{
    public class RentService : IRentService
    {
        private readonly ILogger<RentService> _logger;
        private readonly IRentRepository _rentRepository;
        public RentService(ILogger<RentService> logger, IRentRepository rentRepository)
        {
            _logger = logger;
            _rentRepository = rentRepository;
        }

        public bool AddToRent(RentDetail rentDetail)
        {
            var result = _rentRepository.AddToRent(rentDetail);

            //foreach (var item in MockData.AllEquipments)
            //{
            //    if (item.Id == rentDetail.EquipmentId)
            //        item.InStock = false;
            //}
            _logger.LogInformation($" Added selected equipment by customer to rent item. Rent item: { rentDetail}");
            return result;
        }

        public List<RentDetail> GetRentDetails()
        {
            return _rentRepository.GetRentDetails();
        }

        /// <summary>
        /// Calculate the price of each selected item based on equipment type and no of days
        /// </summary>
        /// <param name="equipmentType"></param>
        /// <param name="noOfDays"></param>
        /// <returns>Price</returns>
        public decimal CalculatePrice(int equipmentType, int noOfDays)
        {
            decimal price = 0;

            if(equipmentType > 0 && noOfDays > 0)
            {
                switch (equipmentType)
                {
                    case (int)EquipmentType.Heavy:
                        price = (int)FeeType.OneTime + (int)FeeType.Premium * noOfDays;
                        break;
                    case (int)EquipmentType.Regular:
                        price = (int)FeeType.OneTime + (int)FeeType.Premium * 2 + (int)FeeType.Regular * (noOfDays - 2);
                        break;
                    case (int)EquipmentType.Specialized:
                        price = (int)FeeType.Premium * 3 + (int)FeeType.Regular * (noOfDays - 3);
                        break;

                    default:
                        _logger.LogWarning($"Unknown equipment type: {equipmentType}");
                        break;
                }
            }

            return price;
        }

        
    }

        //(noOfDays>1? ((int) FeeType.Premium* 2 + (int) FeeType.Regular * (noOfDays-2)) :
             //((int) FeeType.Premium* 2 + ((int) FeeType.Regular* (noOfDays - 2)))) ;
}
