using eService.Data.Models.Abstractions;

namespace eService.Data.Models
{
    public class Address : DBEntity
    {
        public virtual City City { get; set; }

        public virtual Street Street { get; set; }

        public int Number { get; set; }

        public int Floor { get; set; }

        public int ApartmentNumber { get; set; }
    }
}
