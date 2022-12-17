using MediatR;
using WiseConsulting.Application.Common.Exceptions;
using WiseConsulting.Application.Common.Interfaces;
using WiseConsulting.Application.Companies.Models;
using WiseConsulting.Domain.Entities;
using WiseConsulting.Domain.Enums;

namespace WiseConsulting.Application.Companies.UpdateCompany;
public class UpdateCompanyCommand: CompanyDto, IRequest { }

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCompanyCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Companies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Company), request.Id);
        }

        entity.Code = request.Code;
        entity.Name = request.Name;
        entity.Address = request.Address;
        entity.City = request.City;
        entity.Phone = request.Phone;
        entity.Fax = request.Fax;
        entity.Bank = request.Bank;
        entity.AccountNumber = request.AccountNumber;
        entity.IDNumber = request.IDNumber;
        entity.RegistrationNumber = request.RegistrationNumber;
        entity.TaxNumber = request.TaxNumber;
        entity.ActivityCode = request.ActivityCode;
        entity.MunicipalityCode = request.MunicipalityCode;
        entity.SecondMunicipalityCode = request.SecondMunicipalityCode;
        entity.SalaryCode = request.SalaryCode;
        entity.MunicipalityCodeForOtherCity = request.MunicipalityCodeForOtherCity;
        entity.ContactPerson = request.ContactPerson;
        entity.Email = request.Email;
        entity.InvoiceSigningPerson = request.InvoiceSigningPerson;
        entity.InvoiceSigningPersonType = (SigningPersonType)request.InvoiceSigningPersonType;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}