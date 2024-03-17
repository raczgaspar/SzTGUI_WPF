using HX1584_HFT_2023241.Logic.Logic;
using HX1584_HFT_2023241.Models;
using System.Collections.Generic;

namespace HX1584_HFT_2023241.Logic.Interface
{
    public interface IItemLogic
    {
        double? AveragePrice();
        IEnumerable<YearInfo> AveragePricePerYear();
        void Create(Item item);
        void Delete(int id);
        Item Expensive();
        string MostPopularItem();
        IEnumerable<CountryStat> ProductsPerCountries();
        Item Read(int id);
        IEnumerable<Item> ReadAll();
        void Update(Item item);
    }
}