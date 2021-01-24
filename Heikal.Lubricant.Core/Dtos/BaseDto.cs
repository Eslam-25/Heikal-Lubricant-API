using System;

namespace Heikal.Lubricant.Core.Dtos
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
