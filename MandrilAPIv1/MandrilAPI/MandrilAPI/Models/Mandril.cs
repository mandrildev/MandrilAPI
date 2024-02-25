namespace MandrilAPI.Models;

public class Mandril
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Apellido { get; set; } = string.Empty;

    public List<Habilidad>? Habilidades { get; set; } = new List<Habilidad>();

}
