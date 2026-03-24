using FabrikaERP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public interface IHumanResourcesService
    {
        // Employee
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByCodeAsync(string code);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        
        // Shift / Attendance
        Task<ShiftSegment> StartShiftAsync(int employeeId);
        Task EndShiftAsync(int segmentId, double overtime = 0, string? note = null);
        Task<IEnumerable<ShiftSegment>> GetEmployeeShiftsAsync(int employeeId);
        
        // Leave Management
        Task<LeaveRequest> RequestLeaveAsync(LeaveRequest request);
        Task ApproveLeaveAsync(int requestId, string approver);
        Task<IEnumerable<LeaveRequest>> GetPendingLeavesAsync();
    }
}
