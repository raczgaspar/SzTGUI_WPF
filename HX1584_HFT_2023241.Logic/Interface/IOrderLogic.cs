using HX1584_HFT_2023241.Models;
using System.Collections.Generic;

namespace HX1584_HFT_2023241.Logic.Interface
{
    public interface IOrderLogic
    {
        void Create(Order item);
        void Delete(int id);
        double FullCost(int id);
        Order Read(int id);
        IEnumerable<Order> ReadAll();
        void Update(Order item);
    }
}