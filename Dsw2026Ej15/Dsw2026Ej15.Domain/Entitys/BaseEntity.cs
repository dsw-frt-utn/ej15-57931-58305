using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Entitys
{
    public abstract class BaseEntity
    {
        public Guid Id { get; }
        protected BaseEntity(Guid? guid = null)
        {
            Id = guid ?? Guid.NewGuid();
        }

    }
}
