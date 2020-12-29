using DatabaseImplement.Models;
using System.Collections.Generic;

namespace DatabaseImplement
{
    public class ModelSave
    {
        public User User{ get; set; }
        public List<Person> Persons { get; set; }
        public List<List<ItemPerson>> InventoryPersons { get; set; }
        public List<ItemUser> InventoryUsers { get; set; }

        public ModelSave()
        {
            User = new User();
            Persons = new List<Person>();
            InventoryPersons = new List<List<ItemPerson>>();
            InventoryUsers = new List<ItemUser>();
        }
    }
}
