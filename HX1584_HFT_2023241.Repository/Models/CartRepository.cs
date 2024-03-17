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
    public class CartRepository : Repository<Cart>, IRepository<Cart>
    {
        public CartRepository(ShopDbContext ctx) : base(ctx)
        {
        }

        public override Cart Read(int id)
        {
            return ctx.Carts.FirstOrDefault(x => x.cart_ID == id);
        }

        public override void Update(Cart item)
        {
            var old = Read(item.cart_ID);
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
