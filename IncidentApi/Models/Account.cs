using System.ComponentModel.DataAnnotations;

namespace IncidentApi.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string? Name { get; set; }
        // One-to-many relationship with contacts
        [Required]
        public ICollection<Contact>? Contacts { get; set; }
    }
}
