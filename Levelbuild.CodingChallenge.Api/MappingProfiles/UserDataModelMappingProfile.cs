using AutoMapper;
using Levelbuild.CodingChallenge.Api.Models;
using Levelbuild.CodingChallenge.Domain.Abstractions.Models;
using Levelbuild.CodingChallenge.Persistence.Abstractions.Models;

namespace Levelbuild.CodingChallenge.Api.MappingProfiles;

public class UserDataModelMappingProfile : Profile
{
    public UserDataModelMappingProfile()
    {
        this.CreateMap<UserModel, UserDataModel>()
            .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.DisplayName))
            .ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName))
            .ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName))
            .ForMember(d => d.DateOfBirth, o => o.MapFrom(s => s.DateOfBirth))
            .ForMember(d => d.CustomerRefId, o => o.MapFrom(s => s.Customer.Id))
            .ForMember(d => d.Email, o => o.MapFrom(s => s.Email));
    }
}