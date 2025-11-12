using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace backend.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public ICollection<Movie> Movies { get; set; }
    }
}
