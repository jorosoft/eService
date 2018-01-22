using System;
using eService.Data.Models.Abstractions;

namespace eService.Data.Models
{
    public class History : DBEntity
    {
        public DateTime Date { get; set; }

        public virtual Order Order { get; set; }

        public virtual Status Status { get; set; }
    }
}
