using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Walker
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Let the world know your name!")]
        [MaxLength(35)]
        public string Name { get; set; }
        [Required(ErrorMessage ="What part of town do you work in?")]
        public int NeighborhoodId { get; set; }
        public string ImageUrl { get; set; }
        public Neighborhood Neighborhood { get; set; }
    }
}
