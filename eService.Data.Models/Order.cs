using System;
using System.ComponentModel.DataAnnotations;
using eService.Data.Models.Abstractions;

namespace eService.Data.Models
{
    public class Order : DBEntity
    {
        [Required]
        public int Number { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int WarrantyCardNumber { get; set; }

        public DateTime WarrantyCardDate { get; set; }

        [Required]
        [MinLength(2)]
        public string Article { get; set; }

        [Required]
        [MinLength(2)]
        public string Defect { get; set; }

        public string Info { get; set; }

        public virtual Status Status { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public virtual Client Client { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
