namespace Gestion_Projet_App.Models.Entity;

public class Client : ModelBase
{
    public string Name { get; set; }
    public string? Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public ICollection<Projet>? Projects { get; set; }
}
