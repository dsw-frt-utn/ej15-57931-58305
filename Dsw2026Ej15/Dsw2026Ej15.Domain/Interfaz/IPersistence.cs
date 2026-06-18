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

        void EliminarDoctor(Guid id);

        void DesactivarDoctor(Guid id);
        List<Speciality> GetSpecialities();

        Speciality? GetSpeciality(Guid id);

        void AñadirEspecialidad(Speciality speciality);

        void ModificarEspecialidad(Speciality speciality);

        void EliminarEspecialidad(Guid id);
    }
}
