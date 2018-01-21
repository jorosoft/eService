using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eService.Data.Models.Abstractions;

namespace eService.Data.Models
{
    public class Status : DBEntity
    {
        [Required]
        [Index(IsUnique = true)]
        [MinLength(3)]
        [MaxLength(35)]
        public string Name { get; set; }
    }
}
