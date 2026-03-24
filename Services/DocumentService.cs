using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly FabrikaDbContext _db;

        public DocumentService(FabrikaDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return await _db.Documents.Where(d => d.IsActive).OrderBy(d => d.Code).ToListAsync();
        }

        public async Task<IEnumerable<Document>> GetByDepartmentAsync(string department)
        {
            return await _db.Documents
                .Where(d => d.IsActive && d.Department == department)
                .OrderBy(d => d.Code)
                .ToListAsync();
        }

        public async Task<IEnumerable<Document>> GetByTypeAsync(DocumentType type)
        {
            return await _db.Documents
                .Where(d => d.IsActive && d.Type == type)
                .OrderBy(d => d.Code)
                .ToListAsync();
        }

        public async Task<Document?> GetByCodeAsync(string code)
        {
            return await _db.Documents.FirstOrDefaultAsync(d => d.Code == code);
        }

        public async Task<IEnumerable<Document>> GetExpiredDocumentsAsync()
        {
            var today = DateTime.UtcNow.Date;
            return await _db.Documents
                .Where(d => d.IsActive && d.ExpiryDate.HasValue && d.ExpiryDate.Value.Date < today)
                .OrderBy(d => d.ExpiryDate)
                .ToListAsync();
        }

        public async Task<Document> AddDocumentAsync(Document document)
        {
            document.CreatedAt = DateTime.UtcNow;
            document.UpdatedAt = DateTime.UtcNow;
            _db.Documents.Add(document);
            await _db.SaveChangesAsync();
            return document;
        }

        public async Task<Document> UpdateVersionAsync(int id, string newVersion, string newFilePath)
        {
            var doc = await _db.Documents.FindAsync(id)
                ?? throw new KeyNotFoundException($"Doküman bulunamadı: {id}");

            doc.Version   = newVersion;
            doc.FilePath  = newFilePath;
            doc.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            return doc;
        }

        public async Task<bool> DeleteDocumentAsync(int id)
        {
            var doc = await _db.Documents.FindAsync(id);
            if (doc == null) return false;

            // Fiziksel silme yerine pasife alıyoruz (soft-delete)
            doc.IsActive  = false;
            doc.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return true;
        }

        public void OpenDocument(Document document)
        {
            if (!string.IsNullOrWhiteSpace(document.FilePath) && System.IO.File.Exists(document.FilePath))
            {
                Process.Start(new ProcessStartInfo(document.FilePath) { UseShellExecute = true });
            }
        }
    }
}
