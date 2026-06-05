using WebApplication1.DTOs;

namespace WebApplication1.Service;

public interface IPCService
{
    Task<IEnumerable<PCResponse>> GetAllPC(CancellationToken cancellationToken);
    Task<PCDetailsResponse> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<PCResponse> AddAsync(CreatePCRequest req, CancellationToken cancellationToken);
    Task UpdateAsync(int id, UpdatePCRequest req, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}