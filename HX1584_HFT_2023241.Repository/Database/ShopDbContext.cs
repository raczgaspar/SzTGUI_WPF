using HX1584_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Numerics;


namespace HX1584_HFT_2023241.Repository.Database
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Cart> Carts { get; set; }


        public ShopDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                   .UseInMemoryDatabase("shop")
                   .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>()
                 .HasOne(x => x.Cart)
                 .WithMany(x => x.Orders)
                 .HasForeignKey(x => x.cart_id)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(a => a.Item)
                .WithMany(b => b.Order)
                .HasForeignKey(b => b.item_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>()
                .HasOne(x => x.Cart)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.cart_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cart>().HasData(new Cart[]
            {
                new Cart(1, "", true, 3),
                new Cart(2, "", true,3),
                new Cart(3, "Első rendelés", false, 3),
                new Cart(4, "", true, 1),
                new Cart(5, "", false, 1),
                new Cart(6, "Sürgős szállítás", true, 3),
                new Cart(7, "", false, 2),
                new Cart(8, "", false, 1),
                new Cart(9, "Extra felszerelésekkel", true, 2),
                new Cart(10, "", false, 3),
                new Cart(11, "", true, 1),
                new Cart(12, "SOS", true, 2),
                new Cart(13, "", false, 3),
                new Cart(14, "Készlethiány", true, 1),
                new Cart(15, "", true, 2),
                new Cart(16, "Hosszabb szállítási idő", true, 2),
                new Cart(17, "", false, 3),
                new Cart(18, "", true, 3),
                new Cart(19, "", false, 1),
                new Cart(20, "", false, 2),
            });


            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer(74,1, "Eszter Fehér", 703994632, "Debrecen", 25),
                new Customer(41,2, "Bence Kovács", 203524789, "Szeged", 26),
                new Customer(90,3, "Réka Nagy", 702345621, "Nyíregyháza", 19),
                new Customer(18,4, "Tamás Simon", 303872615, "Budapest", 21),
                new Customer(55,5, "Emese Szabó", 303249876, "Szombathely", 22),
                new Customer(6,6, "Gergő Tóth", 702897354, "Győr", 26),
                new Customer(32,7, "Petra Pataki", 703489621, "Miskolc", 24),
                new Customer(83,8, "Dóra Molnár", 203487965, "Debrecen", 20),
                new Customer(99,9, "Bálint Varga", 703569842, "Pécs", 25),
                new Customer(61,10, "Ádám Oláh", 303487659, "Székesfehérvár", 22),
                new Customer(15,11, "Erika Horváth", 702134589, "Szeged", 18),
                new Customer(48,12, "Judit Kovács", 203987651, "Budapest", 29),
                new Customer(20,13, "Nóra Kovács", 203147856, "Győr", 28),
                new Customer(85,14, "Ferenc Fekete", 702345178, "Nyíregyháza", 26),
                new Customer(67,15, "Márton Takács", 703485621, "Budapest", 18),
                new Customer(29,16, "Áron Balázs", 203485179, "Debrecen", 30),
                new Customer(12,17, "Petra Varga", 303875621, "Szombathely", 26),
                new Customer(94,18, "Réka Simon", 702345189, "Pécs", 24),
                new Customer(7,19, "Gergő Kovács", 703985612, "Miskolc", 22),
                new Customer(59,20, "Eszter Tóth", 203785946, "Székesfehérvár", 27)
            });

            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                new Order(123056, 7777,1,1),
                new Order(123006, 2910,1,2),
                new Order(451148, 3658,2,1),
                new Order(451884, 3658,3,2),
                new Order(865148, 5487,4,1),
                new Order(856248, 5782,5,2),
                new Order(325596, 4671,5,1),
                new Order(325506, 6215,5,1),
                new Order(775848, 1010,6,1),
                new Order(225848, 8888,7,1),
                new Order(899898, 7777,8,1),
                new Order(365847, 4765,9,3),
                new Order(365848, 8888,9,1),
                new Order(366658, 8873,10,1),
                new Order(366622, 2896,11,1),
                new Order(106622, 3210,12,1),
                new Order(102522, 2967,13,1),
                new Order(102523, 9330,13,1),
                new Order(446426, 5149,14,1),
                new Order(655482, 1984,15,1),
                new Order(695592, 7531,16,1),
                new Order(225592, 8657,17,2),
                new Order(650000, 2967,18,2),
                new Order(111111, 7531,19,1),
                new Order(111112, 7777,20,5),
            });

            modelBuilder.Entity<Item>().HasData(new Item[]
            {
                new Item(8657, "Számítógép", 200000, 2022, "China"),
                new Item(2910, "Mobiltelefon", 125000, 2020, "USA"),
                new Item(7531, "Webkamera", 100000,2018, "Japan"),
                new Item(1984, "Füles", 24000, 2022, "China"),
                new Item(6215, "Egér", 4000, 2022, "USA"),
                new Item(8873, "Billentyűzet", 2500, 2023, "China"),
                new Item(3658, "Monitor", 60000, 2020, "Japan"),
                new Item(5149, "Laptop", 180000, 2018, "Germany"),
                new Item(5782, "Tablet", 80000, 2019, "USA"),
                new Item(9330, "Hangszóró", 30000, 2023, "China"),
                new Item(2896, "TV", 110000, 2019, "Japan"),
                new Item(4765, "Nyomtató", 30000, 2020, "Germany"),
                new Item(3210, "Videókamera", 160000, 2021, "China"),
                new Item(8888, "Projektor", 70000, 2022, "USA"),
                new Item(5487, "Robotporszívó", 140000, 2018, "China"),
                new Item(2967, "Okosóra", 60000, 2023, "Japan"),
                new Item(1010, "Router", 35000, 2021, "China"),
                new Item(4671, "Ebook olvasó", 20000, 2019, "USA"),
                new Item(7777, "Gamer szék", 65000, 2018, "China"),

            });




        }
    }

}
