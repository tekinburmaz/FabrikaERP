using System;

namespace FabrikaERP.Models
{
    /// <summary>
    /// Fabrika doküman yönetimi: ISO prosedürleri, makine kılavuzları, güvenlik belgeleri vb.
    /// </summary>
    public class Document
    {
        public int    Id           { get; set; }

        /// <summary>Benzersiz doküman numarası (örn. "DOC-ISO-001").</summary>
        public string Code         { get; set; } = string.Empty;

        public string Title        { get; set; } = string.Empty;

        public DocumentType Type   { get; set; }

        /// <summary>Dosya sistemi veya ağ paylaşımındaki tam yol.</summary>
        public string FilePath     { get; set; } = string.Empty;

        /// <summary>Dosya uzantısı / MIME tipi (PDF, DOCX, XLSX, …).</summary>
        public string FileExtension { get; set; } = string.Empty;

        /// <summary>Sürüm numarası (Örn. "v1.3").</summary>
        public string Version      { get; set; } = "v1.0";

        /// <summary>Hangi departmana ait olduğu.</summary>
        public string? Department  { get; set; }

        /// <summary>İlgili makine kodu (varsa).</summary>
        public string? MachineCode { get; set; }

        /// <summary>Dokümanın geçerlilik bitiş tarihi; null ise süresiz geçerli.</summary>
        public DateTime? ExpiryDate { get; set; }

        public bool   IsActive     { get; set; } = true;

        public string? Description { get; set; }

        /// <summary>Dokümanı sisteme yükleyen kullanıcı adı.</summary>
        public string? UploadedBy  { get; set; }

        public DateTime CreatedAt  { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt  { get; set; } = DateTime.UtcNow;
    }

    public enum DocumentType
    {
        MachinManual      = 1,   // Makine Kılavuzu
        SafetyProcedure   = 2,   // Güvenlik Prosedürü
        QualityStandard   = 3,   // Kalite Standardı
        WorkInstruction   = 4,   // İş Talimatı
        IsoDocument       = 5,   // ISO Belgesi
        FormTemplate      = 6,   // Form / Şablon
        Report            = 7,   // Rapor
        Other             = 99
    }
}
