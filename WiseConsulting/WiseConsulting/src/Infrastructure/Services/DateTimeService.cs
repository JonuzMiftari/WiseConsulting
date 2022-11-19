using WiseConsulting.Application.Common.Interfaces;

namespace WiseConsulting.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
