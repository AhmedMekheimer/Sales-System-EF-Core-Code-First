using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using P02_SalesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_SalesDatabase.Data
{
    class SalesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseSqlServer("Data Source=.;Integrated Security=True;Connect Timeout=30;Trust Server Certificate=True; Initial Catalog=Sales System")
                .ConfigureWarnings(warnings =>
                    warnings.Throw(RelationalEventId.PendingModelChangesWarning));
            ;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sale>().Property(t => t.Date).HasDefaultValueSql("GETDATE()");
/*
            //                     -------------   BONUS Seeding Task   -------------
            Random random = new Random();
            //String Id Random generation method
            string RandomId(int length)
            {
                const string chars = "ABC0123456789";
                StringBuilder sb = new StringBuilder(length);

                for (int i = 0; i < length; i++)
                {
                    sb.Append(chars[random.Next(chars.Length)]);
                }

                return sb.ToString();
            }

            //Product's table Random Generation
            var products = new List<Product>();
            var ProductNames = new[] { "Milk", "Egg", "زبادي فراولة", "كيس مناديل", "Chocolate" };
            for (int i = 0; i <= 10; i++)
            {
                string id = RandomId(10);
                products.Add(new Product
                {
                    ProductId = id,
                    Name = ProductNames[random.Next(ProductNames.Length)]+id,
                    Quantity = random.Next(50),
                    Price = 10 + (random.NextDouble() * (90)),
                    Description = "Description for " + ProductNames[random.Next(ProductNames.Length)] + " Product"
                }
                    );
            }
            modelBuilder.Entity<Product>().HasData(products);

            //Customers' table 
            var customers = new List<Customer>();
            var CustomerNames = new[] { "Ahmed", "Ali", "محمد", "يوسف" };
            for (int i = 0; i <= 10; i++)
            {
                string id = RandomId(10);
                string name = CustomerNames[random.Next(CustomerNames.Length)];
                customers.Add(new Customer
                {
                    CustomerId = id,
                    Name = name,
                    Email=$"{id}_{name}@account",
                    CreditCardNumber= RandomId(10)
                }
                    );
            }
            modelBuilder.Entity<Customer>().HasData(customers);

            //Stores' table 
            var stores = new List<Store>();
            var StoreNames = new[] {"البقّال","Green Market","أولاد رجب","Target Market"};
            for(int i=0;i<10;i++)
            {
                string id = RandomId(10);
                stores.Add(new Store
                {
                    StoreId = id,
                    Name = StoreNames[random.Next(StoreNames.Length)]+id
                }
                    );
            }
            modelBuilder.Entity<Store>().HasData(stores);

            //Sales' Table
            var startDate = new DateOnly(2025, 1, 1);
            var sales = new List<Sale>();
            for(int i=0;i<50;i++)
            {
                var customer = customers[random.Next(customers.Count)];
                var store = stores[random.Next(stores.Count)];
                sales.Add(new Sale
                {
                    SaleId = RandomId(5),
                    Date = startDate,
                    CustomerId = customer.CustomerId,
                    StoreId = store.StoreId
                }
                    );
            }


            // 'ProductSale' Bridge table data seeding
            var productSales = new List<object>();
            var random2 = new Random();

            foreach (var sale in sales)
            {
                var productCount = random2.Next(1, 4); // 1-3 products per sale
                var selectedProducts = products
                    .OrderBy(p => random2.Next())       //shuffling the products orders
                    .Take(productCount);                //Take a random num of products from Top

                foreach (var product in selectedProducts)
                {
                    productSales.Add(new { ProductsProductId = product.ProductId, 
                        SalesSaleId = sale.SaleId});
                }
            }
            
            modelBuilder.Entity<Sale>()
                .HasMany(s => s.Products)
                .WithMany(p => p.Sales)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductSale",
                    j => j.HasData(productSales.ToArray())
                );*/
        }
    }
}
