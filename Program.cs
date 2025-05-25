using LocationServer.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var build = Host.CreateApplicationBuilder(args);

build.Logging.AddConsole(options =>
options.LogToStandardErrorThreshold = LogLevel.Trace
);

build.Services.AddMcpServer()
.WithStdioServerTransport()
.WithToolsFromAssembly();

build.Services.AddScoped<LocationService>();

var app = build.Build();

await app.RunAsync();