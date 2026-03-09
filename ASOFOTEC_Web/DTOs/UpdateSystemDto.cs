namespace ASOFOTEC_Web.DTOs
{
    public class UpdateSystemDto
    {
        public int SystemID { get; set; }
        public string? SystemName { get; set; }
        public string? Description { get; set; }
        public string? DeveloperName { get; set; }
        public DateTime DateDeveloped { get; set; }
    }
}
