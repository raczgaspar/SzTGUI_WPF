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
    public class ItemLogic : IItemLogic
    {
        IRepository<Item> repo;

        public ItemLogic(IRepository<Item> repo)
        {
            this.repo = repo;
        }

        public void Create(Item item)
        {
            if (item.price < 0)
            {
                throw new ArgumentException("Price have to be a positive number!");
            }
            if (item.productName == null || item.productName == "")
            {
                throw new ArgumentException("Product's name is invalid!");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            var item = repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException("Item not exists!");
            }
            repo.Delete(id);
        }

        public Item Read(int id)
        {
            var item = repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException("Item not exists!");
            }
            return item;
        }

        public IEnumerable<Item> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Item item)
        {
            if (item.price < 0)
            {
                throw new ArgumentException("Price have to be a positive number!");
            }
            if (item.productName == null || item.productName == "")
            {
                throw new ArgumentException("Product's name is invalid!");
            };
            if (item.year_of_man < 2018 || item.year_of_man > 2023)
            {
                throw new ArgumentException("Invalid year of manufacture!");
            }
            repo.Update(item);
        }

        public Item Expensive()
        {
            var max = repo.ReadAll().Max(x => x.price);
            return repo.ReadAll().Where(x => x.price == max).First();
        }

        public double? AveragePrice()
        {
            return repo
               .ReadAll()
               .Average(t => t.price);
        }


        public IEnumerable<YearInfo> AveragePricePerYear()
        {
            return from x in repo.ReadAll()
                   group x by x.year_of_man into g
                   select new YearInfo()
                   {
                       Year = g.Key,
                       Price = g.Average(t => t.price),
                       Products = g.Count()
                   };
        }

        public IEnumerable<CountryStat> ProductsPerCountries()
        {
            return from x in repo.ReadAll()
                   group x by x.fabr_country into g
                   select new CountryStat()
                   {
                       Country = g.Key,
                       Count = g.Count()
                   };
        }

        public string MostPopularItem()
        {
            var items = repo.ReadAll();
            var max = items.Max(x => x.Order.Count);
            var pop = items.Where(x => x.Order.Count == max).First();
            return pop.productName;
        }


    }
    public class YearInfo
    {
        public int Year { get; set; }
        public double? Price { get; set; }
        public int Products { get; set; }

        public override bool Equals(object obj)
        {
            YearInfo b = obj as YearInfo;
            if (b == null)
            {
                return false;
            }
            else
            {
                return Year == b.Year
                    && Price == b.Price
                    && Products == b.Products;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Year, Price, Products);
        }
    }
    public class CountryStat
    {
        public string Country { get; set; }
        public int Count { get; set; }

        public override bool Equals(object obj)
        {
            CountryStat b = obj as CountryStat;
            if (b == null)
            {
                return false;
            }
            else
            {
                return Country == b.Country
                    && Count == b.Count;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Country, Count);
        }
    }
}
