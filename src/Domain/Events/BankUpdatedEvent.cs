using System;
namespace WiseConsulting.Domain.Events;

public class BankUpdatedEvent : BaseEvent
{
    public BankUpdatedEvent(Bank bank)
    {
        Bank = bank;
    }

    public Bank Bank { get; }
}