﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eService.Data.Models.Abstractions;

namespace eService.Data.Models
{
    public class Status : DBEntity
    {
        [Required]
        [Range(0, 10)]
        public int WorkFlowLevel { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(3)]
        [MaxLength(35)]
        public string Name { get; set; }
    }
}
