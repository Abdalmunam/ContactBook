using System.ComponentModel.DataAnnotations;

namespace ContactBook.Api.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        [StringLength(100)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
