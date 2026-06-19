using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Data.DTOs
{
    internal class DoctorDto
    {
        public Guid _id { get; set; }
        public string _name { get; set; } = string.Empty;
        public string _licenseNumber { get; set; } = string.Empty;
        public Guid _specialityGuid { get; set; }
        public bool _isActive { get; set; } = true;
    }
}
