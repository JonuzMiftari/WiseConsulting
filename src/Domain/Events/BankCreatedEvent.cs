using System;
namespace WiseConsulting.Domain.Events;

public class BankCreatedEvent : BaseEvent
{
    public BankCreatedEvent(Bank bank)
    {
        Bank = bank;
    }

    public Bank Bank { get; }
}