using System.ComponentModel.DataAnnotations;
using eService.Data.Models.Abstractions;

namespace eService.Data.Models
{
    public class Address : DBEntity
    {
        public virtual Town Town { get; set; }

        public virtual Street Street { get; set; }

        [Range(0, 1000)]
        public int Number { get; set; }

        [Range(0, 20)]
        public int Floor { get; set; }

        [Range(0, 1000)]
        public int ApartmentNumber { get; set; }
    }
}
