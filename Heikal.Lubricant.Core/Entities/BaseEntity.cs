using System;
using System.ComponentModel.DataAnnotations;

namespace Heikal.Lubricant.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
