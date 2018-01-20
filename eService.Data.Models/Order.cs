using eService.Data.Models.Abstractions;
using System;

namespace eService.Data.Models
{
    public class Order : DBEntity
    {
        public int Number { get; set; }

        public DateTime Date { get; set; }

        public int InvoiceNumber { get; set; }

        public string Info { get; set; }

        public virtual Status Status { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public virtual Client Client { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
