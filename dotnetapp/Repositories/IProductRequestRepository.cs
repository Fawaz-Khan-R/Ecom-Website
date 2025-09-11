using System.Threading.Tasks;
using dotnetapp.Models;

namespace dotnetapp.Repositories
{
    public interface IProductRequestRepository
    {
        Task AddAsync(ProductRequest request);
        // Add other method signatures as needed
    }
}
