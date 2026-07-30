using Dsw2026Ej15.Domain.Entitys;
using Dsw2026Ej15.Domain.Interfaz;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Dsw2026Ej15.Data.Persistence
{
    public class PersistenceEf : IPersistence
    {
        private readonly AppDbContext _context;

        public PersistenceEf(AppDbContext context)
        {
            _context = context;
        }

        public List<Doctor> GetDoctors() => _context.Doctors.Include(d => d.Speciality).ToList();

        public Doctor? GetDoctor(Guid id) =>
            _context.Doctors.Include(d => d.Speciality).FirstOrDefault(d => d.Id == id);

        public void AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }

        public void RemoveDoctor(Guid id)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
        }

        public void DeactivateDoctor(Guid id)
        {
            var doctor = GetDoctor(id);
            if (doctor != null && doctor.IsActive)
            {
                doctor.IsActive = false;
                _context.SaveChanges();
            }
        }

        public List<Speciality> GetSpecialities() => _context.Specialities.ToList();

        public Speciality? GetSpeciality(Guid id) => _context.Specialities.FirstOrDefault(s => s.Id == id);

        public void AddSpeciality(Speciality speciality)
        {
            _context.Specialities.Add(speciality);
            _context.SaveChanges();
        }

        public void UpdateSpeciality(Speciality speciality)
        {
            _context.Specialities.Update(speciality);
            _context.SaveChanges();
        }

        public void RemoveSpeciality(Guid id)
        {
            var speciality = GetSpeciality(id);
            if (speciality != null)
            {
                _context.Specialities.Remove(speciality);
                _context.SaveChanges();
            }
        }
    }
}

