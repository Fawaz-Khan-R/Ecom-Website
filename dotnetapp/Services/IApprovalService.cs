using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetapp.Models;

namespace dotnetapp.Services
{
    public interface IApprovalService
    {
        Task ApproveAsync(int requestId);
        IEnumerable<Approval> GetAllApprovals();
        Approval GetApprovalById(int id);
        void CreateApproval(Approval approval);
        void UpdateApproval(int id, Approval approval);
        void DeleteApproval(int id);
    }
}
