namespace ApiFinanzas.Services;

public class IngresoService : IIngresoService
{
    FinanzasContext context;

    public IngresoService(FinanzasContext dbcontext)
    {
        context = dbcontext;
    }  

    public IEnumerable<Ingresos> Get()
    {
        return context.Ingresos;
    }

    public void Save(Ingresos ing)
    {
        context.Add(ing);
        context.SaveChanges();
    }

    public void Update(Guid IngresoID, Ingresos ing)
    {
        var ingresoActual = context.Ingresos.Find (IngresoID);
        if(ingresoActual != null)
        {
            ingresoActual.ingreso = ing.ingreso;
            ingresoActual.registroIng=ing.registroIng;
            ingresoActual.conceptoIng=ing.conceptoIng;
            
            context.Update(ingresoActual);
            context.SaveChanges();
        }
    }

    public void Delete(Guid IngresoID)
    {
        var ingresoActual = context.Ingresos.Find(IngresoID);
        if(ingresoActual != null)
        {
            context.Remove(ingresoActual);
            context.SaveChanges();
        }
    }
    
}

public interface IIngresoService
{
    IEnumerable<Ingresos> Get();
    void Save(Ingresos ing);
    void Update(Guid IngresoID, Ingresos ing);
    void Delete(Guid IngresoID);
}