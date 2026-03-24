using System;

namespace FabrikaERP.Models
{
    public enum TransactionType
    {
        Payment,    // Ödeme (Borç Kapatma)
        Receipt,    // Tahsilat (Alacak Kapatma)
        Refund,     // İade
        Adjustment  // Düzeltme
    }

    public enum TransactionStatus
    {
        Pending,
        Completed,
        Failed,
        Cancelled
    }

    public class FinanceTransaction
    {
        public int Id { get; set; }
        public string TransactionNumber { get; set; } = string.Empty;
        
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; } = TransactionStatus.Pending;
        
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "TRY";
        
        /// <summary>İlişkili Cari ID (Müşteri veya Tedarikçi).</summary>
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        
        public string? Description { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
