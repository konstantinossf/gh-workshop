using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Favorites
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // Navigation property for many-to-many relationship with Movie
        public List<Movie> Movies { get; set; } = new List<Movie>();

        // Navigation property for owner (single MovieUser)
    [Required]
    [ForeignKey("Owner")]
    public int MovieUserId { get; set; }
    public MovieUser Owner { get; set; }
    }
// Checklist (x for done, - for not done):
// - [x] Create class structure
// - [x] Implement navigation properties if needed
// - [x] Add data annotations for validation
}
// Checklist (x for done, - for not done):
// - [x] Create class structure
// - [x] Implement navigation properties if needed
// - [x] Add data annotations for validation
