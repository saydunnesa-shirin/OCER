using AutoMapper;
using OCER.Common.Models;
using OCER.Web.ViewModels;

namespace OCER.Web
{
    public class Mapper :Profile
    {
        public Mapper()
        {
            CreateMap<Equipment, EquipmentViewModel>();
        }
    }
}
