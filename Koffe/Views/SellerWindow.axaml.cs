using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Koffe.ViewModels;

namespace Koffe.Views;

public partial class SellerWindow : Window
{
    public SellerWindow()
    {
        DataContext = new Seller();
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