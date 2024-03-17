using HX1584_HFT_2023241.Logic.Logic;
using HX1584_HFT_2023241.Models;
using HX1584_HFT_2023241.Repository.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX1584_HFT_2023241.Test
{
    [TestFixture]
    public class ItemLogicTester
    {
        ItemLogic logic;
        Mock<IRepository<Item>> mockRepo;

        [SetUp]
        public void Init()
        {
            mockRepo = new Mock<IRepository<Item>>();
            mockRepo.Setup(m => m.ReadAll()).Returns(new List<Item>()
            {
                new Item(555, "Dunakavics", 600, 2023, "Hungary"),
                new Item(655, "Betonkeverő", 20000, 2013, "Germany"),
                new Item(755, "Kása", 300, 2023, "Hungary"),
                new Item(855, "Babkonzerv", 400, 2020, "Hungary"),
                new Item(955, "Mikrométer", 10000, 2020, "Japán"),
                new Item(355, "Teleszkóp", 15000, 2013, "Japán"),
                new Item(255, "Nagyító", 15000, 2010, "Japán")

            }.AsQueryable());
            logic = new ItemLogic(mockRepo.Object);
        }

        [Test]
        public void AveragePricePerYearTest()
        {
            var actual = logic.AveragePricePerYear().ToList();
            var expected = new List<YearInfo>()
            {
                new YearInfo()
                {
                    Year = 2023,
                    Price = 450,
                    Products = 2
                },
                new YearInfo()
                {
                    Year = 2013,
                    Price = 17500,
                    Products= 2
                },
                new YearInfo()
                {
                    Year = 2020,
                    Price = 5200,
                    Products = 2
                },
                new YearInfo()
                {
                    Year = 2010,
                    Price = 15000,
                    Products = 1
                }
            };

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ProductsPerCountries()
        {
            var actual = logic.ProductsPerCountries().ToList();
            var expected = new List<CountryStat>()
            {
                new CountryStat()
                {
                    Country = "Hungary",
                    Count = 3
                },
                new CountryStat()
                {
                    Country = "Germany",
                    Count = 1
                },
                new CountryStat()
                {
                    Country = "Japán",
                    Count = 3
                }
                
            };

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CreateItemCorrect()
        {
            var item = new Item(1, "Kapa", 1500, 2000, "Hungary");

            logic.Create(item);

            mockRepo.Verify(x => x.Create(item), Times.Once);
        }
        [Test]
        public void CreateItemIncorrectPrice()
        {
            var item = new Item(1, "Kapa", -1500, 2000, "Hungary");
            try
            {
                logic.Create(item);
            }
            catch
            {
            }

            mockRepo.Verify(x => x.Create(item), Times.Never);

        }
    }
}
