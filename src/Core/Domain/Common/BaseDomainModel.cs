
using System;

namespace XNerd.Ecommerce.Domain.Common
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}

