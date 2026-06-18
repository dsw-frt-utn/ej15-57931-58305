using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Data.DTOs
{
    internal class SpecialityDto
    {
        public Guid _id { get; set; }
        public string _name { get; set; } = string.Empty;
        public string _description { get; set; } = string.Empty;
    }
}
