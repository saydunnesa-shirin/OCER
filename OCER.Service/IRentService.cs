using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCER.Service
{
    public interface IRentService
    {
        public decimal CalculatePrice(int equipmentType, int noOfDays);
    }
}
