using System.ComponentModel.DataAnnotations;

namespace OCER.Common.Models
{
    public enum EquipmentType
    {
        Heavy = 1,
        Regular,
        Specialized
    }

    public enum FeeType
    {
        //[Display(Name = "One-time")]
        OneTime = 100,
        Premium = 60,
        Regular = 40
    }
}
