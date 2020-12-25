using DatabaseImplement;
using DatabaseImplement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaveGame.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientLogic clientLogic;

        public ClientController(ClientLogic clientLogic)
        {
            this.clientLogic = clientLogic;
        }
        [HttpGet]
        public User Login(string login, string password) => clientLogic.Login(new DatabaseImplement.Models.User()
        {
            Login = login,
            Password = password
        });
        [HttpPost]
        public void Register(User model)
        {
            clientLogic.Register(model);
        }
    }
}
