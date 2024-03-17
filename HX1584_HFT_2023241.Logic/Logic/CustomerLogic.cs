using HX1584_HFT_2023241.Logic.Interface;
using HX1584_HFT_2023241.Models;
using HX1584_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HX1584_HFT_2023241.Logic.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        IRepository<Customer> repo;

        public CustomerLogic(IRepository<Customer> repo)
        {
            this.repo = repo;
        }

        public void Create(Customer item)
        {
            if (item.name == null || item.name == "")
            {
                throw new ArgumentException("Name is empty...");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            var cust = repo.Read(id);
            if (cust == null)
            {
                throw new ArgumentException("Customer not exists!");
            }
            repo.Delete(id);
        }

        public Customer Read(int id)
        {
            var cust = repo.Read(id);
            if (cust == null)
            {
                throw new ArgumentException("Customer not exists!");
            }
            return cust;
        }

        public IEnumerable<Customer> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Customer item)
        {
            if (item.name == null || item.name == "")
            {
                throw new ArgumentException("Name is empty...");
            }
            repo.Update(item);
        }

        public IEnumerable<Customer> CustomerWithComment()
        {
            var custs = repo.ReadAll();
            return custs.Where(x => x.Cart.comment != "");
        }

        public IEnumerable<Customer> OrderFromChina()
        {
            var ctx = repo.ReadAll();
            return ctx.Where(x => x.Cart.Orders.Where(x => x.Item.fabr_country == "China").Any());
        }

        public IEnumerable<CityInfo> CityStats()
        {
            return from x in repo.ReadAll()
                   group x by x.city into g
                   select new CityInfo()
                   {
                       City = g.Key,
                       count = g.Count()
                   };
        }

        public IEnumerable<CityYear> AvgYerPerCity()
        {
            return from x in repo.ReadAll()
                   group x by x.city into g
                   select new CityYear()
                   {
                       City = g.Key,
                       avgYear = g.Average(x => x.year)
                   };
        }
    }

    public class CityInfo
    {
        public string City { get; set; }
        public int count { get; set; }

        public override bool Equals(object obj)
        {
            CityInfo b = obj as CityInfo;
            if (b == null)
            {
                return false;
            }
            else
            {
                return City == b.City
                    && count == b.count;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(City, count);
        }
    }

    public class CityYear
    {
        public string City { get; set; }
        public double avgYear { get; set; }

        public override bool Equals(object obj)
        {
            CityYear b = obj as CityYear;
            if (b == null)
            {
                return false;
            }
            else
            {
                return City == b.City
                    && avgYear == b.avgYear;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(City, avgYear);
        }
    }
}
