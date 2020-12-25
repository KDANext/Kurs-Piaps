using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseImplement.Models
{
    public class Person
    {
        public int? Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string ClassName { get; set; }
        [Required]
        public int ManaMax { get; set; }
        [Required]
        public int Mana { get; set; }
        [Required]
        public int Health { get; set; }
        [Required]
        public int Armor { get; set; }
        [Required]
        public int Damage { get; set; }
        public virtual User User { get; set; }
        public virtual List<ItemUser> ItemUsers { get; set; }
    }
}
