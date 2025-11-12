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

        // Navigation property for many-to-one relationship with MovieUser
        [Required]
        public int MovieUserId { get; set; }
        public MovieUser MovieUser { get; set; }

        // Navigation property for many-to-one relationship with Movie
        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
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
