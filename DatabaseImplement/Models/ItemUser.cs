using System.ComponentModel.DataAnnotations;

namespace DatabaseImplement.Models
{
    public class ItemUser
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int ItemCount { get; set; }
        public virtual User User { get; set; }
    }
}
