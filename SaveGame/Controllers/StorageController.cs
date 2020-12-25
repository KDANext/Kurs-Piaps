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
    public class StorageController : ControllerBase
    {
        private readonly StorageLogic storageLogic;

        public StorageController(StorageLogic storageLogic)
        {
            this.storageLogic = storageLogic;
        }
        [HttpPost]
        public void Save(ModelSave modelSave)
        {
            storageLogic.Save(modelSave);
        }
        [HttpGet]
        public ModelSave Load(int userId)
        {
            return storageLogic.Load(userId);
        }
    }
}
