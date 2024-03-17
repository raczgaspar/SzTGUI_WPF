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
    public class CartLogic : ICartLogic
    {
        IRepository<Cart> repo;

        public CartLogic(IRepository<Cart> repo)
        {
            this.repo = repo;
        }

        public void Create(Cart item)
        {
            if (item.priority < 1 || item.priority > 3)
            {
                throw new ArgumentException("Priority has to be between 1-3!");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            var cart = repo.Read(id);
            if (cart == null)
            {
                throw new ArgumentException("Cart not exists!");
            }
            repo.Delete(id);
        }

        public Cart Read(int id)
        {
            var cart = repo.Read(id);
            if (cart == null)
            {
                throw new ArgumentException("Cart not exists!");
            }
            return cart;
        }

        public IEnumerable<Cart> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Cart item)
        {
            if (item.priority < 1 || item.priority > 3)
            {
                throw new ArgumentException("Priority has to be between 1-3!");
            }
            repo.Update(item);
        }

        public IEnumerable<Cart> CommentsByStatus(bool status)
        {
            var q = repo.ReadAll().Where(x => x.delivered == status);
            return q;
        }

        /*public IEnumerable<Priorities> PriorityRate()
         {
             return from x in this.repo.ReadAll()
                    group x by x.priority into g
                    select new Priorities()
                    {
                        prio = g.Key,
                        rate = (g.Count(x => x.delivered == true) / g.Count())*100

                    };


         }*/

        public IEnumerable<Cart> MultipleSame()
        {
            var ctx = repo.ReadAll();
            return ctx.Where(x => x.Orders.Where(x => x.amount > 1).Any());
        }
    }

    public class Priorities
    {
        public int prio { get; set; }
        public double rate { get; set; }
    }
}
