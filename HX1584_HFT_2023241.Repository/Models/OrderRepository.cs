using HX1584_HFT_2023241.Models;
using HX1584_HFT_2023241.Repository.Database;
using HX1584_HFT_2023241.Repository.General;
using HX1584_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX1584_HFT_2023241.Repository.Models
{
    public class OrderRepository : Repository<Order>, IRepository<Order>
    {
        public OrderRepository(ShopDbContext ctx) : base(ctx)
        {
        }

        public override Order Read(int id)
        {
            return ctx.Orders.FirstOrDefault(x => x.order_id == id);
        }

        public override void Update(Order item)
        {
            var old = Read(item.order_id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
