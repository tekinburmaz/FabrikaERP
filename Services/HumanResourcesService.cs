using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public class HumanResourcesService : IHumanResourcesService
    {
        private readonly FabrikaDbContext _db;

        public HumanResourcesService(FabrikaDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _db.Employees.Include(e => e.User).ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByCodeAsync(string code)
        {
            return await _db.Employees.Include(e => e.User).FirstOrDefaultAsync(e => e.EmployeeCode == code);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            employee.CreatedAt = DateTime.UtcNow;
            _db.Employees.Add(employee);
            await _db.SaveChangesAsync();
            return employee;
        }

        public async Task<ShiftSegment> StartShiftAsync(int employeeId)
        {
            var segment = new ShiftSegment
            {
                EmployeeId = employeeId,
                StartTime = DateTime.Now,
                CreatedAt = DateTime.UtcNow
            };
            
            _db.ShiftSegments.Add(segment);
            await _db.SaveChangesAsync();
            return segment;
        }

        public async Task EndShiftAsync(int segmentId, double overtime = 0, string? note = null)
        {
            var segment = await _db.ShiftSegments.FindAsync(segmentId)
                ?? throw new KeyNotFoundException($"Vardiya kaydı bulunamadı: {segmentId}");
                
            segment.EndTime = DateTime.Now;
            segment.OvertimeHours = overtime;
            segment.Note = note;
            
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShiftSegment>> GetEmployeeShiftsAsync(int employeeId)
        {
            return await _db.ShiftSegments
                .Where(s => s.EmployeeId == employeeId)
                .OrderByDescending(s => s.StartTime)
                .ToListAsync();
        }

        public async Task<LeaveRequest> RequestLeaveAsync(LeaveRequest request)
        {
            request.CreatedAt = DateTime.UtcNow;
            request.Status = LeaveStatus.Pending;
            _db.LeaveRequests.Add(request);
            await _db.SaveChangesAsync();
            return request;
        }

        public async Task ApproveLeaveAsync(int requestId, string approver)
        {
            var request = await _db.LeaveRequests.FindAsync(requestId)
                ?? throw new KeyNotFoundException($"İzin talebi bulunamadı: {requestId}");
                
            request.Status = LeaveStatus.Approved;
            request.ApprovedBy = approver;
            
            // Eğer izin aktif ise personel statüsünü de değiştirebiliriz
            if (request.StartDate <= DateTime.Today && request.EndDate >= DateTime.Today)
            {
                var employee = await _db.Employees.FindAsync(request.EmployeeId);
                if (employee != null) employee.Status = EmployeeStatus.OnLeave;
            }
            
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<LeaveRequest>> GetPendingLeavesAsync()
        {
            return await _db.LeaveRequests
                .Where(l => l.Status == LeaveStatus.Pending)
                .Include(l => l.Employee)
                .ToListAsync();
        }
    }
}
