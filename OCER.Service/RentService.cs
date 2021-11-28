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
            _logger.LogInformation($" Added selected equipment by customer to rent item. Rent item: { rentDetail}");
            return result;
        }

        public bool DeleteFromRent(RentDetail rentDetail)
        {
            var result = _rentRepository.DeleteFromRent(rentDetail);
            _logger.LogInformation($" Delete equipment from rent. Rent item: { rentDetail}");
            return result;
        }

        public Rent GetRent()
        {
            return _rentRepository.GetRent();
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
        
        /// <summary>
        /// Calculate customer loyality points based on equipment type
        /// </summary>
        /// <param name="equipmentType"></param>
        /// <returns></returns>
        public int CalculateBonus(int equipmentType)
        {
            int bonusPoint = 0;

            if (equipmentType > 0)
            {
                switch (equipmentType)
                {
                    case (int)EquipmentType.Heavy:
                        bonusPoint = 2;
                        break;
                    case (int)EquipmentType.Regular:
                        bonusPoint = 1;
                        break;
                    case (int)EquipmentType.Specialized:
                        bonusPoint = 1;
                        break;

                    default:
                        _logger.LogWarning($"Unknown equipment type: {equipmentType}");
                        break;
                }
            }

            return bonusPoint;
        }


    }

        //(noOfDays>1? ((int) FeeType.Premium* 2 + (int) FeeType.Regular * (noOfDays-2)) :
             //((int) FeeType.Premium* 2 + ((int) FeeType.Regular* (noOfDays - 2)))) ;
}
