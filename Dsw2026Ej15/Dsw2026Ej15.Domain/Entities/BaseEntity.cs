using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Entitys
{
    public abstract class BaseEntity
    {
        public Guid _id { get; }
        protected BaseEntity(Guid? guid = null)
        {
            _id = guid ?? Guid.NewGuid();
        }
      


    }
}
