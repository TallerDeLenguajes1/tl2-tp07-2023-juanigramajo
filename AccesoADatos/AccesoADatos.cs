using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

public class AccesoADatos
{
    public List<Tarea> LeerTareas()
    {
        string filePath = "tareas.json";
        
        try
        {
            // Lee el contenido del archivo JSON y deserialízalo en una lista de cadetes.
            string Json = File.ReadAllText(filePath);
            List<Tarea> Tareas = JsonSerializer.Deserialize<List<Tarea>>(Json);
            return Tareas;
        }
        catch (IOException e)
        {
            // Console.WriteLine($"Error al leer el archivo: {e.Message}");
        }
    
        // Return an empty list if any errors occurred
        return new List<Tarea>();
    }

    public bool Guardar(List<Tarea> Tareas)
    {
        if (Tareas != null)
        {
            string ListadoTareasJson = JsonSerializer.Serialize(Tareas);
            File.WriteAllText("Tareas.json", ListadoTareasJson);

            if (ListadoTareasJson != null)
            {
                return true;
            } else
            {
                return false;
            }
        } else
        {
            return false;
        }
    }
}
    