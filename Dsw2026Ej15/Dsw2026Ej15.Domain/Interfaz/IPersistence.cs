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

        void AñadirDoctor(Doctor doctor);

        void ModificarDoctor(Doctor doctor);
        Speciality? GetSpeciality(Guid id);
    }
}
