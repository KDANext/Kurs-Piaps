using DatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement
{
    public class ItemPersonLogic
    {
        public void Create(ItemPerson model)
        {
            using (var context = new Database())
            {
                    try
                    {
                        var elem = new ItemPerson();
                        context.ItemPersons.Add(elem);
                        elem.ItemCount = model.ItemCount;
                        elem.ItemId = model.ItemId;
                        elem.PersonId = model.PersonId;
                        context.SaveChanges();
                    } catch
                    {
                        ExeptionController.ExeptionController.CrushSaveExeption();
                    }
            }
        }

        public void Delete(ItemPerson model)
        {
            using (var context = new Database())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.ItemPersons.FirstOrDefault(x => x.Id == model.Id);
                        if(element != null)
                        {
                            context.ItemPersons.Remove(element);
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        ExeptionController.ExeptionController.CrushSaveExeption();
                    }
                }
            }
        }

        public List<ItemPerson> Read(int idPerson)
        {
            using (var context = new Database())
            {
                return context.ItemPersons.Where(x => x.PersonId == idPerson).ToList();
            }
        }
    }
}
