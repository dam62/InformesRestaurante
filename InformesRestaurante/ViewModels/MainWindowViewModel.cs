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
    [ObservableProperty] private DateTimeOffset fechaInicio = new(DateTime.Now);
    [ObservableProperty] private DateTimeOffset fechaFinal = new(DateTime.Now);
    
    [ObservableProperty] private AvaloniaList<Empleado>? listaEmpleados = new();
    [ObservableProperty] private string filtro = string.Empty;
    
    [ObservableProperty] private AvaloniaList<String>? listaPuestos = new();
    
    [ObservableProperty] private DateTimeOffset fecha1 = new(DateTime.Now);
    [ObservableProperty] private DateTimeOffset fecha2 = new(DateTime.Now);

    public MainWindowViewModel()
    {
    }
    
    [RelayCommand]
    public async Task CargarDesplegablesAsync()
    {
        ListaCategorias = await n8nService.ObtenerCategoriaPlatos();
        ListaPuestos = await n8nService.ObtenerEmpleadosPuestos();
    }
    
    [RelayCommand]
    public async Task ObtenerEmpleadosPorFiltroAsync()
    {
        if (!string.IsNullOrWhiteSpace(Filtro))
        {
            ListaEmpleados = await n8nService.ObtenerEmpleadosFiltrados(Filtro);
        }
    }

    [RelayCommand]
    public async Task GenerarPDFReservaAsync(string id)
    {
        Url = "http://localhost:10000/erciRestaurant/informeReserva/" + id;
        SeMuestraPDF = true;
    }
    
    [RelayCommand]
    public async Task GenerarPDFCategoriaPlatoAsync(string categoria)
    {
        Url = "http://localhost:10000/erciRestaurant/getPlatosCategoria/"+categoria+"/"+
              FechaInicio.ToString("yyyy-MM-dd")+"/"+
              FechaFinal.ToString("yyyy-MM-dd");
        SeMuestraPDF = true;
    }
    
    [RelayCommand]
    public async Task GenerarPDFPedidosEmpleadosAsync()
    {
        Url = "http://localhost:10000/erciRestaurant/pedidosEmpleado";
        SeMuestraPDF = true;
    }
    
    [RelayCommand]
    public async Task GenerarPDFReservaCapacidadAsync(string cap)
    {
        Url = "http://localhost:10000/erciRestaurant/getReservaCapacidad/" + cap;
        SeMuestraPDF = true;
    }
    
    [RelayCommand]
    public async Task MostrarPDFEmpleadosAsync(Empleado empleado)
    {
        Url = "http://localhost:10000/erciRestaurant/getEmpleadoPlato/"+empleado.Id;
        SeMuestraPDF = true;
    }
    
    [RelayCommand]
    public async Task GenerarEmpleadosPuestoAsync(string puesto)
    {
        Url = "http://localhost:10000/erciRestaurant/getEmpleadoPuesto/"+puesto;
        SeMuestraPDF = true;
    }
    
    [RelayCommand]
    public async Task GenerarVentasPorCategoriaAsync()
    {
        Url = "http://localhost:10000/erciRestaurant/getVentasCategoria/"+
              Fecha1.ToString("yyyy-MM-dd")+"/"+
              Fecha2.ToString("yyyy-MM-dd");
        SeMuestraPDF = true;
    }
    
    [RelayCommand]
    public async Task GenerarVentasEmpleadosAsync()
    {
        Url = "http://localhost:10000/erciRestaurant/ventasEmpleado";
        SeMuestraPDF = true;
    }
    
    [RelayCommand]
    public void OcultarPdf()
    {
        SeMuestraPDF = false;
    }
}