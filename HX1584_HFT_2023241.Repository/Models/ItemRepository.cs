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
    public class ItemRepository : Repository<Item>, IRepository<Item>
    {
        public ItemRepository(ShopDbContext ctx) : base(ctx)
        {
        }

        public override Item Read(int id)
        {
            return ctx.Items.FirstOrDefault(x => x.item_id == id);
        }

        public override void Update(Item item)
        {
            var old = Read(item.item_id);
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
