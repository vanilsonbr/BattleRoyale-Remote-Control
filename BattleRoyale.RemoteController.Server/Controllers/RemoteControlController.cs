using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BatteRoyale.RemoteController.Server.Services;
using BatteRoyale.RemoteController.Server.Services.Interface;
using BattleRoyale.RemoteController.Server.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BattleRoyale.RemoteController.Server.Controllers
{
    [Route("api/[controller]")]
    public class RemoteControlController : Controller
    {
        //private readonly IRemoteControlService _service;
        private readonly IRemoteControlService _service;

        public RemoteControlController(IRemoteControlService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public IEnumerable<Client> ConnectedClients()
        {
            var connectedClients = _service.ConnectedClients();
            return connectedClients;
        }

        [HttpGet("[action]")]
        public Client GetClient(string ipAddress)
        {
            var client = _service.GetClient(ipAddress);
            return client;
        }

        [HttpPost("[action]")]
        public void AddClient([FromBody] Client client)
        {
            _service.OnClientConnected(client);
        }
    }
}
