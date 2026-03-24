using FabrikaERP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public interface IBomService
    {
        Task<IEnumerable<BillOfMaterial>> GetAllBomsAsync();
        Task<BillOfMaterial?> GetBomByProductCodeAsync(string productCode);
        Task<BillOfMaterial> CreateBomAsync(BillOfMaterial bom);
        Task<bool> DeleteBomAsync(int bomId);
        
        Task<IEnumerable<BomItem>> GetBomItemsAsync(int bomId);
        Task AddBomItemAsync(BomItem item);
        Task RemoveBomItemAsync(int itemId);
    }
}
