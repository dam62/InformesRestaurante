using System;
using System.Threading.Tasks;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InformesRestaurante.Services;

namespace InformesRestaurante.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private N8NService n8nService = new();
    [ObservableProperty] private string url;
    [ObservableProperty] private bool seMuestraPDF = false;
    
    [ObservableProperty] private AvaloniaList<String>? listaCategorias = new();
    [ObservableProperty] private DateTimeOffset fechaInicio = new(DateTime.Now);
    [ObservableProperty] private DateTimeOffset fechaFinal = new(DateTime.Now);
    
    [RelayCommand]
    public async Task CargarDesplegablesAsync()
    {
        ListaCategorias = await n8nService.ObtenerCategoriasPlatos();
    }

    [RelayCommand]
    public void GenerarPDFReservaAsync(string id)
    {
        Url = "localhost:10000/eriRestaurant/informeReserva/" + id;
        SeMuestraPDF = true;
    }
    
    [RelayCommand]
    public async Task GenerarPDFCategoriaPlatoAsync(string categoria)
    {
        if (categoria != null)
        {
            Url = "http://localhost:9876/reports/getplatosCategoria/"+categoria+"/"+
                  FechaInicio.ToString("yyyy-MM-dd")+"/"+
                  FechaFinal.ToString("yyyy-MM-dd");
        }
    }
    
    [RelayCommand]
    public void OcultarPDF()
    {
        SeMuestraPDF = false;
    }
}