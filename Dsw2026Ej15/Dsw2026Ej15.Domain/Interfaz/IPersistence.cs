using Dsw2026Ej15.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Interfaz
{
    public interface IPersistence
    {
        List<Doctor> GetDoctors();
        Doctor? GetDoctor(Guid id);
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void RemoveDoctor(Guid id);
        void DeactivateDoctor(Guid id);

        List<Speciality> GetSpecialities();
        Speciality? GetSpeciality(Guid id);
        void AddSpeciality(Speciality speciality);
        void UpdateSpeciality(Speciality speciality);
        void RemoveSpeciality(Guid id);
    }
}
