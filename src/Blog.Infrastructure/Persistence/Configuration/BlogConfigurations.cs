using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Persistence.Configuration;

public class BlogConfigurations : IEntityTypeConfiguration<Blog.Domain.Entities.Blog>
{

    public void Configure(EntityTypeBuilder<Domain.Entities.Blog> builder)
    {
        builder.ToTable("Blog");

        builder.HasKey(x => x.Id);

        builder.Property(x=> x.Title).IsRequired().HasMaxLength(250);
        builder.Property(x=> x.Content).IsRequired();
        builder.Property(x=> x.Image).IsRequired();
        builder.Property(x=> x.CreatedAt).IsRequired();
        builder.Property(x=> x.UpdatedAt).IsRequired();

        builder.HasOne(b => b.User)
        .WithMany(u=> u.Blogs)
        .HasForeignKey(b=> b.UserId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}
