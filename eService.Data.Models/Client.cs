using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eService.Data.Models.Abstractions;

namespace eService.Data.Models
{
    public class Client : DBEntity
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual Address Address { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(5)]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}
