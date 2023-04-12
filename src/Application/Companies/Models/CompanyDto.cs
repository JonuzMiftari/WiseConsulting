using AutoMapper;
using WiseConsulting.Application.Common.Mappings;
using WiseConsulting.Domain.Entities;

namespace WiseConsulting.Application.Companies.Models;
public class CompanyDto : IMapFrom<Company>
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string Name { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    // TODO: change bank to bank entity
    public string Bank { get; set; }
    public string AccountNumber { get; set; }
    // Maticen broj
    public string? IDNumber { get; set; }
    // Registarski broj
    public string? RegistrationNumber { get; set; }
    public string? TaxNumber { get; set; }
    public string? ActivityCode { get; set; }
    public int MunicipalityCode { get; set; }
    public int SecondMunicipalityCode { get; set; }
    public int SalaryCode { get; set; }
    public int MunicipalityCodeForOtherCity { get; set; }
    public string? ContactPerson { get; set; }
    public string? Email { get; set; }
    public string? InvoiceSigningPerson { get; set; }
    public int InvoiceSigningPersonType { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Company, CompanyDto>()
            .ForMember(d => d.InvoiceSigningPersonType, opt => opt.MapFrom(s => (int)s.InvoiceSigningPersonType));
    }
}