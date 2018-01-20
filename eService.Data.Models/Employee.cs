using eService.Data.Models.Abstractions;

namespace eService.Data.Models
{
    public class Employee : DBEntity
    {
        public string Name { get; set; }
    }
}
