using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Models;

namespace dotnetapp.Services
{
    public class ApprovalService : IApprovalService
    {
        private readonly List<Approval> _approvals = new();
        public IEnumerable<Approval> GetAllApprovals() => _approvals;
        public Approval GetApprovalById(int id) => _approvals.FirstOrDefault(a => a.Id == id);
        public void CreateApproval(Approval approval)
        {
            approval.Id = _approvals.Count + 1;
            _approvals.Add(approval);
        }
        public void UpdateApproval(int id, Approval approval)
        {
            var existing = GetApprovalById(id);
            if (existing != null)
            {
                existing.Status = approval.Status;
                existing.Comments = approval.Comments;
            }
        }
        public void DeleteApproval(int id)
        {
            var approval = GetApprovalById(id);
            if (approval != null)
                _approvals.Remove(approval);
        }
        public async Task ApproveAsync(int requestId)
        {
            // Implementation here
            await Task.CompletedTask;
        }
    }
}