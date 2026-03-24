using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public class BomService : IBomService
    {
        private readonly FabrikaDbContext _db;

        public BomService(FabrikaDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<BillOfMaterial>> GetAllBomsAsync()
        {
            return await _db.BillOfMaterials.Where(b => b.IsActive).ToListAsync();
        }

        public async Task<BillOfMaterial?> GetBomByProductCodeAsync(string productCode)
        {
            return await _db.BillOfMaterials
                .Include(b => b.Items)
                .FirstOrDefaultAsync(b => b.ProductCode == productCode && b.IsActive);
        }

        public async Task<BillOfMaterial> CreateBomAsync(BillOfMaterial bom)
        {
            bom.CreatedAt = DateTime.UtcNow;
            bom.UpdatedAt = DateTime.UtcNow;
            _db.BillOfMaterials.Add(bom);
            await _db.SaveChangesAsync();
            return bom;
        }

        public async Task<bool> DeleteBomAsync(int bomId)
        {
            var bom = await _db.BillOfMaterials.FindAsync(bomId);
            if (bom == null) return false;
            
            bom.IsActive = false; // Soft-delete
            bom.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BomItem>> GetBomItemsAsync(int bomId)
        {
            return await _db.BomItems.Where(i => i.BillOfMaterialId == bomId).ToListAsync();
        }

        public async Task AddBomItemAsync(BomItem item)
        {
            _db.BomItems.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveBomItemAsync(int itemId)
        {
            var item = await _db.BomItems.FindAsync(itemId);
            if (item != null)
            {
                _db.BomItems.Remove(item);
                await _db.SaveChangesAsync();
            }
        }
    }
}
