using System;
using System.Threading.Tasks;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InformesRestaurante.Models;
using InformesRestaurante.Services;

namespace InformesRestaurante.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private N8NService n8nService = new();
    [ObservableProperty] private string url;
    [ObservableProperty] private bool seMuestraPDF = false;
    
    [ObservableProperty] private AvaloniaList<String>? listaCategorias = new();
    [ObservableProperty] private Categoria categoria = new();
    [ObservableProperty] private DateTimeOffset fechaInicio = new(DateTime.Now);
    [ObservableProperty] private DateTimeOffset fechaFinal = new(DateTime.Now);
    
    [RelayCommand]
    public async Task CargarDesplegablesAsync()
    {
        ListaCategorias = await n8nService.ObtenerCategoriasPlatos();
    }

    [RelayCommand]
    public void GenerarPDFReserva(string id)
    {
        Url = "localhost:10000/eriRestaurant/informeReserva/" + id;
        SeMuestraPDF = true;
    }
    
    [RelayCommand]
    public async Task GenerarPDFCategoriaPlatoAsync()
    {
        Url = "http://localhost:10000/eriRestaurant/getplatosCategoria/"+Categoria+"/"+
              FechaInicio.ToString("yyyy-MM-dd")+"/"+
              FechaFinal.ToString("yyyy-MM-dd");
    }
    
    [RelayCommand]
    public void OcultarPDF()
    {
        SeMuestraPDF = false;
    }
}