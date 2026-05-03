using System;
using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Blog.Infrastructure.Persistence.Context;

public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options) 
{
    public DbSet<User> Users {get; set;}
    public DbSet<Role> Roles {get; set;}
    public DbSet<UserRole> UserRoles {get; set;}
    public DbSet<Blog.Domain.Entities.Blog> Blogs {get; set;}
    public DbSet<Comment> Comments {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         // way1: add for each configuration
         // modelBuilder.ApplyConfiguration(new UserConfiguration());

        //way2:
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);
    }

}
