using System;

namespace Blog.Domain.Entities;

public class Comment
{
    public int Id {get;set;}
    public required string Content {get; set;}
    public required DateTime CreatedAt {get; set;} = DateTime.Now;
    public required DateTime UpdatedAt {get; set;} = DateTime.Now;
    public int UserId {get; set;}
    public User User {get; set;}
    public int BlogId {get; set;}
    public Blog Blog {get; set;}
}
