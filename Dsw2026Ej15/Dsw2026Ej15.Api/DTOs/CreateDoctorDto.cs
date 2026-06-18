namespace Dsw2026Ej15.Api.DTOs
{
    public class CreateDoctorDto
    {
        public string _name { get; set; } = string.Empty;
        public string _licenseNumber { get; set; } = string.Empty;
        public Guid _specialityId { get; set; }
        public bool _isActive { get; set; } = true;

    }
}
