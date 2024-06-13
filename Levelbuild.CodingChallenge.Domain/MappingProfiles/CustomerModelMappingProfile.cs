using AutoMapper;
using Levelbuild.CodingChallenge.Domain.Abstractions.Models;
using Levelbuild.CodingChallenge.Persistence.Abstractions.Models;

namespace Levelbuild.CodingChallenge.Domain.MappingProfiles;

public class CustomerModelMappingProfile : Profile
{
    public CustomerModelMappingProfile()
    {
        this.CreateMap<CustomerTableRecord, CustomerModel>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.WebSite, o => o.MapFrom(s => s.WebSite))
            .ForMember(d => d.Users, o => o.MapFrom(s => s.Users));
    }
}