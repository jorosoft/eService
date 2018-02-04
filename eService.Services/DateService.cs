using System;
using eService.Services.Contracts;

namespace eService.Services
{
    public class DateService : IDateService
    {
        public DateTime Today
        {
            get
            {
                return DateTime.Now.Date;
            }
        }
    }
}
