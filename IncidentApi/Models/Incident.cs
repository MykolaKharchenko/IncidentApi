using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentApi.Models
{
    public class Incident
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key ] public string? NameId { get; set; }
        public string? Description { get; set; }


        // One-to-many relationship with accounts
        [Required]
        public ICollection<Account>? Accounts { get; set; }
    }
}
