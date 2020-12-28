using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseImplement.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Nickname { get; set; }
        public int LocationId { get; set; }
        public virtual List<Person> Persons { get; set; }
        public virtual List<ItemUser> ItemsUser { get; set; }
    }
}
