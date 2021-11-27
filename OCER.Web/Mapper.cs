using AutoMapper;
using OCER.Common.Models;
using OCER.Web.ViewModels;

namespace OCER.Web
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Equipment, EquipmentViewModel>()
                .ForMember(vm => vm.EquipmentTypeId, m => m.MapFrom(src => (int)src.EquipmentType));

            CreateMap<EquipmentViewModel, RentDetail>()
            .ForMember(dest => dest.EquipmentId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.Days));
        }
    }
}
