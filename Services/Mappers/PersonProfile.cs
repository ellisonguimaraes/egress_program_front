using AutoMapper;
using EgressPortal.Models.API.HttpClient.Egress.Person;

namespace EgressPortal.Services.Mappers;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<PersonResponseApi, CompleteRegisterForm>()
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
            .ForMember(dest => dest.IsAddressPublic, opt => opt.MapFrom(src => src.Address.IsPublic))
            .ForMember(dest => dest.EnterpriseName, opt => opt.MapFrom(src => src.Employment.Enterprise))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Employment.Role))
            .ForMember(dest => dest.SalaryRange, opt => opt.MapFrom(src => src.Employment.SalaryRange))
            .ForMember(dest => dest.IsEmploymentPublic, opt => opt.MapFrom(src => src.Employment.IsPublic))
            .ForMember(dest => dest.IsPublicInitiative, opt => opt.MapFrom(src => src.Employment.IsPublicInitiative))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.Employment.StartDate!, "MM/dd/yyyy", default)))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.BirthDate!, "MM/dd/yyyy", default)))
            .ForMember(dest => dest.HasCertification, opt => opt.MapFrom(src => src.ContinuingEducation.HasCertification))
            .ForMember(dest => dest.HasSpecialization, opt => opt.MapFrom(src => src.ContinuingEducation.HasSpecialization))
            .ForMember(dest => dest.HasMasterDegree, opt => opt.MapFrom(src => src.ContinuingEducation.HasMasterDegree))
            .ForMember(dest => dest.HasDoctorateDegree, opt => opt.MapFrom(src => src.ContinuingEducation.HasDoctorateDegree))
            .ForMember(dest => dest.IsContinuingEducationPublic, opt => opt.MapFrom(src => src.ContinuingEducation.IsPublic))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.CanExposeData, opt => opt.MapFrom(src => src.ExposeData))
            .ForMember(dest => dest.CanReceivedMessage, opt => opt.MapFrom(src => src.CanReceiveMessage));
    }
}