using Library_App.Configurations;
using Library_App.GraphQL.Writer;
using Library_App.Repositories;
using Library_App.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// swagger oauth2 configuration
builder.Services.AddSwaggerGen(
    options =>
    {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Description = "Standart Authorization header using the Bearer scheme",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });

        options.OperationFilter<SecurityRequirementsOperationFilter>();
    }
);

// database configuration
builder.Services.AddDbContext<Database>(
    options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
        options.ConfigureWarnings(warnings =>
            warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
    }
);

// enum converter and ignore cycle
builder.Services.AddControllers().AddJsonOptions(
    options =>
    {
        var enumConverter = new JsonStringEnumConverter();
        options.JsonSerializerOptions.Converters.Add(enumConverter);
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    }
);

// authentication configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWTConfig:key").Value)),
                ValidateIssuer = false,
                ValidateAudience =false,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        }
    );


// dependencies or containers
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IAuthRepository, AuthRepository>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<IRatingService, RatingService>();
builder.Services.AddTransient<IRatingRepository, RatingRepository>();
builder.Services.AddTransient<IFavoriteService, FavoriteService>();
builder.Services.AddTransient<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddTransient<IWriterService, WriterService>();
builder.Services.AddTransient<IWriterRepository, WriterRepository>();
builder.Services.AddTransient<IFriendshipService, FriendshipService>();
builder.Services.AddTransient<IFriendshipRepository, FriendshipRepository>();
builder.Services.AddTransient<IBookSharingService, BookSharingService>();
builder.Services.AddTransient<IBookSharingRepository, BookSharingRepository>();

// graphQL types and queries 
builder.Services.AddTransient<WriterQuery>();
builder.Services.AddTransient<WriterMutation>();
builder.Services.AddGraphQL(g => SchemaBuilder.New().AddServices(g).AddType<WriterType>().AddQueryType<WriterQuery>().AddMutationType<WriterMutation>().Create());

var app = builder.Build();

Database.Seed(app.Services.CreateScope().ServiceProvider.GetRequiredService<Database>());

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

// cors configuration
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

// graphQL configuration
app.MapGraphQL("/api");
app.UseGraphQLAltair();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
