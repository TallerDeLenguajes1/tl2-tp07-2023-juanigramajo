using Microsoft.AspNetCore.Mvc;

public class ManejoDeTareas{
    private AccesoADatos accesoADatos;
    
    public ManejoDeTareas(AccesoADatos accesoADatos){
        this.accesoADatos  = new AccesoADatos();
    }

    public bool AddTarea(Tarea tarea){

        var ListadoTareas = accesoADatos.LeerTareas();
        tarea.Id = ListadoTareas.Count + 1;
        ListadoTareas.Add(tarea);
        bool control = accesoADatos.Guardar(ListadoTareas);

        if (control)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public Tarea ObtenerTarea(int idTarea)
    {
        List<Tarea> ListadoTareas = accesoADatos.LeerTareas();
        Tarea tareaBuscar = ListadoTareas.FirstOrDefault(t => t.Id == idTarea);

        if (tareaBuscar != null)
        {
            return tareaBuscar;
        } else
        {
            return null;
        }
    }

    public bool ActualizarTarea(Tarea tareaModificar)
    {
        List<Tarea> ListadoTareas = accesoADatos.LeerTareas();
        Tarea tareaBuscar = ListadoTareas.FirstOrDefault(t => t.Id == tareaModificar.Id);
        ListadoTareas.Remove(tareaBuscar);
        tareaBuscar = tareaModificar;
        ListadoTareas.Insert(tareaBuscar.Id - 1, tareaBuscar);

        bool control = accesoADatos.Guardar(ListadoTareas);

        if (control)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public bool DeleteTarea(int idRemove){

        var ListadoTareas = accesoADatos.LeerTareas();
        var tarea = ListadoTareas.FirstOrDefault(t => t.Id == idRemove);

        if(tarea != null){

            var control = ListadoTareas.Remove(tarea);
            if(control)
            {
                accesoADatos.Guardar(ListadoTareas);
            }

            return true;
        }

        return false;
    }

    public List<Tarea> GetTareas()
    {
        return accesoADatos.LeerTareas();
    }

    public List<Tarea> GetTareasCompletadas()
    {
        List<Tarea> ListadoTareas = accesoADatos.LeerTareas();
        List<Tarea> ListadoTareasCompletadas = ListadoTareas.FindAll(t => t.estado == Estado.Completada);
        
        if (ListadoTareasCompletadas != null)
        {
            return ListadoTareasCompletadas;
        } else
        {
            return null;
        }
    }

    
}