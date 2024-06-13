using AutoMapper;
using Levelbuild.CodingChallenge.Api.Models;
using Levelbuild.CodingChallenge.Domain.Abstractions.Models;
using Levelbuild.CodingChallenge.Persistence.Abstractions.Models;

namespace Levelbuild.CodingChallenge.Api.MappingProfiles;

public class CustomerDataModelMappingProfile : Profile
{
    public CustomerDataModelMappingProfile()
    {
        this.CreateMap<CustomerModel, CustomerDataModel>()
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.WebSite, o => o.MapFrom(s => s.WebSite));
    }
}