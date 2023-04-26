namespace WiseConsulting.Domain.Events;
public class CompanyDeletedEvent : BaseEvent
{
    public CompanyDeletedEvent(Company company)
    {
        Company = company;
    }

    public Company Company { get; }
}
