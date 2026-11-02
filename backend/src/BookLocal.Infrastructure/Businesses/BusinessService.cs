using BookLocal.Application.Businesses.DTOs;
using BookLocal.Application.Businesses.Interfaces;
using BookLocal.Domain.Entities;
using BookLocal.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookLocal.Infrastructure.Businesses;

public class BusinessService : IBusinessService
{
    private readonly BookLocalDbContext _dbContext;

    public BusinessService(BookLocalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<BusinessResponse> CreateAsync(CreateBusinessRequest request, CancellationToken cancellationToken = default)
    {
        var business = new Business
        {
            Name = request.Name,
            Description = request.Description
        };

        _dbContext.Businesses.Add(business);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new BusinessResponse
        {
            Id = business.Id,
            Name = business.Name,
            Description = business.Description,
            CreatedAtUtc = business.CreatedAtUtc
        };
    }
    
    public async Task<IReadOnlyList<BusinessResponse>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Businesses
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .Select(b => new BusinessResponse
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                CreatedAtUtc = b.CreatedAtUtc
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<BusinessResponse?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Businesses
            .AsNoTracking()
            .Where(b => b.Id == id)
            .Select(b => new BusinessResponse
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                CreatedAtUtc = b.CreatedAtUtc
            })
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<BusinessResponse> UpdateAsync(int Id, UpdateBusinessRequest updateBusinessRequest, CancellationToken cancellationToken)
    {
        var business = await _dbContext.Businesses
        .FirstOrDefaultAsync(b => b.Id == Id, cancellationToken);

        if (business == null)
        {
            return null;
        }

        business.Name = updateBusinessRequest.Name;
        business.Description = updateBusinessRequest.Description;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new BusinessResponse
        {
            Id = business.Id,
            Name = business.Name,
            Description = business.Description,
            CreatedAtUtc = business.CreatedAtUtc
        };
    }

    public async Task<bool> DeleteAsync(
    int id,
    CancellationToken cancellationToken = default)
    {
        var business = await _dbContext.Businesses
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

        if (business is null)
        {
            return false;
        }

        _dbContext.Businesses.Remove(business);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}