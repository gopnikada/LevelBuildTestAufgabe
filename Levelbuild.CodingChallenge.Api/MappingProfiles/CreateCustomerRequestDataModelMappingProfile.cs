using AutoMapper;
using Levelbuild.CodingChallenge.Api.Models;
using Levelbuild.CodingChallenge.Domain.Abstractions.Models;

namespace Levelbuild.CodingChallenge.Api.MappingProfiles;

public class CreateCustomerRequestDataModelMappingProfile : Profile
{
    public CreateCustomerRequestDataModelMappingProfile()
    {
        this.CreateMap<CreateCustomerRequestDataModel, CreateCustomerRequestModel>()
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.WebSite, o => o.MapFrom(s => s.WebSite));
    }
}