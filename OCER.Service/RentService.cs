using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OCER.Common.Models;

namespace OCER.Service
{
    public class RentService : IRentService
    {
        private readonly ILogger<RentService> _logger;

        public RentService(ILogger<RentService> logger)
        {
            _logger = logger;
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
