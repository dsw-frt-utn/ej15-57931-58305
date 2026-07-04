namespace Dsw2026Ej15.Api.Models
{
    public record DoctorModel
    {
        public record Request(string Name, string LicenceNumber, Guid SpecialityId);

        public record Response(Guid Id, string Name, string LicenceNumber, string SpecialtyName);
    }
}
