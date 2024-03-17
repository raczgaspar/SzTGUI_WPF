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
    internal class MixedTests
    {
        ItemLogic itemLogic;
        CustomerLogic customerLogic;
        OrderLogic orderLogic;
        CartLogic cartLogic;
        Mock<IRepository<Item>> itemRepo;
        Mock<IRepository<Customer>> customerRepo;
        Mock<IRepository<Order>> orderRepo;
        Mock<IRepository<Cart>> cartRepo;

        [SetUp]
        public void Init()
        {
            itemRepo = new Mock<IRepository<Item>>();
            itemRepo.Setup(m => m.ReadAll()).Returns(new List<Item>()
            {
                new Item()
                {
                    item_id = 555,
                    productName = "Dunakavics",
                    price = 600,
                    year_of_man = 2023,
                    fabr_country = "Hungary",
                    Order = new List<Order>()
                    {
                        new Order(),
                        new Order(),
                        new Order(),
                    }
                },
                new Item()
                {
                    item_id = 655,
                    productName = "Betonkeverő",
                    price = 20000,
                    year_of_man = 2013,
                    fabr_country = "Germany",
                    Order = new List<Order>()
                    {
                        new Order(),

                    }
                },
                new Item()
                {
                    item_id = 755,
                    productName = "Kása",
                    price = 300,
                    year_of_man = 2023,
                    fabr_country = "Hungary",
                    Order = new List<Order>()
                    {
                        new Order(),
                        new Order(),
                        new Order(),
                    }

                },
                new Item()
                {
                    item_id = 855,
                    productName = "Babkonzerv",
                    price = 400,
                    year_of_man = 2020,
                    fabr_country = "Hungary",
                    Order = new List<Order>()
                    {
                        new Order(),
                        new Order(),

                    }

                },
                new Item()
                {
                    item_id = 955,
                    productName = "Mikrométer",
                    price = 10000,
                    year_of_man = 2020,
                    fabr_country = "China",
                    Order = new List<Order>()
                    {
                    }

                },
                new Item()
                {
                    item_id = 355,
                    productName = "Teleszkóp",
                    price = 15000,
                    year_of_man = 2013,
                    fabr_country = "China",
                    Order = new List<Order>()
                    {
                        new Order(),

                    }

                },
                new Item()
                {
                    item_id = 255,
                    productName = "Nagyító",
                    price = 15000,
                    year_of_man = 2010,
                    fabr_country = "China",
                    Order = new List<Order>()
                    {
                        new Order(),
                        new Order(),
                        new Order(),
                        new Order(),
                        new Order(),
                    }

                }

            }.AsQueryable());
            itemLogic = new ItemLogic(itemRepo.Object);



            customerRepo = new Mock<IRepository<Customer>>();
            customerRepo.Setup(m => m.ReadAll()).Returns(new List<Customer>()
            {
                new Customer()
                {
                    customer_id = 1,
                    cart_id= 1,
                    name = "Sebestyén Balázs",
                    phone = 707355868,
                    city = "Budapest",
                    year = 40,
                    Cart = new Cart()
                            {
                                cart_ID= 1,
                                comment = "",
                                delivered = true,
                                priority = 1,
                                Orders= new List<Order>()
                                {
                                    new Order
                                        {
                                            order_id= 1001,
                                            item_id= 555,
                                            cart_id= 1,
                                            amount= 1,
                                            Item = new Item()
                                                {
                                                    item_id = 555,
                                                    productName = "Dunakavics",
                                                    price = 600,
                                                    year_of_man = 2023,
                                                    fabr_country = "Hungary",
                                                    Order = new List<Order>()
                                                    {
                                                        new Order(),
                                                        new Order(),
                                                        new Order(),
                                                    }
                                                },

                                        },
                                }
                            }
                },
                new Customer()
                {
                    customer_id = 2,
                    cart_id= 2,
                    name = "Kerekes Áron",
                    phone = 707321068,
                    city = "Pákozd",
                    year = 22,
                    Cart = 
                            new Cart()
                        {
                            cart_ID= 2,
                            comment = "SOS",
                            delivered = false,
                            priority = 3,
                            Orders= new List<Order>()
                            {
                                new Order
                                    {
                                        order_id= 1002,
                                        item_id= 755,
                                        cart_id= 2,
                                        amount= 1,
                                        Item = new Item()
                                            {
                                                item_id = 755,
                                                productName = "Kása",
                                                price = 300,
                                                year_of_man = 2023,
                                                fabr_country = "Hungary",
                                                Order = new List<Order>()
                                                {
                                                    new Order(),
                                                    new Order(),
                                                    new Order(),
                                                }

                                            },

                                    },
                            }
                        }
                },
                new Customer()
                {
                    customer_id = 3,
                    cart_id= 3,
                    name = "Kovács Eszter",
                    phone = 207355123,
                    city = "Ózd",
                    year = 21,
                    Cart = new Cart()
                        {
                            cart_ID= 3,
                            comment = "",
                            delivered = true,
                            priority = 2,
                            Orders = new List<Order>()
                            {
                                new Order
                                    {
                                        order_id= 1004,
                                        item_id= 655,
                                        cart_id= 3,
                                        amount= 1,
                                        Item =
                                        new Item()
                                            {
                                                item_id = 655,
                                                productName = "Betonkeverő",
                                                price = 20000,
                                                year_of_man = 2013,
                                                fabr_country = "Germany",
                                                Order = new List<Order>()
                                                {
                                                    new Order(),

                                                }
                                            },
                                    },
                            }

                        }
                },
                new Customer()
                {
                    customer_id = 4,
                    cart_id= 4,
                    name = "Huszák Milán",
                    phone = 307355800,
                    city = "Budapest",
                    year = 30,
                    Cart = new Cart()
                            {
                            cart_ID= 4,
                            comment = "First order",
                            delivered = true,
                            priority = 3,
                            Orders = new List<Order>()
                            {
                                new Order
                                    {
                                        order_id= 1005,
                                        item_id= 755,
                                        cart_id= 4,
                                        amount= 3,
                                        Item = new Item()
                                        {
                                            item_id= 1,
                                            productName = "Kasza",
                                            price = 600,
                                            fabr_country = "Germany"

                                        }
                                    }
                            }
                            }
                },
                new Customer()
                {
                    customer_id = 5,
                    cart_id= 5,
                    name = "Tihon Tamás",
                    phone = 207487561,
                    city = "Pákozd",
                    year = 11,
                    Cart = new Cart()
                        {
                            cart_ID= 5,
                            comment = "",
                            delivered = false,
                            priority = 2,
                            Orders = new List<Order>()
                            {
                                new Order
                                    {
                                        order_id= 1006,
                                        item_id= 355,
                                        cart_id= 5,
                                        amount= 2,
                                        Item =
                                        new Item()
                                            {
                                                item_id = 355,
                                                productName = "Teleszkóp",
                                                price = 15000,
                                                year_of_man = 2013,
                                                fabr_country = "China",
                                                Order = new List<Order>()
                                                {
                                                    new Order(),
                                                }
                                            },
                                    },
                            }
                        }
                },
                new Customer()
                {
                    customer_id = 6,
                    cart_id= 6,
                    name = "Kovács Martin",
                    phone = 707565485,
                    city = "Pákozd",
                    year = 21,
                    Cart = new Cart()
                        {
                            cart_ID= 6,
                            comment = "",
                            delivered = true,
                            priority = 2,
                            Orders = new List<Order>()
                            {
                                new Order
                                {
                                    order_id= 1007,
                                    item_id= 955,
                                    cart_id= 6,
                                    amount= 1,
                                    Item =
                                    new Item()
                                        {
                                            item_id = 955,
                                            productName = "Mikrométer",
                                            price = 10000,
                                            year_of_man = 2020,
                                            fabr_country = "China",
                                            Order = new List<Order>()
                                            {
                                            }
                                        },
                                },
                            }
                        }
                }

            }.AsQueryable());
            customerLogic = new CustomerLogic(customerRepo.Object);



            cartRepo = new Mock<IRepository<Cart>>();
            cartRepo.Setup(m => m.ReadAll()).Returns(new List<Cart>()
            {
                new Cart()
                {
                    cart_ID= 1,
                    comment = "",
                    delivered = true,
                    priority = 1,
                    Orders= new List<Order>()
                    {
                        new Order
                        {
                            order_id= 1001,
                            item_id= 555,
                            cart_id= 1,
                            amount= 1,

                        },
                    }
                },
                new Cart()
                {
                    cart_ID= 2,
                    comment = "SOS",
                    delivered = false,
                    priority = 3,
                    Orders= new List<Order>()
                    {
                        new Order
                        {
                            order_id= 1002,
                            item_id= 755,
                            cart_id= 2,
                            amount= 1,

                        },
                    }
                },
                new Cart()
                {
                    cart_ID= 3,
                    comment = "",
                    delivered = true,
                    priority = 2,
                    Orders= new List<Order>()
                    {
                        new Order
                        {
                            order_id= 1004,
                            item_id= 655,
                            cart_id= 3,
                            amount= 1,
                        },
                    }
                    
                },
                new Cart()
                {
                    cart_ID= 4,
                    comment = "First order",
                    delivered = true,
                    priority = 3,
                    Orders= new List<Order>()
                    {
                        new Order
                        {
                            order_id= 1005,
                            item_id= 755,
                            cart_id= 4,
                            amount= 3,
                        },
                    }
                    
                },
                new Cart()
                {
                    cart_ID= 5,
                    comment = "",
                    delivered = false,
                    priority = 2,
                    Orders= new List<Order>()
                    {
                        new Order
                    {
                        order_id= 1006,
                        item_id= 355,
                        cart_id= 5,
                        amount= 2,
                    },
                    }
                    
                },
                new Cart()
                {
                    cart_ID= 6,
                    comment = "",
                    delivered = true,
                    priority = 2,
                    Orders= new List<Order>()
                    {
                       new Order
                    {
                        order_id= 1007,
                        item_id= 955,
                        cart_id= 6,
                        amount= 1,
                    }
                    }
                    
                }
            }.AsQueryable()) ;
            cartLogic = new CartLogic(cartRepo.Object);



            orderRepo = new Mock<IRepository<Order>>();
            orderRepo.Setup(m => m.ReadAll()).Returns(new List<Order>()
            {
                new Order
                {
                    order_id= 1001,
                    item_id= 555,
                    cart_id= 1,
                    amount= 1,
                    Item = new Item()
                        {
                            item_id = 555,
                            productName = "Dunakavics",
                            price = 600,
                            year_of_man = 2023,
                            fabr_country = "Hungary",
                            Order = new List<Order>()
                            {
                                new Order(),
                                new Order(),
                                new Order(),
                            }
                        },

                },
                new Order
                {
                    order_id= 1002,
                    item_id= 755,
                    cart_id= 2,
                    amount= 1,
                    Item = new Item()
                        {
                            item_id = 755,
                            productName = "Kása",
                            price = 300,
                            year_of_man = 2023,
                            fabr_country = "Hungary",
                            Order = new List<Order>()
                            {
                                new Order(),
                                new Order(),
                                new Order(),
                            }

                        },

                },
                new Order
                {
                    order_id= 1003,
                    item_id= 555,
                    cart_id= 2,
                    amount= 1,

                },
                new Order
                {
                    order_id= 1004,
                    item_id= 655,
                    cart_id= 3,
                    amount= 1,
                    Item =
                    new Item()
                        {
                            item_id = 655,
                            productName = "Betonkeverő",
                            price = 20000,
                            year_of_man = 2013,
                            fabr_country = "Germany",
                            Order = new List<Order>()
                            {
                                new Order(),

                            }
                        },


                },
                new Order
                {
                    order_id= 1005,
                    item_id= 755,
                    cart_id= 4,
                    amount= 3,
                    Item = new Item()
                    {
                        item_id= 1,
                        productName = "Kasza",
                        price = 600,
                        fabr_country = "Germany"

                    }
                },
                new Order
                {
                    order_id= 1006,
                    item_id= 355,
                    cart_id= 5,
                    amount= 2,
                    Item =
                    new Item()
                        {
                            item_id = 355,
                            productName = "Teleszkóp",
                            price = 15000,
                            year_of_man = 2013,
                            fabr_country = "China",
                            Order = new List<Order>()
                            {
                                new Order(),
                            }
                        },
                },
                new Order
                {
                    order_id= 1007,
                    item_id= 955,
                    cart_id= 6,
                    amount= 1,
                    Item =
                    new Item()
                        {
                            item_id = 955,
                            productName = "Mikrométer",
                            price = 10000,
                            year_of_man = 2020,
                            fabr_country = "China",
                            Order = new List<Order>()
                            {
                            }

                        },

                },
                new Order
                {
                    order_id= 1008,
                    item_id= 255,
                    cart_id= 1,
                    amount= 1,

                },
                new Order
                {
                    order_id= 1009,
                    item_id= 855,
                    cart_id= 3,
                    amount= 2,

                },
                new Order
                {
                    order_id= 1010,
                    item_id= 455,
                    cart_id= 5,
                    amount= 5,
                    

                },



            }.AsQueryable());
            orderLogic = new OrderLogic(orderRepo.Object);

            
        }

        [Test]
        public void FullCostTest()
        {
            var actual = orderLogic.FullCost(1005);
            double expected = 1800;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MostPopularItem()
        {
            string expected = "Nagyító";
            var actual = itemLogic.MostPopularItem();


            Assert.AreEqual(actual,expected);
        }

        [Test]
        public void CustomerWithCommentTest()
        {
            var expected = new List<Customer>()
            {
                new Customer()
                {
                    customer_id = 2,
                    cart_id= 2,
                    name = "Kerekes Áron",
                    phone = 707321068,
                    city = "Pákozd",
                    year = 22,
                    Cart =
                            new Cart()
                        {
                            cart_ID= 2,
                            comment = "SOS",
                            delivered = false,
                            priority = 3,
                        }
                },
                new Customer()
                {

                    customer_id = 4,
                    cart_id= 4,
                    name = "Huszák Milán",
                    phone = 307355800,
                    city = "Budapest",
                    year = 30,
                    Cart = new Cart()
                            {
                            cart_ID= 4,
                            comment = "First order",
                            delivered = true,
                            priority = 3,

                            }
                }
                
            };
            var actual = customerLogic.CustomerWithComment();

            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void MultipleSameTest()
        {
            var actual = cartLogic.MultipleSame().ToList();
            var expected = new List<Cart>()
            {
                new Cart()
                {
                    cart_ID= 4,
                    comment = "First order",
                    delivered = true,
                    priority = 3,
                    Orders= new List<Order>()
                    {
                        new Order
                        {
                            order_id= 1005,
                            item_id= 755,
                            cart_id= 4,
                            amount= 3,
                        },
                    }

                },

                new Cart()
                {
                    cart_ID= 5,
                    comment = "",
                    delivered = false,
                    priority = 2,
                    Orders= new List<Order>()
                    {
                        new Order
                    {
                        order_id= 1006,
                        item_id= 355,
                        cart_id= 5,
                        amount= 2,
                    },
                    }

                }

            };

            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void OrderFromChinaTest()
        {
            var actual = customerLogic.OrderFromChina().ToList();
            var expected = new List<Customer>()
            {
                new Customer()
                {
                    customer_id = 5,
                    cart_id= 5,
                    name = "Tihon Tamás",
                    phone = 207487561,
                    city = "Pákozd",
                    year = 11,
                    Cart = new Cart()
                        {
                            cart_ID= 5,
                            comment = "",
                            delivered = false,
                            priority = 2,

                        }
                },

                new Customer()
                {
                    customer_id = 6,
                    cart_id= 6,
                    name = "Kovács Martin",
                    phone = 707565485,
                    city = "Pákozd",
                    year = 21,
                    Cart = new Cart()
                        {
                            cart_ID= 6,
                            comment = "",
                            delivered = true,
                            priority = 2,

                        }
                }

            };

            Assert.AreEqual(expected,actual);
        }
    }
}
