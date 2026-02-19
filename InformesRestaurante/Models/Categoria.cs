using Newtonsoft.Json;

namespace InformesRestaurante.Models;

public class Categoria
{
    [JsonProperty("id_categoria", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Id { get; set; }
    
    [JsonProperty("nombre")]
    public string Nombre { get; set; }

    public override string ToString()
    {
        return Nombre;
    }
}