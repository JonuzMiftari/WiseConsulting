using System;
namespace WiseConsulting.Domain.Events;

public class BankDeletedEvent : BaseEvent
{
    public BankDeletedEvent(Bank bank)
    {
        Bank = bank;
    }

    public Bank Bank { get; }
}