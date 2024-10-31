using AutoMapper;
using ClickerWebProject.Domain;
using ClickerWebProject.UseCases.GetBoosts;
using ClickerWebProject.UseCases.GetCurrentUser;

namespace ClickerWebProject.UseCases;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Boost,GetBoostsDto>();
        CreateMap<UserBoost,UserBoostDto>();
        CreateMap<ApplicationUser,UserDto>();
    }
}
