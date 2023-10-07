using Microsoft.AspNetCore.Mvc;

public enum Estado
    {
        Pendiente, 
        EnProgreso, 
        Completada
    }

public class Tarea
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public Estado estado { get; set; }

    private static Tarea tareaSingleton;
    public static Tarea GetTarea()
    {
        if (tareaSingleton == null)
        {
            tareaSingleton = new Tarea("tareaEjemplo");
        }

        return tareaSingleton;
    }

    public Tarea(){

    }

    public Tarea(string tittle){
        this.Id = 0;
        this.Titulo = tittle;
        this.Descripcion = "descripción";
        this.estado = 0;
    }
}