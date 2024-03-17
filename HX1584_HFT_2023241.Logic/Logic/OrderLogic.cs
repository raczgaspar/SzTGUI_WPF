using HX1584_HFT_2023241.Logic.Interface;
using HX1584_HFT_2023241.Models;
using HX1584_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX1584_HFT_2023241.Logic.Logic
{
    public class OrderLogic : IOrderLogic
    {
        IRepository<Order> repo;

        public OrderLogic(IRepository<Order> repo)
        {
            this.repo = repo;
        }

        public void Create(Order item)
        {
            if (item.amount < 0)
            {
                throw new ArgumentException("Amount must be higher than 0!");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            var order = repo.Read(id);
            if (order == null)
            {
                throw new ArgumentException("Order not exists");
            }
            repo.Delete(id);
        }

        public Order Read(int id)
        {
            var order = repo.Read(id);
            if (order == null)
            {
                throw new ArgumentException("Order not exists");
            }
            return order;
        }

        public IEnumerable<Order> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Order item)
        {
            if (item.amount < 0)
            {
                throw new ArgumentException("Amount must be higher than 0!");
            }
            repo.Update(item);
        }

        public double FullCost(int id)
        {
            var order = repo.ReadAll().Where(x => x.order_id == id).First();
            return order.Item.price * order.amount;
        }






    }
}
