using System;
using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace Blog.Infrastructure.Persistence.Context;

public class BlogDbContext: DbContext 
{
    
    //Way1
    public BlogDbContext(DbContextOptions<BlogDbContext> options): base(options)
    {    }

    //Way2: after .net 8 and c#12 we have primary constructor, so we can write at class declarations
        //public class BlogDbContext(DbContextOptions<BlogDbContext> options): DbContext(options){


    public DbSet<User> Users;
    public DbSet<Role> Roles;
    public DbSet<UserRole> UserRoles;
    public DbSet<Blog.Domain.Entities.Blog> Blogs;
    public DbSet<Comment> Comments;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         // way1: add for each configuration
         // modelBuilder.ApplyConfiguration(new UserConfiguration());

        //way2:
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);
    }

}
