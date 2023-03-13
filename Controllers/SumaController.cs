using Microsoft.AspNetCore.Mvc;
using ApiFinanzas.Services;
 
namespace ApiFinanzas.Controllers;

[ApiController]
[Route("api/")]

public class SumaController : ControllerBase
{
    IEgresoService egresoService;
    IIngresoService ingresoService;

    public SumaController(IEgresoService eservice, IIngresoService iservice)
    {
        egresoService = eservice;
        ingresoService=iservice;
    }
    
    [HttpGet]
    [Route("suma/total")]
    public IActionResult Get(){
        var i=ingresoService.Get().Sum(x=>x.ingreso);
        var e=egresoService.Get().Sum(x=>x.egreso);
        
        return Ok($"La suma total de los gastos es: {i-e}");
        
    }
}