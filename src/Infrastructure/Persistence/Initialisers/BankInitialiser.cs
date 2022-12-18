using System;
using WiseConsulting.Domain.Entities;

namespace WiseConsulting.Infrastructure.Persistence.Initialisers;

public class BankInitialiser
{
    private readonly ApplicationDbContext _context;

    public BankInitialiser(ApplicationDbContext context)
    {
        _context = context;
    }

    public async void Seed()
    {
        if (!_context.Banks.Any())
        {
            _context.Banks.AddRange(
                new Bank
                {
                    Name = "NLB Banka",
                    Identifier = "210"
                },
                new Bank
                {
                    Name = "Komercijalna Banka",
                    Identifier = "300"
                },
                new Bank
                {
                    Name = "Halk Bank",
                    Identifier = "270"
                },
                new Bank
                {
                    Name = "ProCredit Bank",
                    Identifier = "380"
                });

            await _context.SaveChangesAsync();
        }
    }
}

