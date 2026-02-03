using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InformesRestaurante.Services;

namespace InformesRestaurante.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private N8NService n8nService = new();
    [ObservableProperty] private string url;
    [ObservableProperty] private bool seMuestraPDF = false;
    
    
    
    [RelayCommand]
    public void OcultarPDF()
    {
        SeMuestraPDF = false;
    }
}