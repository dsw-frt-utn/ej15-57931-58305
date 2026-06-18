using Dsw2026Ej15.Domain.Entitys;
using Dsw2026Ej15.Domain.Interfaz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace Dsw2026Ej15.Data
{
   
        public class PersistenceInMemory : IPersistence
        {


            private readonly List<Doctor> Doctors = new List<Doctor>();

            private readonly List<Speciality> Specialities = new List<Speciality>();


            public PersistenceInMemory()

            {

                CargarEspecialidades();

            }


            public List<Doctor> GetDoctors() => Doctors;


            public Doctor? GetDoctor(Guid id)

            {

                return Doctors.Find(d => d._id == id);

            }

            
            public void AñadirDoctor(Doctor doctor) => Doctors.Add(doctor);


            public void ModificarDoctor(Doctor doctor)

            {

                var DoctorExistente = GetDoctor(doctor._id);

                if (DoctorExistente != null)

                {

                    DoctorExistente._name = doctor._name;

                    DoctorExistente._licenseNumber = doctor._licenseNumber;

                    DoctorExistente._speciality = doctor._speciality;

                    DoctorExistente._isActive = doctor._isActive;

                }

            }



            public void EliminarDoctor(Guid id)

            {

                Doctor? DoctorEliminar = GetDoctor(id);

                if (DoctorEliminar != null)

                {

                    Doctors.Remove(DoctorEliminar);

                }

            }


            public void DesactivarDoctor(Guid id)
        {
            Doctor? doctorToDeactivate = GetDoctor(id);
            if (doctorToDeactivate != null && doctorToDeactivate._isActive)
            {
                doctorToDeactivate._isActive = false;
            }
        }


        public List<Speciality> GetSpecialities() => Specialities;


            public Speciality? GetSpeciality(Guid id)

            {

                return Specialities.Find(d => d._id == id);

            }


            public void AñadirEspecialidad(Speciality speciality) => Specialities.Add(speciality);


            public void ModificarEspecialidad(Speciality speciality)

            {

                var EspecialidadExistente = GetSpeciality(speciality._id);

                if (EspecialidadExistente != null)

                {

                    EspecialidadExistente._description = speciality._description;


                }

            }



            public void EliminarEspecialidad(Guid id)

            {

                Doctor? EspecialidadEliminar = GetDoctor(id);

                if (EspecialidadEliminar != null)

                {

                    Doctors.Remove(EspecialidadEliminar);

                }

            }


            private void CargarEspecialidades()

            {

                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "specialities.json");

                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);

                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var list = JsonSerializer.Deserialize<List<Speciality>>(json, options);

                    if (list != null) { Specialities.AddRange(list); }
                }


            }
        }
}
