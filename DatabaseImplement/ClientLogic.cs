using DatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DatabaseImplement
{
    public class ClientLogic
    {
        private string Sold = "Sold";
        public void Register(User model)
        {
            using (var context = new Database())
            {
                try
                {
                    Encrypt(model);
                    User user = new User();
                    user.Login = model.Login;
                    user.Password = model.Password;
                    user.Nickname = model.Nickname;
                } catch
                {
                    ExeptionController.ExeptionController.CrushSaveExeption();
                }                  
            }
        }

        public User Login(User model)
        {
            using (var context = new Database())
            {
                Encrypt(model);
                var element = context.Users.First(x => x.Login == model.Login && x.Password == model.Password);
                if (element == null)
                {
                    ExeptionController.ExeptionController.UncorrectCheckUserExeption();
                }
                return element;
            }
        }

        private void Encrypt(User model)
        {
            model.Login = GetHash(model.Login);
            model.Password = GetHash(model.Password);
        }
        private string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input+Sold));
            return Convert.ToBase64String(hash);
        }
    }
}
