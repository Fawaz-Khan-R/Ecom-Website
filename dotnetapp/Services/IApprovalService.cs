using System.Threading.Tasks;

namespace dotnetapp.Services
{
    public interface IApprovalService
    {
        Task ApproveAsync(int requestId);
        // Other approval-related methods
    }

    
}
