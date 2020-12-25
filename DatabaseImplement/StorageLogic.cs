using DatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement
{
    public class StorageLogic
    {
        private readonly PersonLogic personLogic = new PersonLogic();
        private readonly ItemPersonLogic itemPersonLogic = new ItemPersonLogic();
        private readonly ItemUserLogic itemUserLogic = new ItemUserLogic();
        public void Save(ModelSave model)
        {
            using (var context = new Database())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var itemPerson = model.InventoryPersons.GetEnumerator();
                        foreach (var person in model.Persons)
                        {
                            itemPerson.MoveNext();
                            personLogic.CreateOrUpdate(person);
                            SaveItem(person, itemPerson.Current);
                        }
                        var element = context.Users.First(x=> x.Id == model.User.Id);
                        element.LocationId = model.User.LocationId;
                        transaction.Commit();
                        context.SaveChanges();
                    } 
                    catch
                    {
                        ExeptionController.ExeptionController.CrushSaveExeption();
                        transaction.Rollback();
                    }
                }
            }
        }
        private void SaveItemUser(int userId, List<ItemUser> inventoryUsers)
        {
            using (var context = new Database())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var oldItems = itemUserLogic.Read(userId);
                        foreach (var item in oldItems)
                        {
                            itemUserLogic.Delete(item);
                        }
                        for (int i = 0; i < inventoryUsers.Count; i++)
                        {
                            inventoryUsers[i].UserId = userId;
                            itemUserLogic.Create(inventoryUsers[i]);
                        }
                        transaction.Commit();
                        context.SaveChanges();
                    }
                    catch
                    {
                        ExeptionController.ExeptionController.CrushSaveExeption();
                        transaction.Rollback();
                    }
                }
            }
        }
        private void SaveItem(Person person, List<ItemPerson> items)
        {
            using (var context = new Database())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var oldItems = itemPersonLogic.Read(person.Id.Value);
                        foreach(var item in oldItems)
                        {
                            itemPersonLogic.Delete(item);
                        }
                        for (int i = 0; i < items.Count; i++)
                        {
                            items[i].PersonId = person.Id.Value;
                            itemPersonLogic.Create(items[i]);
                        }
                        transaction.Commit();
                        context.SaveChanges();
                    } catch
                    {
                        ExeptionController.ExeptionController.CrushSaveExeption();
                        transaction.Rollback();
                    }
                }
            }
        }
        public ModelSave Load(int userId)
        {
            ModelSave model = new ModelSave();
            model.InventoryUsers = itemUserLogic.Read(model.User.Id);
            personLogic.Read(model);
            foreach(var person in model.Persons)
            {
                model.InventoryPersons.Add(itemPersonLogic.Read(person.Id.Value));
            }
            return model;
        }
    }
}
