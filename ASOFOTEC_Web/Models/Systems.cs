using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASOFOTEC_Web.Models
{
    public class Systems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SystemID { get; set; }
        public string? SystemName { get; set; }
        public string? Description { get; set; }
        public string? DeveloperName { get; set; }
        public DateTime DateDeveloped { get; set; }

    }
}
