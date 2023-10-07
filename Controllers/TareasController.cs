using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase
{
    private ManejoDeTareas manejoDeTareas;
    private readonly ILogger<TareasController> _logger;

    public TareasController(ILogger<TareasController> logger)
    {
        _logger = logger;
        AccesoADatos accesoADatos = new AccesoADatos();
        manejoDeTareas = new ManejoDeTareas(accesoADatos);
    }

    [HttpPost("AddTarea")]
    public ActionResult<Tarea> AddTarea(Tarea tarea)
    {
        bool controlExito = manejoDeTareas.AddTarea(tarea);

        if (controlExito)
        {
            return Ok(tarea);
        } else
        {
            return BadRequest();
        }
    }

    [HttpGet("ObtenerTarea")]
    public ActionResult<Tarea> ObtenerTarea(int idTarea)
    {
        Tarea tareaBuscar = manejoDeTareas.ObtenerTarea(idTarea);

        if (tareaBuscar != null)
        {
            return Ok(tareaBuscar);
        } else
        {
            return BadRequest();
        }
    }

    [HttpPut("ActualizarTarea")]
    public ActionResult<Tarea> ActualizarTarea(Tarea tareaModificada)
    {
        bool control = manejoDeTareas.ActualizarTarea(tareaModificada);

        if (control)
        {
            return Ok(tareaModificada);
        } else
        {
            return BadRequest();
        }
    }   

    [HttpPost("EliminarTarea")]
    public ActionResult<Tarea> EliminarTarea(int idTarea)
    {
        bool control = manejoDeTareas.DeleteTarea(idTarea);
        
        if (control)
        {
            return Ok();
        } else
        {
            return BadRequest();
        }
    }

    [HttpGet("GetTareas")]
    public ActionResult<List<Tarea>> GetTareas()
    {
        List<Tarea> ListadoTareas = manejoDeTareas.GetTareas();

        if (ListadoTareas != null)
        {
            return Ok(ListadoTareas);
        } else
        {
            return BadRequest();
        }

    }

    [HttpGet("GetTareasCompletadas")]
    public ActionResult<List<Tarea>> GetTareasCompletadas()
    {
        List<Tarea> ListadoTareasCompletadas = manejoDeTareas.GetTareasCompletadas();

        if (ListadoTareasCompletadas != null)
        {
            return Ok(ListadoTareasCompletadas);
        } else
        {
            return BadRequest();
        }
    }

}