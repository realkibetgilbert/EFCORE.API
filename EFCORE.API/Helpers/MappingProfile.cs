using AutoMapper;
using EFCORE.API.Dtos;
using MODEL;

namespace EFCORE.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<StudentToCreateDto, Student>().ReverseMap();
        }
    }
}
