using System;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Collections;
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
    
    public async Task<AvaloniaList<string>?> ObtenerCategoriasPlatos()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "categorias");
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<string>>(listaString);
    }
}