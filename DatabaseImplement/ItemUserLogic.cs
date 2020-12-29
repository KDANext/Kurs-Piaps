using DatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement
{
    public class ItemUserLogic
    {
        public void Create(ItemUser model)
        {
            using (var context = new Database())
            {
                try
                {
                    var elem = new ItemUser();
                    context.ItemsUser.Add(elem);
                    elem.ItemCount = model.ItemCount;
                    elem.ItemId = model.ItemId;
                    elem.UserId = model.UserId;
                    context.SaveChanges();
                }
                catch
                {
                    ExeptionController.ExeptionController.CrushSaveExeption();
                }
            }
        }

        public void Delete(ItemUser model)
        {
            using (var context = new Database())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.ItemsUser.FirstOrDefault(x => x.Id == model.Id);
                        if (element != null)
                        {
                            context.ItemsUser.Remove(element);
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

        public List<ItemUser> Read(int userId)
        {
            using (var context = new Database())
            {
                return context.ItemsUser.Where(x => x.UserId == userId).ToList();
            }
        }
    }
}
