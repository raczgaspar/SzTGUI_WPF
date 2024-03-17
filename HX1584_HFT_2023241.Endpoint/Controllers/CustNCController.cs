using HX1584_HFT_2023241.Logic.Interface;
using HX1584_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HX1584_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustNCController : ControllerBase
    {
        ICustomerLogic customerLogic { get; set; }

        public CustNCController(ICustomerLogic customerLogic)
        {
            this.customerLogic = customerLogic;
        }

        [HttpGet]
        public IEnumerable<Customer> CustomersWithComment()
        {
            return this.customerLogic.CustomerWithComment();
        }

        [HttpGet]
        public IEnumerable<Customer> OrderFromChina()
        {
            return this.customerLogic.OrderFromChina();
        }
    }
}
