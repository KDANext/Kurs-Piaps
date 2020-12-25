using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseImplement
{
    public class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=ITShopDatebase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<ItemUser> ItemsUser { get; set; }
        public virtual DbSet<ItemPerson> ItemPersons{ get; set; }
    }
}
