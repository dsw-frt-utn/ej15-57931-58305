namespace Dsw2026Ej15.Api.DTOs
{
    public record CreateDoctorDto
    {
        public record Request(string Name, string LicenceNumber, Guid SpecialityId);
        public record Response(Guid Id, string Name, string LicenceNumber, string SpecialtyName);
    }
}
