namespace MandrilAPI.Models;

public class Habilidad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public EPotencia Potencia { get; set; }

    public enum EPotencia
    {
        Suave,
        Moderado,
        Intenso,
        RePotente,
        Extremo
    }

}
