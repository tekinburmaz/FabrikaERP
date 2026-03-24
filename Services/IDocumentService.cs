using FabrikaERP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public interface IDocumentService
    {
        Task<IEnumerable<Document>> GetAllDocumentsAsync();
        Task<IEnumerable<Document>> GetByDepartmentAsync(string department);
        Task<IEnumerable<Document>> GetByTypeAsync(DocumentType type);
        Task<Document?> GetByCodeAsync(string code);

        /// <summary>Süresi dolmuş (ExpiryDate geçmiş) dokümanları getirir.</summary>
        Task<IEnumerable<Document>> GetExpiredDocumentsAsync();

        Task<Document> AddDocumentAsync(Document document);

        /// <summary>Yeni sürüm yükler; eski versiyonun Version ve UpdatedAt alanlarını günceller.</summary>
        Task<Document> UpdateVersionAsync(int id, string newVersion, string newFilePath);

        Task<bool> DeleteDocumentAsync(int id);

        /// <summary>Dosyayı işletim sistemi ile açar (Process.Start).</summary>
        void OpenDocument(Document document);
    }
}
