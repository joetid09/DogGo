

using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Dog
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int OwnerId { get; set; }
        [Required]
        public string Breed { get; set; }
        [StringLength(250, MinimumLength = 0)]
        public string Notes { get; set; }
        public string ImageUrl { get; set; }

    }
}
