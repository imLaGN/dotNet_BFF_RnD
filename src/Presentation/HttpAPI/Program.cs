var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

#endregion Add services to the container.

#region Build & configure the application.

var app = builder.Build();

// Apply development-specific configurations
if (app.Environment.IsDevelopment())
{
	// OpenAPI endpoint activation
	app.MapOpenApi();

	// Swagger UI
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();  // Enforce HTTPS
app.UseAuthorization();     // Authorization middleware
app.MapControllers();       // Map controller routes

#endregion Build & configure the application.

/**
 * Start the application.
 */
//app.Run();
await app.RunAsync();