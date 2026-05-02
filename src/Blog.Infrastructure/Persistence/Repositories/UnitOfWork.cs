using System;
using Blog.Domain.Interface;
using Blog.Infrastructure.Persistence.Context;

namespace Blog.Infrastructure.Persistence.Repositories;

public class UnitOfWork(BlogDbContext context) : IUnitOfWork
{
    public void Commit()
    {
       context.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }
}
