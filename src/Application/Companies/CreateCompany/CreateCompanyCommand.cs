using MediatR;
using WiseConsulting.Application.Common.Interfaces;
using WiseConsulting.Application.Companies.Models;
using WiseConsulting.Domain.Entities;
using WiseConsulting.Domain.Enums;

namespace WiseConsulting.Application.Companies.CreateCompany;
public class CreateCompanyCommand : CompanyDto, IRequest<int> { }

public class CreateCompanyCommandHandler: IRequestHandler<CreateCompanyCommand, int>
{
    private readonly IApplicationDbContext _context;
    public CreateCompanyCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = new Company
        {
            Code = request.Code,
            Name = request.Name,
            Address = request.Address,
            City = request.City,
            Phone = request.Phone,
            Fax = request.Fax,
            Bank = request.Bank,
            AccountNumber = request.AccountNumber,
            IDNumber = request.IDNumber,
            RegistrationNumber = request.RegistrationNumber,
            TaxNumber = request.TaxNumber,
            ActivityCode = request.ActivityCode,
            MunicipalityCode = request.MunicipalityCode,
            SecondMunicipalityCode = request.SecondMunicipalityCode,
            SalaryCode = request.SalaryCode,
            MunicipalityCodeForOtherCity = request.MunicipalityCodeForOtherCity,
            ContactPerson = request.ContactPerson,
            Email = request.Email,
            InvoiceSigningPerson = request.InvoiceSigningPerson,
            InvoiceSigningPersonType = (SigningPersonType)request.InvoiceSigningPersonType
        };

        // TODO: if needed add domain event for Company Created Event
        //entity.AddDomainEvent(new CompanyCreatedEvent(entity));

        _context.Companies.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}