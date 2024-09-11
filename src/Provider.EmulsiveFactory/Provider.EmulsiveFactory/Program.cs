using Provider.EmulsiveFactory;

var builder = WebApplication.CreateBuilder(args);
AppSetup.ConfigureBuilder(builder);

var app = builder.Build();
AppSetup.ConfigureApp(app);

app.Run();