using Dsw2026Ej15.Data.DTOs;
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
        private List<Doctor> Doctors = new List<Doctor>();
        private List<Speciality> Specialities = new List<Speciality>();

        public PersistenceInMemory()
        {
            LoadSpecialities();
        }

        public List<Doctor> GetDoctors() => Doctors;

        public Doctor? GetDoctor(Guid id) => Doctors.Find(d => d.Id == id);

        public void AddDoctor(Doctor doctor) => Doctors.Add(doctor);

        public void UpdateDoctor(Doctor doctor)
        {
            var existingDoctor = GetDoctor(doctor.Id);
            if (existingDoctor != null)
            {
                existingDoctor.Name = doctor.Name;
                existingDoctor.LicenseNumber = doctor.LicenseNumber;
                existingDoctor.Speciality = doctor.Speciality;
                existingDoctor.IsActive = doctor.IsActive;
            }
        }

        public void RemoveDoctor(Guid id)
        {
            Doctor? doctorToRemove = GetDoctor(id);
            if (doctorToRemove != null)
            {
                Doctors.Remove(doctorToRemove);
            }
        }

        public void DeactivateDoctor(Guid id)
        {
            Doctor? doctorToDeactivate = GetDoctor(id);
            if (doctorToDeactivate != null && doctorToDeactivate.IsActive)
            {
                doctorToDeactivate.IsActive = false;
            }
        }

        public List<Speciality> GetSpecialities() => Specialities;

        public Speciality? GetSpeciality(Guid id) => Specialities.Find(s => s.Id == id);

        public void AddSpeciality(Speciality speciality) => Specialities.Add(speciality);

        public void UpdateSpeciality(Speciality speciality)
        {
            var existingSpeciality = GetSpeciality(speciality.Id);
            if (existingSpeciality != null)
            {
                existingSpeciality.Name = speciality.Name;
                existingSpeciality.Description = speciality.Description;
            }
        }

        public void RemoveSpeciality(Guid id)
        {
            Speciality? specialityToRemove = GetSpeciality(id);
            if (specialityToRemove != null)
            {
                Specialities.Remove(specialityToRemove);
            }
        }

        private void LoadSpecialities()
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "specialities.json");
            var json = File.ReadAllText(jsonPath);
            var specialities = JsonSerializer.Deserialize<List<SpecialityDto>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? [];
            Specialities = specialities.Select(s => new Speciality(s.Name, s.Description, s.Id)).ToList();
        }
    }
}
