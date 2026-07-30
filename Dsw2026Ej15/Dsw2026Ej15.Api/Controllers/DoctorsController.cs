using Dsw2026Ej15.Api.DTOs;
using Dsw2026Ej15.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;
using Dsw2026Ej15.Domain.Interfaz;
using Dsw2026Ej15.Domain.Exceptions;
using Dsw2026Ej15.Api.Models;
using System.ComponentModel.DataAnnotations;


namespace Dsw2026Ej15.Api.Controllers
{
    [ApiController]
    [Route("api/doctors")]

    public class DoctorsController : ControllerBase
    {

        private readonly IPersistence _persistencia;


        public DoctorsController(IPersistence persistencia)

        {

            _persistencia = persistencia;

        }

        [HttpPost]

        public async Task<IActionResult> CreateDoctor(DoctorModel.Request request)

        {

            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.LicenceNumber))

            {

                throw new ValidationException("Nombre y Matricula son requeridos");

            }


            var speciality = _persistencia.GetSpeciality(request.SpecialityId);


            if (speciality is null)

            {

                throw new ValidationException("Especialidad no Existe");

            }


            var doctor = new Doctor(request.Name, request.LicenceNumber, speciality);


            _persistencia.AñadirDoctor(doctor);


            return Created();


        }


        [HttpGet]

        public async Task<IActionResult> GetDoctors()

        {

            List<DoctorModel.Response> doctors = _persistencia.GetDoctors()

                .Select(d => new DoctorModel.Response(

                    d._id,

                    d._name,

                    d._licenseNumber,

                    d._speciality._name)

                ).ToList();


            return Ok(doctors);

        }



        [HttpGet("{id}")]

        public async Task<IActionResult> GetDoctor(Guid id)

        {

            var doctor = _persistencia.GetDoctor(id);


            if (doctor == null || !doctor._isActive)


                throw new ValidationException("Medico inexistente o inactivo");


            return Ok(new
            {

                doctor._name,

                doctor._licenseNumber,

                SpecialityName = doctor._speciality._name

            });

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDoctor(Guid id)

        {

            var doctor = _persistencia.GetDoctor(id);


            if (doctor == null || !doctor._isActive)

                throw new ValidationException("Medico inexistente o inactivo");


            doctor._isActive = false;


            return NoContent();

        }

    }
}
