using Dsw2026Ej15.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using Dsw2026Ej15.Domain.Interfaz;
using Microsoft.EntityFrameworkCore;


namespace Dsw2026Ej15.Data.Entities.Persistence
{
    public class PercistenceEf : IPersistence
    {
        private readonly AppDbContext _context;
        public PercistenceEf(AppDbContext context)
        {
            _context = context;
        }
        public Speciality? GetSpeciality(Guid id)
        {
            return _context.Specialities.FirstOrDefault(s => s._id == id);
        }
        public void AñadirDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }
        public List<Doctor> GetDoctors()
        {
            return _context.Doctors.Include(d => d._speciality).ToList();
        }
        public Doctor? GetDoctor(Guid id)
        {
            return _context.Doctors.Include(d => d._speciality).FirstOrDefault(d => d._id == id);
        }
        public void ModificarDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
        }
    }
}
