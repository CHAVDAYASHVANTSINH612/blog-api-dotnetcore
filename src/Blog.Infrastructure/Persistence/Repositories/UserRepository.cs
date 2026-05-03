using System;
using Blog.Domain.Entities;
using Blog.Domain.Interface;
using Blog.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Persistence.Repositories;

public class UserRepository(BlogDbContext blogDBContext) : GenericRepository<User>(blogDBContext), IUserRepository
{
    public async Task<List<string>> GetRolesByEmailAsync(string email)
    {
        return await blogDBContext.Users.Where(u => u.Email== email)
                                  .SelectMany(x => x.UserRoles)
                                  .Select(ur=> ur.Role.Name)
                                  .ToListAsync();
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await blogDBContext.Users.FirstOrDefaultAsync(x => x.Email == email);
    }
}
