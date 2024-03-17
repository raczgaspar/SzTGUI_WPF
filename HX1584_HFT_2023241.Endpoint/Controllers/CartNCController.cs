using HX1584_HFT_2023241.Logic.Interface;
using HX1584_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HX1584_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CartNCController : ControllerBase
    {
        ICartLogic cartLogic { get; set; }

        public CartNCController(ICartLogic cartLogic)
        {
            this.cartLogic = cartLogic;
        }

        [HttpGet]
        public IEnumerable<Cart> MultipleSame()
        {
            return this.cartLogic.MultipleSame();
        }
    }
}
