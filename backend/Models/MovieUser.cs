using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class MovieUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Navigation property for many-to-many relationship with Movie
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
// Checklist (x for done, - for not done):
// - [x] Create class structure
// - [x] Implement navigation properties if needed
// - [x] Add data annotations for validation
