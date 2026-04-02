using ASOFOTEC_Web.DTOs;
using ASOFOTEC_Web.Models;
using AutoMapper;

namespace ASOFOTEC_Web.AutoMapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<InsertSystemDto, Systems>();
            CreateMap<Systems, SystemDto>()
                .ForMember(dto => dto.SystemID,
                M => M.MapFrom(S => S.SystemID));
        }
    }
}
