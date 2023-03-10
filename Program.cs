using WebApp.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IIssueRepository, IssueRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSession(options => {
    options.Cookie.Name = ".User.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(120);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseSession();

app.Run();