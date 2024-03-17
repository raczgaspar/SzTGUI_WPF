using HX1584_HFT_2023241.Endpoint.Services;
using HX1584_HFT_2023241.Logic.Interface;
using HX1584_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HX1584_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ICartLogic logic;
        IHubContext<SignalRHub> hub;

        public CartController(ICartLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Cart> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Cart Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Cart value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("CartCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Cart value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("CartUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleteCart = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("CartDeleted", deleteCart);
        }
    }
}
