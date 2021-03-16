using AutoMapper;
using JingetSample.API.ViewModels;
using JingetSample.Domain.Entities;

namespace JingetSample.API.Mapping
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<NewUserViewModel, UserModel>();
        }
    }
}
