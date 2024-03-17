using HX1584_HFT_2023241.Logic.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HX1584_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrderNCController : ControllerBase
    {
        IOrderLogic orderLogic { get; set; }

        public OrderNCController(IOrderLogic orderLogic)
        {
            this.orderLogic = orderLogic;
        }

        [HttpGet("{id}")]
        public double OrderFullCost(int id)
        {
            return this.orderLogic.FullCost(id);
        }

    }
}
