using Dsw2026Ej15.Api.DTOs;
using Dsw2026Ej15.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;
using Dsw2026Ej15.Domain.Interfaz;
using Dsw2026Ej15.Domain.Validators;
using Dsw2026Ej15.Domain.Exceptions;


namespace Dsw2026Ej15.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IPersistence _persistencia;

            public DoctorsController(IPersistence persistencia)
            {
                _persistencia = persistencia;
            }

            //Post api/doctors
            [HttpPost]
            public ActionResult CreateDoctor([FromBody] CreateDoctorDto dto)
            {
                Speciality? speciality = _persistencia.GetSpeciality(dto._specialityId);
                List<string> errors = DoctorsValidator.ValidateNew(dto._name, dto._licenseNumber, speciality);
                if (errors.Count > 0) { throw new ValidationException(string.Join("-", errors)); }
                var doctor = new Doctor(dto._name, dto._licenseNumber   , speciality);
                _persistencia.AñadirDoctor(doctor);
                return Created();
            }

            //Get api/doctors
            [HttpGet]
            public ActionResult<IEnumerable<Doctor>> GetDoctors()
            {
                var activeDoctors = DoctorsValidator.ActiveDoctors(_persistencia.GetDoctors());
                return Ok(activeDoctors);
            }

            //Get api/doctors/{id}
            [HttpGet("{id}")]
            public ActionResult<Doctor> GetDoctor(Guid id)
            {
                var doctor = _persistencia.GetDoctor(id);
                if (doctor == null || !doctor._isActive)
                {
                    throw new NotFoundException("");
                }
                return Ok(new
                {
                    doctor._name,
                    doctor._licenseNumber,
                    SpecialitiName = doctor._speciality?._name
                });
            }

            //Delete api/doctors/{id}
            [HttpDelete("{id}")]
            public ActionResult DeleteDoctor(Guid id)
            {
                var doctor = _persistencia.GetDoctor(id);
                if (doctor == null || !doctor._isActive)
                {
                    throw new NotFoundException("");
                }
                _persistencia.DesactivarDoctor(doctor._id);
                return NoContent();
            }
        }
}
