using Newtonsoft.Json;

namespace InformesRestaurante.Models;

public class Empleado
{
    [JsonProperty("id_empleado", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Id { get; set; }
    
    [JsonProperty("nombre")]
    public string Nombre { get; set; }

    public override string ToString()
    {
        return Nombre;
    }
}