using HX1584_HFT_2023241.Logic.Logic;
using HX1584_HFT_2023241.Models;
using System.Collections.Generic;

namespace HX1584_HFT_2023241.Logic.Interface
{
    public interface ICustomerLogic
    {
        IEnumerable<CityYear> AvgYerPerCity();
        IEnumerable<CityInfo> CityStats();
        void Create(Customer item);
        IEnumerable<Customer> CustomerWithComment();
        void Delete(int id);
        IEnumerable<Customer> OrderFromChina();
        Customer Read(int id);
        IEnumerable<Customer> ReadAll();
        void Update(Customer item);
    }
}