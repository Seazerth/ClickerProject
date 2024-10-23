using AutoMapper;
using ClickerWebProject.Domain;
using ClickerWebProject.UseCases.GetBoosts;

namespace ClickerWebProject.UseCases;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Boost,GetBoostsDto>();
    }
}
