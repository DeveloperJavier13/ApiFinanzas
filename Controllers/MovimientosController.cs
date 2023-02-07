using Microsoft.AspNetCore.Mvc;
using ApiFinanzas.Services;
using System.Linq;

namespace ApiFinanzas.Controllers;

[ApiController]
[Route("api/")]

public class MovimientosController : ControllerBase
{
    IEgresoService egresoService;
    IIngresoService ingresoService;
    private readonly int records=5;

    public MovimientosController(IEgresoService eservice, IIngresoService iservice)
    {
        egresoService = eservice;
        ingresoService=iservice;
    }

    [HttpGet("movimiento/egreso")]
    public IActionResult Get(int? page){
        int _page=page??1;
        decimal filas =  egresoService.Get().Count(); 
        int total_page=Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(filas/records)));

        var e= egresoService.Get().Skip((_page -1)*records).Take(records).ToList();
        return Ok(new{
            pages=total_page,
            records=e,
            currentpage=_page
        });       
    }
    
    [HttpGet("movimiento/ingreso")]
    public IActionResult get(int? page){
        int _page=page??1;
        decimal filas =  ingresoService.Get().Count(); 
        int total_page=Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(filas/records)));
        var i =ingresoService.Get().Skip((_page -1)*records).Take(records).ToList();

        return Ok(new{
            pages=total_page,
            records=i,
            currentpage=_page
        });       
    }
}