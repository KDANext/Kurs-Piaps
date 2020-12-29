using DatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement
{
    public class PersonLogic
    {
        public void CreateOrUpdate(Person model)
        {
            using (var context = new Database())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Person elem = context.Persons.FirstOrDefault(rec => rec.Id != model.Id);
                        if (model.Id.HasValue && model.Id != 0)
                        {
                            elem = context.Persons.FirstOrDefault(rec => rec.Id == model.Id);
                            if (elem == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            elem = new Person();
                            context.Persons.Add(elem);
                        }
                        elem.Armor = model.Armor;
                        elem.ClassName = model.ClassName;
                        elem.Damage = model.Damage;
                        elem.UserId = model.UserId;
                        elem.Health = model.Health;
                        elem.Mana = model.Mana;
                        elem.ManaMax = model.ManaMax;                      
                        context.SaveChanges();
                        transaction.Commit();
                        model.Id = elem.Id;
                    }
                    catch
                    {
                        ExeptionController.ExeptionController.CrushSaveExeption();
                    }
                }
            }
        }

        public void Read(ModelSave model)
        {
            using (var context = new Database())
            {
                model.Persons = context.Persons.Where(x => x.UserId == model.User.Id).ToList();
            }
        }
    }
}
