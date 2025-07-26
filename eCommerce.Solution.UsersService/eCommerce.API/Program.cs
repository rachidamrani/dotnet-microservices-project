using eCommerce.Core;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add Services
builder.Services.AddCore();
builder.Services.AddInfrastructure();

// Add controllers to the service collection
builder.Services.AddControllers();

// Build the web application
var app = builder.Build();

// Routing
app.UseRouting();

// Authentication
app.UseAuthentication();

// Authorization
app.UseAuthorization();

// Controller routes
app.MapControllers();

app.Run();