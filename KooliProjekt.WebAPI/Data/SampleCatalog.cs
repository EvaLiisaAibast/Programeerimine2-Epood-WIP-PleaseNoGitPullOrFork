using System;
using System.Collections.Generic;
using KooliProjekt.Application.Data;

namespace KooliProjekt.WebAPI.Data
{
    public static class SampleCatalog
    {
        public static readonly List<Category> Categories = new List<Category>
        {
            new Category { Id = 1, ParentCategoryId = 0, Name = "Elektroonika", Description = "Arvutid ja tarvikud" },
            new Category { Id = 2, ParentCategoryId = 0, Name = "Raamatud", Description = "IT ja kirjandus" },
            new Category { Id = 3, ParentCategoryId = 0, Name = "Riided", Description = "Igapäevane riietus" }
        };

        public static readonly List<Product> Products = new List<Product>
        {
            new Product { Id = 1, CategoryId = 1, BrandId = 1, Name = "Logitech G502 hiir", Description = "Mängurihiir", BasePrice = 39.95m, Price = 49.95m, WeightKg = 0.12m, Status = "Active", CreatedAt = new DateTime(2026, 9, 1) },
            new Product { Id = 2, CategoryId = 1, BrandId = 2, Name = "Dell U2723QE monitor", Description = "27-tolline 4K", BasePrice = 479.00m, Price = 549.00m, WeightKg = 6.4m, Status = "Active", CreatedAt = new DateTime(2026, 9, 3) },
            new Product { Id = 3, CategoryId = 1, BrandId = 3, Name = "Keychron K2 klaviatuur", Description = "Mehaaniline", BasePrice = 74.90m, Price = 89.90m, WeightKg = 0.8m, Status = "Active", CreatedAt = new DateTime(2026, 9, 5) },
            new Product { Id = 4, CategoryId = 2, BrandId = 4, Name = "ASP.NET Core Mastery", Description = "Õpik", BasePrice = 27.50m, Price = 34.50m, WeightKg = 0.6m, Status = "Active", CreatedAt = new DateTime(2026, 9, 7) },
            new Product { Id = 5, CategoryId = 2, BrandId = 4, Name = "C# ja andmebaasid", Description = "Õpik", BasePrice = 24.90m, Price = 29.90m, WeightKg = 0.5m, Status = "Active", CreatedAt = new DateTime(2026, 9, 8) },
            new Product { Id = 6, CategoryId = 3, BrandId = 5, Name = "Tallinn dressikas", Description = "Puuvillane", BasePrice = 36.00m, Price = 45.00m, WeightKg = 0.4m, Status = "Active", CreatedAt = new DateTime(2026, 9, 10) },
            new Product { Id = 7, CategoryId = 3, BrandId = 5, Name = "Tuulejakk", Description = "Veekindel", BasePrice = 72.00m, Price = 89.00m, WeightKg = 0.7m, Status = "Inactive", CreatedAt = new DateTime(2026, 9, 12) },
            new Product { Id = 8, CategoryId = 1, BrandId = 6, Name = "USB-C kaabel 2m", Description = "100W", BasePrice = 6.90m, Price = 9.90m, WeightKg = 0.1m, Status = "Active", CreatedAt = new DateTime(2026, 9, 14) }
        };

        public static readonly List<Customer> Customers = new List<Customer>
        {
            new Customer { Id = 1, Email = "eva@example.ee", PasswordHash = "x", FirstName = "Eva", LastName = "Aibast", Phone = "+3725550001", Status = "Active", CreatedAt = new DateTime(2026, 8, 1), LastLogin = new DateTime(2026, 10, 1) },
            new Customer { Id = 2, Email = "marta@example.ee", PasswordHash = "x", FirstName = "Marta", LastName = "Kask", Phone = "+3725550002", Status = "Active", CreatedAt = new DateTime(2026, 8, 15), LastLogin = new DateTime(2026, 9, 30) },
            new Customer { Id = 3, Email = "karl@example.ee", PasswordHash = "x", FirstName = "Karl", LastName = "Tamm", Phone = "+3725550003", Status = "Active", CreatedAt = new DateTime(2026, 9, 2), LastLogin = new DateTime(2026, 10, 3) }
        };

