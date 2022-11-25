using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcCrud.Models
{
    public partial class User
    {
        public User()
        {
            Units = new HashSet<Unit>();
        }

        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Login Name")]
        public string LoginName { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
    }
}