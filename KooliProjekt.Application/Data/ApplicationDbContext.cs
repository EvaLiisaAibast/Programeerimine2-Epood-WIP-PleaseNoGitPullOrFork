using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
                    {
                        property.SetPrecision(18);
                        property.SetScale(2);
                    }
                }
            }
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Wishlist> Wishlists { get; set; }

        public DbSet<WishlistItem> WishlistItems { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<ReviewResponse> ReviewResponses   { get; set; }

        public DbSet<ReviewImage> ReviewImages { get; set; }

        public DbSet<SupportTicket> SupportTickets { get; set; }

        public DbSet<TicketMessage> TicketMessages { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<CustomerGroup> CustomerGroups { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<ProductVideo> ProductVideos { get; set; }

        public DbSet<ProductOption> ProductOptions { get; set; }

        public DbSet<OptionValue> OptionValues { get; set; }

        public DbSet<ProductVariant> ProductVariants { get; set; }

        public DbSet<VariantOption> VariantOptions { get; set; }

        public DbSet<PriceHistory> PriceHistories { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<CampaignProduct> CampaignProducts { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<StockLevel> StockLevels { get; set; }

        public DbSet<StockMovement> StockMovements { get; set; }

        public DbSet<WarehouseTransfer> WarehouseTransfers { get; set; }

        public DbSet<WarehouseTransferLine> WarehouseTransferLines { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Refund> Refunds { get; set; }

        public DbSet<Shipment> Shipments { get; set; }

        public DbSet<Carrier> Carriers { get; set; }

        public DbSet<ShipmentTracking> ShipmentTrackings { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<EmployeeRole> EmployeeRoles { get; set; }

        public DbSet<AuditLog> AuditLogs { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }

        public DbSet<GoodsReceipt> GoodsReceipts { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        public DbSet<VatRate> VatRates { get; set; }

        public DbSet<ReturnRequest> ReturnRequests { get; set; }

        public DbSet<ReturnLine> ReturnLines { get; set; }

        public DbSet<LoyaltyAccount> LoyaltyAccounts { get; set; }

        public DbSet<LoyaltyPoints> LoyaltyPoints { get; set; }

        public DbSet<GiftCard> GiftCards { get; set; }
    }
}
