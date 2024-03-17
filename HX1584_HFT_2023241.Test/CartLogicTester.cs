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
    public class CartLogicTester
    {
        CartLogic logic;
        Mock<IRepository<Cart>> mockRepo;

        [SetUp]
        public void Init()
        {
            mockRepo = new Mock<IRepository<Cart>>();
            mockRepo.Setup(m => m.ReadAll()).Returns(new List<Cart>()
            {
                new Cart(1, "", true, 1),
                new Cart(2, "SOS", false, 3),
                new Cart(3, "", true, 2),
                new Cart(4, "First order", true, 3),
                new Cart(5, "", false, 2),
                new Cart(6, "", true, 2)
            }.AsQueryable());
            logic = new CartLogic(mockRepo.Object);
        }

        /*[Test]
        public void PriorityRateTest()
        {
            var actual = logic.PriorityRate();
            var expected = new List<Priorities>()
            {
                new Priorities()
                {
                    prio= 1,
                    rate= 1100,
                },
                new Priorities()
                {
                    prio= 3,
                    rate= 1/2d*100,
                },
                new Priorities()
                {
                    prio= 2,
                    rate= 2/3d*100,
                }
                
            };
            Assert.AreEqual(expected, actual);
        }*/

        [Test]
        public void CreateCartCorrect()
        {
            var item = new Cart (1, "", true, 2);

            logic.Create(item);

            mockRepo.Verify(x => x.Create(item), Times.Once);
        }

        [Test]
        public void CreateCartIncorrectPrio()
        {
            var item = new Cart(1, "", true, -2);
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
