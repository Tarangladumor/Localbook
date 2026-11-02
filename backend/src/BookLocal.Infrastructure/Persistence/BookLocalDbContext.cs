using BookLocal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLocal.Infrastructure.Persistence;

public class BookLocalDbContext : DbContext
{
    public BookLocalDbContext(
        DbContextOptions<BookLocalDbContext> options)
        : base(options)
    {

    }

    public DbSet<Business> Businesses => Set<Business>();
    public DbSet<Category> Categories => Set<Category>();

}