using BookLocal.Application.Businesses.DTOs;

namespace BookLocal.Application.Businesses.Interfaces;

public interface IBusinessService
{
    Task<BusinessResponse> CreateAsync(CreateBusinessRequest request, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<BusinessResponse>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<BusinessResponse?> GetByIdAsync(int Id, CancellationToken cancellationToken = default);

    Task<BusinessResponse?> UpdateAsync(int Id, UpdateBusinessRequest updateBusinessRequest, CancellationToken cancellationToken);

    Task<bool> DeleteAsync(int Id, CancellationToken cancellationToken);
}