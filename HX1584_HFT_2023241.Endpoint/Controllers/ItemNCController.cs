using HX1584_HFT_2023241.Logic.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HX1584_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ItemNCController : ControllerBase
    {
        IItemLogic itemLogic { get; set; }

        public ItemNCController(IItemLogic itemLogic)
        {
            this.itemLogic = itemLogic;
        }

        [HttpGet]
        public string MostPopularItem()
        {
            return this.itemLogic.MostPopularItem();
        }
    }
}
