using Microsoft.AspNetCore.Mvc;
using ApiFinanzas.Services;

namespace ApiFinanzas.Controllers;

[ApiController]
[Route("api/")]

public class IngresoController : ControllerBase
{
    IIngresoService ingresoService;
    private readonly int records=5;

     public IngresoController(IIngresoService service)
    {
        ingresoService = service;
    }

    [HttpGet("ingreso/mostrar")]
    public IActionResult Get(int? page)
    {
        var cont = ingresoService.Get().Count();
        return Ok(ingresoService.Get());        
    }
    
    [HttpPost]
    [Route("ingreso/crear")]
    public IActionResult Post([FromBody] Ingresos ing)
    {        
        ingresoService.Save(ing);
        return Ok("Guardado correcto del registro");
    }

    [HttpPut("ingreso/actualizar/{id}")]
    [Route("ingreso/actualizar")]
    public IActionResult Put(Guid id, [FromBody] Ingresos ing)
    {        
        ingresoService.Update(id, ing);
        return Ok("Actualización completa");
    }

    [HttpDelete("ingreso/borrar/{id}")]
    [Route("ingreso/borrar")]
    public IActionResult Delete(Guid id)
    {        
        ingresoService.Delete(id);
        return Ok("Eliminación correcta del registro");
    }

        
}