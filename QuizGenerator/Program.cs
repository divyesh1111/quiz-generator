using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using QuizGenerator;
using QuizGenerator.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

// Register Quiz Services
builder.Services.AddSingleton<IQuestionBankService, QuestionBankService>();
builder.Services.AddSingleton<IQuizService, QuizService>();

await builder.Build().RunAsync();