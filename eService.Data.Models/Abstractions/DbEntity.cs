using System;
using System.ComponentModel.DataAnnotations.Schema;
using eService.Data.Models.Contracts;

namespace eService.Data.Models.Abstractions
{
    public class DBEntity : IDeletable
    {
        public DBEntity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
