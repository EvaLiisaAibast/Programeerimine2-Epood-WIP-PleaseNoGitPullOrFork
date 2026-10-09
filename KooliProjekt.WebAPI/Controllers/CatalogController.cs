using System;
using System.Collections.Generic;
using System.Linq;
using KooliProjekt.Application.Data;
using KooliProjekt.WebAPI.Data;
using KooliProjekt.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class CatalogController : ApiControllerBase
    {
        [HttpGet("products")]
        public ActionResult<IEnumerable<ProductListItem>> GetProducts(string search = null, int? categoryId = null, string sort = null, int? page = null, int? pageSize = null)
        {
            IEnumerable<Product> query = SampleCatalog.Products;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            if (sort == "price_desc")
            {
                query = query.OrderByDescending(p => p.Price);
            }
            else if (sort == "price_asc")
            {
                query = query.OrderBy(p => p.Price);
            }
            else
            {
                query = query.OrderBy(p => p.Name);
            }

            if (page.HasValue && pageSize.HasValue && page.Value > 0 && pageSize.Value > 0)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            var result =
                from p in query
                join c in SampleCatalog.Categories on p.CategoryId equals c.Id
                select new ProductListItem
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryName = c.Name,
                    Status = p.Status
                };

            return Ok(result.ToList());
        }

        [HttpGet("products/{id:int}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = SampleCatalog.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("categories")]
        public ActionResult<IEnumerable<CategoryGroup>> GetCategories()
        {
            var result =
                from c in SampleCatalog.Categories
                let products = SampleCatalog.Products.Where(p => p.CategoryId == c.Id).ToList()
                select new CategoryGroup
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProductCount = products.Count,
                    AveragePrice = products.Count == 0 ? 0 : Math.Round(products.Average(p => p.Price), 2)
                };

            return Ok(result.ToList());
        }

        [HttpGet("stats")]
        public ActionResult<ShopStats> GetStats()
        {
            var prices = SampleCatalog.Products.Select(p => p.Price);

            var stats = new ShopStats
            {
                ProductCount = SampleCatalog.Products.Count,
                CategoryCount = SampleCatalog.Categories.Count,
                CustomerCount = SampleCatalog.Customers.Count,
                Cheapest = prices.Min(),
                MostExpensive = prices.Max(),
                AveragePrice = Math.Round(prices.Average(), 2),
                InventoryValue = prices.Sum(),
                ProductsByStatus = SampleCatalog.Products
                    .GroupBy(p => p.Status)
                    .Select(g => new StatusBreakdown { Status = g.Key, Count = g.Count() })
                    .OrderBy(s => s.Status)
                    .ToList()
            };

            return Ok(stats);
        }
    }
}
