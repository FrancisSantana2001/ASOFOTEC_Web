using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASOFOTEC_Web.Models
{
    public class ModelUser
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Id_Card { get; set; } = null!;
        [Display(Name ="Nombre")]
        public string Name { get; set; }= null!;
        [Display(Name="Apellido")]
        public string Last_Name { get; set; }= null!;
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }= null!;
        [Display(Name ="Edad")]
        public int Age { get; set; }
        [Display(Name = "Telefono")]
        public string Phone { get; set; }= null!;
        [Display(Name = "Pais")]
        public string Country { get; set; }= null!;
        [Display(Name = "Dirección-residencia")]
        public string Adress { get; set; }= null!;

    }
}