        public static readonly List<Order> Orders = new List<Order>
        {
            new Order { Id = 1, OrderNumber = 1001, CustomerId = 1, InvoiceAddressId = 1, DeliveryAddressId = 1, OrderDate = new DateTime(2026, 9, 15), PaidAt = new DateTime(2026, 9, 15), SentAt = new DateTime(2026, 9, 17), DeliveredAt = new DateTime(2026, 9, 20), Subtotal = 84.45m, Discount = 0m, Vat = 0m, ShippingCost = 4.99m, Amount = 89.44m, Status = "delivered" },
            new Order { Id = 2, OrderNumber = 1002, CustomerId = 2, InvoiceAddressId = 2, DeliveryAddressId = 2, OrderDate = new DateTime(2026, 9, 28), PaidAt = new DateTime(2026, 9, 28), Subtotal = 558.90m, Discount = 0m, Vat = 0m, ShippingCost = 0m, Amount = 558.90m, Status = "paid" },
            new Order { Id = 3, OrderNumber = 1003, CustomerId = 3, InvoiceAddressId = 3, DeliveryAddressId = 3, OrderDate = new DateTime(2026, 10, 2), Subtotal = 45.00m, Discount = 0m, Vat = 0m, ShippingCost = 4.99m, Amount = 49.99m, Status = "pending" },
            new Order { Id = 4, OrderNumber = 1004, CustomerId = 1, InvoiceAddressId = 1, DeliveryAddressId = 1, OrderDate = new DateTime(2026, 10, 5), PaidAt = new DateTime(2026, 10, 5), SentAt = new DateTime(2026, 10, 6), Subtotal = 119.80m, Discount = 10.00m, Vat = 0m, ShippingCost = 4.99m, Amount = 114.79m, Status = "shipped" }
        };

        public static readonly List<OrderLine> OrderLines = new List<OrderLine>
        {
            new OrderLine { Id = 1, OrderId = 1, VariantId = 1, ProductId = 1, ProductName = "Logitech G502 hiir", VariantCode = "G502-BLK", Quantity = 1, UnitPrice = 49.95m, Discount = 0m, Amount = 49.95m },
            new OrderLine { Id = 2, OrderId = 1, VariantId = 4, ProductId = 4, ProductName = "ASP.NET Core Mastery", VariantCode = "ACM-1", Quantity = 1, UnitPrice = 34.50m, Discount = 0m, Amount = 34.50m },
            new OrderLine { Id = 3, OrderId = 2, VariantId = 2, ProductId = 2, ProductName = "Dell U2723QE monitor", VariantCode = "U2723-4K", Quantity = 1, UnitPrice = 549.00m, Discount = 0m, Amount = 549.00m },
            new OrderLine { Id = 4, OrderId = 2, VariantId = 8, ProductId = 8, ProductName = "USB-C kaabel 2m", VariantCode = "USBC-2M", Quantity = 1, UnitPrice = 9.90m, Discount = 0m, Amount = 9.90m },
            new OrderLine { Id = 5, OrderId = 3, VariantId = 6, ProductId = 6, ProductName = "Tallinn dressikas", VariantCode = "TLN-M", Quantity = 1, UnitPrice = 45.00m, Discount = 0m, Amount = 45.00m },
            new OrderLine { Id = 6, OrderId = 4, VariantId = 3, ProductId = 3, ProductName = "Keychron K2 klaviatuur", VariantCode = "K2-RGB", Quantity = 1, UnitPrice = 89.90m, Discount = 5.00m, Amount = 84.90m },
            new OrderLine { Id = 7, OrderId = 4, VariantId = 5, ProductId = 5, ProductName = "C# ja andmebaasid", VariantCode = "CSD-1", Quantity = 1, UnitPrice = 29.90m, Discount = 5.00m, Amount = 24.90m }
        };
    }
}
