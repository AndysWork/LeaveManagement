using LeaveManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Contracts
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        public bool CheckAllocation(int leaveTypeId, string employeeId);
        public ICollection<LeaveAllocation> GetLeaveAllocationsByEmployeeId(string Id);
    }
}
