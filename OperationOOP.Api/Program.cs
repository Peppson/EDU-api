namespace OperationOOP.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();

        // Swagger
        builder.Services.AddSwaggerGen(options =>
        {
            options.CustomSchemaIds(type => type.FullName?.Replace('+', '.'));
            options.InferSecuritySchemes();
            options.SwaggerDoc("v1", new()
            {
                Title = "Demo Api",
                Version = "v1"
            });
        });

        
        // Todo add validations 
        builder.Services.AddSingleton<IDatabase, Database>(); // Mock DB
        

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            { 
                c.DefaultModelsExpandDepth(-1);         // Hide schemas
            }); 
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapEndpoints<Program>();
        app.Run();
    }
}
