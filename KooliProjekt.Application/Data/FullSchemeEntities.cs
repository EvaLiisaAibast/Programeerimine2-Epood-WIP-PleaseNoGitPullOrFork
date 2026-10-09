using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Data
{
    #region Customer

    public class Address
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(20)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(150)]
        public string Street { get; set; }

        [Required]
        [StringLength(20)]
        public string HouseNumber { get; set; }

        [StringLength(20)]
        public string Apartment { get; set; }

        public bool IsDefault { get; set; }
    }

    public class ShoppingCart
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

    public class CartItem
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int VariantId { get; set; }

        [Range(0, int.MaxValue, MinimumIsExclusive = true)]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }
    }

    public class Wishlist
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class WishlistItem
    {
        public int Id { get; set; }

        public int WishlistId { get; set; }

        public int VariantId { get; set; }

        public DateTime AddedAt { get; set; }
    }

    public class Review
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int OrderLineId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(4000)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }

    public class ReviewResponse
    {
        public int Id { get; set; }

        public int ReviewId { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(4000)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class ReviewImage
    {
        public int Id { get; set; }

        public int ReviewId { get; set; }

        [Required]
        [StringLength(255)]
        public string Url { get; set; }
    }

    public class SupportTicket
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int ResponsibleEmployeeId { get; set; }

        [Required]
        [StringLength(200)]
        public string Subject { get; set; }

        [Required]
        [StringLength(50)]
        public string Priority { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ClosedAt { get; set; }
    }

    public class TicketMessage
    {
        public int Id { get; set; }

        public int TicketId { get; set; }

        [Required]
        [StringLength(50)]
        public string SenderType { get; set; }

        public int SenderId { get; set; }

        [Required]
        [StringLength(4000)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class Notification
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(2000)]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ReadAt { get; set; }
    }

    public class CustomerGroup
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string GroupName { get; set; }

        [Range(0, 100)]
        public decimal DiscountPercent { get; set; }
    }

    #endregion

    #region Catalog

    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Website { get; set; }
    }

    public class ProductImage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(255)]
        public string Url { get; set; }

        [StringLength(200)]
        public string AltText { get; set; }

        public int SortOrder { get; set; }

        public bool IsMain { get; set; }
    }

    public class ProductVideo
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(255)]
        public string Url { get; set; }

        [StringLength(200)]
        public string Title { get; set; }
    }

    public class ProductOption
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }

    public class OptionValue
    {
        public int Id { get; set; }

        public int ProductOptionId { get; set; }

        [Required]
        [StringLength(100)]
        public string Value { get; set; }
    }

    [Index(nameof(ProductCode), IsUnique = true)]
    public class ProductVariant
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductCode { get; set; }

        [StringLength(50)]
        public string Barcode { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue)]
        public decimal WeightKg { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }

    public class VariantOption
    {
        public int Id { get; set; }

        public int VariantId { get; set; }

        public int OptionValueId { get; set; }
    }

    public class PriceHistory
    {
        public int Id { get; set; }

        public int VariantId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal CurrentPrice { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }
    }

    public class Campaign
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }

    public class CampaignProduct
    {
        public int Id { get; set; }

        public int CampaignId { get; set; }

        public int ProductId { get; set; }

        [Range(0, 100)]
        public decimal DiscountPercent { get; set; }
    }

    [Index(nameof(Code), IsUnique = true)]
    public class Coupon
    {
        public int Id { get; set; }

        public int CampaignId { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        public int UsageLimit { get; set; }

        public int UsedCount { get; set; }

        [Range(0, double.MaxValue)]
        public decimal MinimumOrderAmount { get; set; }
    }

    #endregion

    #region Warehouse

    public class Warehouse
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int AddressId { get; set; }
    }

    public class StockLevel
    {
        public int Id { get; set; }

        public int WarehouseId { get; set; }

        public int VariantId { get; set; }

        public int Quantity { get; set; }

        public int Reserved { get; set; }

        public int MinimumStock { get; set; }
    }

    public class StockMovement
    {
        public int Id { get; set; }

        public int StockLevelId { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public int Quantity { get; set; }

        [StringLength(500)]
        public string Reason { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class WarehouseTransfer
    {
        public int Id { get; set; }

        public int FromWarehouseId { get; set; }

        public int ToWarehouseId { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime CompletedAt { get; set; }
    }

    public class WarehouseTransferLine
    {
        public int Id { get; set; }

        public int TransferId { get; set; }

        public int VariantId { get; set; }

        [Range(0, int.MaxValue, MinimumIsExclusive = true)]
        public int Quantity { get; set; }
    }

    #endregion

    #region Order

    public class OrderStatusHistory
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        [Required]
        [StringLength(50)]
        public string OldStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string NewStatus { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int ChangedBy { get; set; }
    }

    public class Payment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string Method { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(100)]
        public string TransactionReference { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class Refund
    {
        public int Id { get; set; }

        public int PaymentId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [StringLength(500)]
        public string Reason { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    #endregion

    #region Shipping

    public class Shipment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int WarehouseId { get; set; }

        public int CarrierId { get; set; }

        [StringLength(100)]
        public string TrackingNumber { get; set; }

        public DateTime SentAt { get; set; }

        public DateTime EstimatedDelivery { get; set; }

        public DateTime DeliveredAt { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }

    public class Carrier
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Website { get; set; }
    }

    public class ShipmentTracking
    {
        public int Id { get; set; }

        public int ShipmentId { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(200)]
        public string Location { get; set; }

        public DateTime Timestamp { get; set; }
    }

    #endregion

    #region Employee

    public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }

    [Index(nameof(Email), IsUnique = true)]
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; }

        public int DepartmentId { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class EmployeeRole
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; }
    }

    public class AuditLog
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string ObjectType { get; set; }

        public int ObjectId { get; set; }

        [Required]
        [StringLength(50)]
        public string Action { get; set; }

        [StringLength(4000)]
        public string OldValue { get; set; }

        [StringLength(4000)]
        public string NewValue { get; set; }

        [StringLength(50)]
        public string IpAddress { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    #endregion

    #region Purchasing

    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string ContractReference { get; set; }
    }

    public class PurchaseOrder
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }

        public int WarehouseId { get; set; }

        public DateTime OrderedAt { get; set; }

        public DateTime ExpectedAt { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }

    public class PurchaseOrderLine
    {
        public int Id { get; set; }

        public int PurchaseOrderId { get; set; }

        public int VariantId { get; set; }

        public int OrderedQuantity { get; set; }

        public int ReceivedQuantity { get; set; }

        [Range(0, double.MaxValue)]
        public decimal PurchasePrice { get; set; }
    }

    public class GoodsReceipt
    {
        public int Id { get; set; }

        public int PurchaseOrderLineId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public int EmployeeId { get; set; }
    }

    #endregion

    #region Other

    [Index(nameof(Code), IsUnique = true)]
    public class Currency
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Symbol { get; set; }
    }

    public class ExchangeRate
    {
        public int Id { get; set; }

        public int FromCurrencyId { get; set; }

        public int ToCurrencyId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Rate { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class VatRate
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [Range(0, 100)]
        public decimal Rate { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }
    }

    public class ReturnRequest
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(500)]
        public string Reason { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class ReturnLine
    {
        public int Id { get; set; }

        public int ReturnRequestId { get; set; }

        public int OrderLineId { get; set; }

        public int Quantity { get; set; }

        [StringLength(500)]
        public string Reason { get; set; }
    }

    public class LoyaltyAccount
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int Balance { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class LoyaltyPoints
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public int Points { get; set; }

        [Required]
        [StringLength(200)]
        public string Reason { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    [Index(nameof(Code), IsUnique = true)]
    public class GiftCard
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Range(0, double.MaxValue)]
        public decimal InitialAmount { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Balance { get; set; }

        public DateTime ExpiryDate { get; set; }
    }

    #endregion
}
