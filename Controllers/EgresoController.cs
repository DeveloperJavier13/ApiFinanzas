using Microsoft.AspNetCore.Mvc;
using ApiFinanzas.Services;
 
namespace ApiFinanzas.Controllers;

[ApiController]
[Route("api/")]

public class EgresoController : ControllerBase
{
    IEgresoService egresoService;
    private readonly int records=5;
    public EgresoController(IEgresoService service)
    {
        egresoService = service;
    }

    [HttpGet("egreso/mostrar")]
    public IActionResult Get(int? page)
    {   
        var cont = egresoService.Get().Count();
        return Ok(egresoService.Get());        
    }
    
    [HttpPost]
    [Route ("egreso/crear")]
    public IActionResult Post([FromBody] Egresos egr)
    {        
        egresoService.Save(egr);
        return Ok("Guardado correcto del registro");
    }

    [HttpPut("egreso/actualizar/{id}")]
    [Route("egreso/actualizar")]
    public IActionResult Put(Guid id, [FromBody] Egresos egr)
    {        
        egresoService.Update(id, egr);
        return Ok("Registro actualizado correctamente");
    }

    [HttpDelete("egreso/borrar/{id}")]
    [Route("egreso/borrar")]
    public IActionResult Delete(Guid id)
    {
        egresoService.Delete(id);
        return Ok("Registro eliminado correctamente");
    }


    
}