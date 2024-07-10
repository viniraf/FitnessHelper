var builder = WebApplication.CreateBuilder(args);

// Load the environment variables from the .env file
Env.Load();
Env.TraversePath().Load();

// Get the database connection string from the .env file
string connectionString = Env.GetString("CONNECTION_STRING");
string secretKey = Env.GetString("JWT_SECRET_KEY");

// Add services to the container.
SwaggerControllerOrder<ControllerBase> swaggerControllerOrder = new SwaggerControllerOrder<ControllerBase>(Assembly.GetEntryAssembly());

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FitnessHelper", Version = "v1" });
    c.EnableAnnotations();
    c.OrderActionsBy((apiDesc) => $"{swaggerControllerOrder.SortKey(apiDesc.ActionDescriptor.RouteValues["controller"])}");

    // Define the BearerAuth scheme
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IJwtHelper>(x => new JwtHelper(secretKey));
builder.Services.AddScoped<IPasswordHashHelper, PasswordHashHelper>();
builder.Services.AddScoped<ICalculationService, CalculationService>();
builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IHistoryService, HistoryService>();
builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Add JWT authentication middleware
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FitnessHelper v1");

        // Configure Swagger to use the BearerAuth scheme
        c.DocExpansion(DocExpansion.List);
        c.DefaultModelsExpandDepth(-1);
        c.DefaultModelExpandDepth(-1);
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();