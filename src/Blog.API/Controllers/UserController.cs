using System;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

public class UserController:BaseApiController
{
    [HttpGet]
    public string[] getUsers()
    {
        return new[]
        {
            "user1", "User2", "Admin"
        };
    }
}
