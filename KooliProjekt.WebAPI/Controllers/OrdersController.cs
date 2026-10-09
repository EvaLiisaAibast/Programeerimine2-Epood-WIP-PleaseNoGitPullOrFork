using System;
using System.Collections.Generic;
using System.Linq;
using KooliProjekt.Application.Data;
using KooliProjekt.WebAPI.Data;
using KooliProjekt.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class OrdersController : ApiControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<OrderListItem>> GetOrders(string status = null)
        {
            IEnumerable<Order> query = SampleCatalog.Orders;

            if (!string.IsNullOrWhiteSpace(status))
            {
                query = query.Where(x => x.Status == status);
            }

            var result =
                from o in query.OrderByDescending(x => x.OrderDate)
                join c in SampleCatalog.Customers on o.CustomerId equals c.Id
                select new OrderListItem
                {
                    Id = o.Id,
                    OrderNumber = o.OrderNumber,
                    CustomerName = c.FirstName + " " + c.LastName,
                    OrderDate = o.OrderDate,
                    Status = o.Status,
                    Amount = o.Amount,
                    LineCount = SampleCatalog.OrderLines.Count(l => l.OrderId == o.Id)
                };

            return Ok(result.ToList());
        }

        [HttpGet("{id:int}")]
        public ActionResult<OrderDetail> GetOrder(int id)
        {
            var order = SampleCatalog.Orders.FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            var customer = SampleCatalog.Customers.FirstOrDefault(c => c.Id == order.CustomerId);

            var detail = new OrderDetail
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                CustomerName = customer == null ? "" : customer.FirstName + " " + customer.LastName,
                OrderDate = order.OrderDate,
                Status = order.Status,
                Subtotal = order.Subtotal,
                Discount = order.Discount,
                Vat = order.Vat,
                ShippingCost = order.ShippingCost,
                Amount = order.Amount,
                Lines = SampleCatalog.OrderLines
                    .Where(l => l.OrderId == order.Id)
                    .Select(l => new OrderLineItem
                    {
                        ProductName = l.ProductName,
                        Quantity = l.Quantity,
                        UnitPrice = l.UnitPrice,
                        Amount = l.Amount
                    })
                    .ToList()
            };

            return Ok(detail);
        }
    }
}
