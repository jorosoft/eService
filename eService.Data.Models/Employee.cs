using System.ComponentModel.DataAnnotations;
using eService.Data.Models.Abstractions;

namespace eService.Data.Models
{
    public class Employee : DBEntity
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
