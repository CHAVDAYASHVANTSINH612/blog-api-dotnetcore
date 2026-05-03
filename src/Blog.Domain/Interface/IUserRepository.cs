using System;
using Blog.Domain.Entities;

namespace Blog.Domain.Interface;

public interface IUserRepository: IGenericRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<List<string>> GetRolesByEmailAsync(string email);

}
