Blog API project with Clean Architecture Approch.





EF Migration commands:

dotnet ef migrations add DBSetupComment --output-dir Persistence/Migrations


dotnet ef database update

CLI commands:

dotnet new webapi --name Blog.API                           // Create web api project with minimal api
dotnet new webapi --name Blog.API --use-minimal-apis        // Create web api project with minimal api   
dotnet new webapi --name Blog.API --use-controllers         // Create web api project with controllers  
                                                            // both Minimal <-> Controllers can be converted into each other by some changes


dotnet build            // to build all projects //run from root path

dotnet run --project src/Blog.API --launch-profile https            // to run project and choose https as launch profile from launchsetting.json

// in Infrastructure project
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.tools
    dotnet add package Microsoft.EntityFrameworkCore.design

//Dotnet 10.0 does not support swagger api docs by default : 
    
    steps to do it : 

    1. dotnet add package Swashbuckle.AspNetCore

    2. in program.cs before  "var app = builder.Build();"
        builder.Services.AddSwaggerGen();

    3. in program.cs after "var app = builder.Build();"
    
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                // Enable Swagger UI
                app.UseSwagger();
                app.UseSwaggerUI(options => 
                {
                    // Point to the native .NET 10 OpenAPI JSON endpoint
                    options.SwaggerEndpoint("/openapi/v1.json", "My API v1");
                });
            }
    4. launchsetting..json
         in https  add : "launchUrl": "swagger",

