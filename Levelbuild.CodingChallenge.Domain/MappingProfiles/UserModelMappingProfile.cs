using AutoMapper;
using Levelbuild.CodingChallenge.Domain.Abstractions.Models;
using Levelbuild.CodingChallenge.Persistence.Abstractions.Models;

namespace Levelbuild.CodingChallenge.Domain.MappingProfiles;

public class UserModelMappingProfile : Profile
{
    public UserModelMappingProfile()
    {
        this.CreateMap<UserTableRecord, UserModel>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.DisplayName))
            .ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName))
            .ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName))
            .ForMember(d => d.DateOfBirth, o => o.MapFrom(s => s.DateOfBirth))
            .ForMember(d => d.Customer, o => o.MapFrom(s => s.Customer))
            .ForMember(d => d.Email, o => o.MapFrom(s => s.Email));
    }
}