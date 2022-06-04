namespace AppClinica.Entities;

public class HistoriaClinica
{
    public int codRegistro { get; set; }
    
    public int IdMascota { get; set; }
    public Mascota Mascota { get; set; }
    public DateTime FechaRegistro { get; set; }

    
}