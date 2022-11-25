using System.ComponentModel.DataAnnotations;

namespace MvcCrud.Models
{
    public class Unit
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}