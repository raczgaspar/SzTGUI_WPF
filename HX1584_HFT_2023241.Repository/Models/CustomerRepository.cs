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
    public class CustomerRepository : Repository<Customer>, IRepository<Customer>
    {
        public CustomerRepository(ShopDbContext ctx) : base(ctx)
        {
        }

        public override Customer Read(int id)
        {
            return ctx.Customers.FirstOrDefault(x => x.customer_id == id);
        }

        public override void Update(Customer item)
        {
            var old = Read(item.customer_id);
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
