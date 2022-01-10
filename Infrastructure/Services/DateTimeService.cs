using EStore.Core.Common.Interfaces;

namespace EStore.Infrastructure.Services
{

    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}