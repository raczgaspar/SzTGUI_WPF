using ConsoleTools;
using HX1584_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;

namespace HX1584_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Item")
            {
                Console.WriteLine("Enter item's name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter item's price: ");
                int price = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter year (2018-2023): ");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter country: ");
                string country = Console.ReadLine();
                rest.Post(new Item()
                {
                    productName = name,
                    price = price,
                    year_of_man = year,
                    fabr_country = country
                }, "Item");
            }
            else if (entity == "Customer")
            {
                Console.WriteLine("Enter name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter phone number: ");
                int phone = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the city: ");
                string city = Console.ReadLine();
                Console.WriteLine("Enter the age: ");
                int age = int.Parse(Console.ReadLine());
                rest.Post(new Customer
                {
                    name = name,
                    phone = phone,
                    city = city,
                    year = age
                }, "Customer");
            }
            else if (entity == "Order")
            {
                Console.WriteLine("Enter the item's ID");
                int item = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the amount");
                int amount = int.Parse(Console.ReadLine());
                rest.Post(new Order()
                {
                    item_id = item,
                    amount = amount
                }, "Order");
            }
            else
            {
                Console.WriteLine("Enter the comment: ");
                string comment = Console.ReadLine();
                Console.WriteLine("Enter the priority: ");
                int prio = int.Parse(Console.ReadLine());
                rest.Post(new Cart()
                {
                    comment = comment,
                    priority = prio,
                    delivered = false
                }, "Cart");
            }
            Console.WriteLine("Done! Press any button...");
            Console.ReadKey();

        }
        static void List(string entity)
        {

            if (entity == "Item")
            {
                List<Item> items = rest.Get<Item>("Item");
                foreach (var item in items)
                {
                    Console.WriteLine("Item ID: " + item.item_id + "\tName: " + item.productName + "\tPrice: " + item.price + "\tYear: " + item.year_of_man);
                }
                Console.WriteLine("Done! Press any button...");
            }
            else if (entity == "Customer")
            {
                List<Customer> custs = rest.Get<Customer>("Customer");
                foreach (var item in custs)
                {
                    Console.WriteLine("Customer ID: " + item.customer_id + "\tName: " + item.name + "\tAge: " + item.year + "\tCity: " + item.city + "\tPhone: " + item.phone);
                }
                Console.WriteLine("Done! Press any button...");
            }
            else if (entity == "Order")
            {
                List<Order> orders = rest.Get<Order>("Order");
                foreach (var item in orders)
                {
                    Console.WriteLine("Order ID: " + item.order_id + "\tItem ID: " + item.item_id + "\tAmount:" + item.amount);
                }
                Console.WriteLine("Done! Press any button...");
            }
            else
            {
                List<Cart> carts = rest.Get<Cart>("Cart");
                foreach (var item in carts)
                {
                    Console.WriteLine("Cart ID: " + item.cart_ID + "\tComment: " + item.comment + "\tDelivered: " + item.delivered);
                }
                Console.WriteLine("Done! Press any button...");
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Item")
            {
                Console.WriteLine("Enter item's ID: ");
                int id = int.Parse(Console.ReadLine());
                Item a = rest.Get<Item>(id, "Item");
                Console.WriteLine($"New name [Old: {a.productName}]: ");
                string name = Console.ReadLine();
                a.productName = name;
                Console.WriteLine($"New price [Old: {a.price}]: ");
                int price = int.Parse(Console.ReadLine());
                a.price = price;
                rest.Put(a, "Item");
                Console.WriteLine("Done! Press any button...");
            }

            else if (entity == "Customer")
            {
                Console.WriteLine("Enter customer's ID: ");
                int id = int.Parse(Console.ReadLine());
                Customer a = rest.Get<Customer>(id, "Customer");
                Console.WriteLine($"New name [Old: {a.name}]: ");
                string name = Console.ReadLine();
                a.name = name;
                Console.WriteLine($"New age [Old: {a.year}]: ");
                int age = int.Parse(Console.ReadLine());
                a.year = age;
                Console.WriteLine($"New city [Old: {a.city}]: ");
                string city = Console.ReadLine();
                a.city = city;
                Console.WriteLine($"New phone [Old: {a.phone}]: ");
                int phone = int.Parse(Console.ReadLine());
                a.phone = phone;
                rest.Put(a, "Customer");
                Console.WriteLine("Done! Press any button...");
            }
            else if (entity == "Order")
            {
                Console.WriteLine("Enter order's ID: ");
                int id = int.Parse(Console.ReadLine());
                Order a = rest.Get<Order>(id, "Order");
                Console.WriteLine($"New amount [Old: {a.amount}]: ");
                int am = int.Parse(Console.ReadLine());
                a.amount = am;
                rest.Put(a, "Order");
                Console.WriteLine("Done! Press any button...");
            }
            else
            {
                Console.WriteLine("Enter cart's ID: ");
                int id = int.Parse(Console.ReadLine());
                Cart a = rest.Get<Cart>(id, "Cart");
                Console.WriteLine($"New comment [Old: {a.comment}]: ");
                string comm = Console.ReadLine();
                a.comment = comm;
                Console.WriteLine($"New delivery status [Old: {a.delivered}] 0 - False, 1 - True: ");
                int status = int.Parse(Console.ReadLine());
                a.delivered = status > 0 ? a.delivered = true : a.delivered = false;
                Console.WriteLine($"New priority 1-3 [Old: {a.priority}]: ");
                int prio = int.Parse(Console.ReadLine());
                a.priority = prio;
                rest.Put(a, "Cart");
                Console.WriteLine("Done! Press any button...");
            }
            Console.ReadKey();

        }
        static void Delete(string entity)
        {
            if (entity == "Item")
            {
                Console.WriteLine("Enter the ID to delet: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Item");
                Console.WriteLine("Done! Press any button...");
            }
            else if (entity == "Customer")
            {
                Console.WriteLine("Enter customer ID: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Customer");
                Console.WriteLine("Done! Press any button...");
            }
            else if (entity == "Order")
            {
                Console.WriteLine("Enter order ID: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Order");
                Console.WriteLine("Done! Press any button...");
            }
            else
            {
                Console.WriteLine("Enter cart ID: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Cart");
                Console.WriteLine("Done! Press any button...");
            }
            Console.ReadKey();
        }
        static void FullCost()
        {
            Console.WriteLine("Order ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Order's full pirce: " + rest.GetSingle<double>($"/OrderNC/OrderFullCost/{id}"));
            Console.WriteLine("Done! Press any button...");
            Console.ReadKey();
        }
        static void MostPopular()
        {
            Console.WriteLine("Most popular item: " + rest.GetSingle<string>("/ItemNC/MostPopularItem"));
            Console.WriteLine("Done! Press any button...");
            Console.ReadKey();
        }
        static void CustomerComment()
        {
            var cust = rest.Get<Customer>("/CustNC/CustomersWithComment");
            foreach (var item in cust)
            {
                Console.WriteLine(item.name + ": " + item.Cart.comment);
            }
            Console.WriteLine("Done! Press any button...");
            Console.ReadKey();
        }
        static void MultipleItem()
        {
            var carts = rest.Get<Cart>("/CartNC/MultipleSame");
            foreach (var item in carts)
            {
                foreach (var orders in item.Orders)
                {
                    if (orders.amount > 1)
                    {
                        Console.WriteLine("Cart ID: " + item.cart_ID + "\tItem name: " + orders.Item.productName + "\tAmount: " + orders.amount);
                    }
                }

            }
            Console.WriteLine("Done! Press any button...");
            Console.ReadKey();
        }
        static void OrderFromChina()
        {
            var cust = rest.Get<Customer>("/CustNC/OrderFromChina");
            foreach (var item in cust)
            {
                Console.WriteLine(item.customer_id + ": " + item.name);
            }
            Console.WriteLine("Done! Press any button...");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:64867/", "Item");

            var itemSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Item"))
                .Add("Create", () => Create("Item"))
                .Add("Delete", () => Delete("Item"))
                .Add("Update", () => Update("Item"))
                .Add("Exit", ConsoleMenu.Close);

            var customerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Customer"))
                .Add("Create", () => Create("Customer"))
                .Add("Delete", () => Delete("Customer"))
                .Add("Update", () => Update("Customer"))
                .Add("Exit", ConsoleMenu.Close);

            var orderSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Order"))
                .Add("Create", () => Create("Order"))
                .Add("Delete", () => Delete("Order"))
                .Add("Update", () => Update("Order"))
                .Add("Exit", ConsoleMenu.Close);

            var cartSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Cart"))
                .Add("Create", () => Create("Cart"))
                .Add("Delete", () => Delete("Cart"))
                .Add("Update", () => Update("Cart"))
                .Add("Exit", ConsoleMenu.Close);
            var ncSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Full cost", () => FullCost())
                .Add("Popular item", () => MostPopular())
                .Add("Customers with comment", () => CustomerComment())
                .Add("Multiple item", () => MultipleItem())
                .Add("Order from China", () => OrderFromChina())
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Items", () => itemSubMenu.Show())
                .Add("Customers", () => customerSubMenu.Show())
                .Add("Orders", () => orderSubMenu.Show())
                .Add("Carts", () => cartSubMenu.Show())
                .Add("Non-CRUD", () => ncSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
