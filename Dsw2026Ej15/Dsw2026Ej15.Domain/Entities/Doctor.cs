using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Entitys
{
    public class Doctor: BaseEntity
    {
        public string _name { get; set; } 
        public string _licenseNumber { get; set; }
        public bool _isActive { get; set; } = true;
        public Speciality _speciality { get; set; }

        public Doctor(string name, string licenseNumber, Speciality speciality, Guid? id = null ) : base(id)
        {
            _name = name;
            _licenseNumber = licenseNumber;
            _speciality = speciality;
            
        }



    }
}
