using ColoradoBeetle.Application.Common.Interfaces;

namespace ColoradoBeetle.Infrastructure.Services;
public class DateTimeService : IDateTimeService {
    public DateTime Now => DateTime.UtcNow.AddHours(2);

}
