using System;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Persistence.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comment");
        builder.HasKey(c => c.Id);

        builder.Property(c=> c.Content).IsRequired();
        builder.Property(c=> c.CreatedAt).IsRequired();
        builder.Property(c=> c.UpdatedAt).IsRequired();

        builder.HasOne(c => c.User)
        .WithMany(u => u.Comments)
        .HasForeignKey(c=> c.UserId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.Blog)
        .WithMany(b => b.Comments)
        .HasForeignKey(c=> c.BlogId)
        .OnDelete(DeleteBehavior.NoAction);
        
    }
}
