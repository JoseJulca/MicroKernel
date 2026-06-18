using API.Service.MicroKernel.Core;
using API.Service.MicroKernel.Plugins;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IAppContext, PluginAppContext>();

builder.Services.AddSingleton<PluginManager>(sp =>
{
    var ctx = sp.GetRequiredService<IAppContext>();
    var kernel = new PluginManager(ctx);

    kernel.Register(new MatchScorePlugin());
    kernel.Register(new RankingPlugin());
    kernel.Register(new PredictionPlugin());

    return kernel;
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("ExtensionPolicy", p => p
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("ExtensionPolicy");
app.MapControllers();
app.Run();
