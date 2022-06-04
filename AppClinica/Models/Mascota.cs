namespace AppClinica.Entities;

public class Mascota
{
    public int ID { get; set; }
    public int IdDueño { get; set; }
    public Dueños  Dueño { get; set; }
    public string NombreMascota { get; set; }
    public DateTime FechaNacimiento{ get; set; }
    public string SexoMascota { get; set; }
    public string Especie { get; set; }
    public string Raza { get; set; }
    public string Tamaño { get; set; }
    public string DatosParticulares { get; set; }
}