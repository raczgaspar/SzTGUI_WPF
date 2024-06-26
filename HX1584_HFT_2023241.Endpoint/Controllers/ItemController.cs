﻿using HX1584_HFT_2023241.Endpoint.Services;
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
    public class ItemController : ControllerBase
    {

        IItemLogic logic;
        IHubContext<SignalRHub> hub;

        public ItemController(IItemLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Item> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Item Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Item value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("ItemCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Item value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("ItemUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleteItem = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("ItemDeleted", deleteItem);
        }
    }
}
