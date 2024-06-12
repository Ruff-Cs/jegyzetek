using jegyzetek.ViewModels;

namespace jegyzetek.Views;

public partial class FormPage : ContentPage
{
    public FormPage(FormViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}