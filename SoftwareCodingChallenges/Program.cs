using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Version = "v1",
            Title = "Coding Challenges",
            Description = "This API will contain coding challenges that Software Engineers may see during their interviews.",

            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "TJ Lopez",
                Email = "walter.tj.lopez@gmail.com"
            },
        });
    });




var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Easy Challenges");
    c.RoutePrefix = string.Empty;
});
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
