using System.ComponentModel.DataAnnotations;

namespace DatabaseImplement.Models
{
    public class ItemPerson
    {
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int ItemCount { get; set; }
        public virtual Person Person { get; set; }
    }
}
