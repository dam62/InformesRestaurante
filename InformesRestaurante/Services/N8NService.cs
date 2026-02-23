using System;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Collections;
using InformesRestaurante.Models;
using Newtonsoft.Json;

namespace InformesRestaurante.Services;

public class N8NService
{
    private HttpClient client;

    public N8NService()
    {
        client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5678/webhook/");
    }
    
    public async Task<AvaloniaList<string>?> ObtenerCategoriaPlatos()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "categoriaPlatos");
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<string>>(listaString);
    }
    
    public async Task<AvaloniaList<Empleado>?> ObtenerEmpleadosFiltrados(string filter)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "cb8da4c8-6382-4364-bc13-89772907bd17/empleados/"+filter);
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<Empleado>>(listaString);
    }
}