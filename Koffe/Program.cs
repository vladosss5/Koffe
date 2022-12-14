using Avalonia;
using Avalonia.ReactiveUI;
using System;
using Avalonia.Controls;
using Koffe.Views;
using Koffe.Context;

namespace Koffe;

class Program
{
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args, ShutdownMode.OnLastWindowClose);
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace()
            .UseReactiveUI();
    
    private static void AppMain(Application app, string[] args)
    {
        var window = new AuthorizationWindow()
        {
            DataContext = new ApplicationDbContext(),
        };

        app.Run(window);
    }
}