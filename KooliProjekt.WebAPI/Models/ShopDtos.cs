using System;
using System.Collections.Generic;

namespace KooliProjekt.WebAPI.Models
{
    public class ProductListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string Status { get; set; }
    }

    public class CategoryGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; }
        public decimal AveragePrice { get; set; }
    }

    public class StatusBreakdown
    {
        public string Status { get; set; }
        public int Count { get; set; }
    }

    public class ShopStats
    {
        public int ProductCount { get; set; }
        public int CategoryCount { get; set; }
        public int CustomerCount { get; set; }
        public decimal Cheapest { get; set; }
        public decimal MostExpensive { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal InventoryValue { get; set; }
        public List<StatusBreakdown> ProductsByStatus { get; set; }
    }

    public class OrderListItem
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public int LineCount { get; set; }
    }

    public class OrderLineItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
    }

    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Vat { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Amount { get; set; }
        public List<OrderLineItem> Lines { get; set; }
    }
}
