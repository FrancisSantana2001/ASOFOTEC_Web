namespace ASOFOTEC_Web.DTOs
{
    public class InsertUsersDto
    {
        public string Id_Card { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Last_Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Age { get; set; }
        public string Phone { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Adress { get; set; } = null!;
    }
}
