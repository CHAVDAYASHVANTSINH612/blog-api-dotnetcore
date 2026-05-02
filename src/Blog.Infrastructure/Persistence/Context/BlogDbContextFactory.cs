using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Blog.Infrastructure.Persistence.Context;

public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
{
    public BlogDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<BlogDbContext>();
        optionBuilder.UseSqlServer("Server=Y\\SQLEXPRESS ; Database= BlogDB  ; Integrated Security=True;TrustServerCertificate=True;");

        return new BlogDbContext(optionBuilder.Options);
    }    
}
