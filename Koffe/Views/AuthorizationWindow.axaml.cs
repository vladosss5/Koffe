using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Koffe.ViewModels;

namespace Koffe.Views;

public partial class AuthorizationWindow : Window
{
    public AuthorizationWindow()
    {
        DataContext = new Authorization();
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}