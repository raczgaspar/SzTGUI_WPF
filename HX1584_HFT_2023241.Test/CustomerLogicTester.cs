using HX1584_HFT_2023241.Models;
using NUnit.Framework;
using System;
using System.Linq;
using Moq;
using System.Collections.Generic;
using HX1584_HFT_2023241.Logic.Logic;
using HX1584_HFT_2023241.Repository.Interface;

namespace HX1584_HFT_2023241.Test
{
    [TestFixture]
    public class CustomerLogicTester
    {
        CustomerLogic logic;
        Mock<IRepository<Customer>> mockRepo;

        [SetUp]
        public void Init()
        {
            mockRepo = new Mock<IRepository<Customer>>();
            mockRepo.Setup(m => m.ReadAll()).Returns(new List<Customer>()
            {
                new Customer (1, 1, "Sebestyén Balázs", 707355868, "Budapest", 40),
                new Customer (2, 2, "Kerekes Áron", 707321068, "Pákozd", 22),
                new Customer (3, 3, "Kovács Eszter", 207355123, "Ózd", 21),
                new Customer (4, 4, "Huszák Milán", 307355800, "Budapest", 30),
                new Customer (5, 5, "Tihon Tamás", 207487561, "Pákozd", 11)

            }.AsQueryable());
            logic = new CustomerLogic(mockRepo.Object);
        }

        [Test]
        public void CityStatsTest()
        {
            var actual = logic.CityStats().ToList();
            var expected = new List<CityInfo>()
            {
                new CityInfo()
                {
                    City = "Budapest",
                    count = 2
                },
                new CityInfo()
                {
                    City = "Pákozd",
                    count = 2
                },
                new CityInfo()
                {
                    City = "Ózd",
                    count = 1
                }
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CityYearTest()
        {
            var actual = logic.AvgYerPerCity().ToList();
            var expected = new List<CityYear>()
            {
                new CityYear()
                {
                    City = "Budapest",
                    avgYear = 35
                },
                new CityYear()
                {
                    City = "Pákozd",
                    avgYear = 16.5
                },
                new CityYear()
                {
                    City = "Ózd",
                    avgYear = 21
                }
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void CreateCustomerCorrect()
        {
            var cust = new Customer(1, 1, "Kiss Abel", 707558845, "Labatlan", 20);

            logic.Create(cust);

            mockRepo.Verify(x => x.Create(cust), Times.Once);
            
        }
        [Test]
        public void CreateCustomerIncorrectName()
        {
            var cust = new Customer(1, 1, "", 707558845, "Labatlan", 20);
            try
            {
                logic.Create(cust);
            }
            catch
            {
            }

            mockRepo.Verify(x => x.Create(cust), Times.Never);

        }
    }
}
