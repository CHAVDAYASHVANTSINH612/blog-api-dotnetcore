using System;

namespace Blog.Domain.Entities;

public class Comment
{
    public int Id {get;set;}
    public required string Content {get; set;}
    public required DateTime CreatedAt {get; set;}
    public required DateTime UpdatedAt {get; set;}
    public int UserId {get; set;}
    public User? User {get; set;}
    public int BlogId {get; set;}
    public Blog? Blog {get; set;}
}
