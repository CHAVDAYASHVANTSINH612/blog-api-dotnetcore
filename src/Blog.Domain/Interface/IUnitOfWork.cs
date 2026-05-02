using System;

namespace Blog.Domain.Interface;

public interface IUnitOfWork
{
    void Commit();
    Task CommitAsync();
}
