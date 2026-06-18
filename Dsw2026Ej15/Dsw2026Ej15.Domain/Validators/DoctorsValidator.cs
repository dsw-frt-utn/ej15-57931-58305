
using Dsw2026Ej15.Domain.Entitys;
namespace Dsw2026Ej15.Domain.Validators;
public class DoctorsValidator
{
    public static List<string> ValidateNew(string name, string licenseNumber, Speciality? speciality)
    {
        List<string> errors = new List<string>();
        if (string.IsNullOrEmpty(name)) { errors.Add("Nombre Invalido"); }
        if (string.IsNullOrEmpty(licenseNumber)) { errors.Add("Numero de Licencia Invalido"); }
        if (speciality == null) { errors.Add("Especialidad Invalida"); }
        return errors;
    }

    public static List<Doctor>? ActiveDoctors(List<Doctor>? doctors)
    {
        List<Doctor> doctorsActive = [];
        if (doctors != null)
        {
            foreach (var doctor in doctors)
            {
                if (doctor._isActive) { doctorsActive.Add(doctor); }
            }
        }
        return doctorsActive;
    }
}
