using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    public ICollection<MovieUser> WatchedByUsers { get; set; }
    // Navigation property for many-to-many relationship with MovieUser via Favorites
    public ICollection<Favorites> Favorites { get; set; }
    }
}
