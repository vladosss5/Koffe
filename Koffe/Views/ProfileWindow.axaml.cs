using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Koffe.ViewModels;

namespace Koffe.Views;

public partial class ProfileWindow : Window
{
    public ProfileWindow()
    {
        DataContext = new Profile();
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