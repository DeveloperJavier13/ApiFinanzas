namespace ApiFinanzas.Services;

public class EgresoService : IEgresoService
{
    FinanzasContext context;

    public EgresoService(FinanzasContext dbcontext)
    {
        context = dbcontext;
    }  

    public IEnumerable<Egresos> Get()
    {
        return context.Egresos;
    }

    public void Save(Egresos egr)
    {
        context.Add(egr);
        context.SaveChanges();
    }

    public void Update(Guid EgresoID, Egresos egr)
    {
        var egresoActual = context.Egresos.Find (EgresoID);
        if(egresoActual != null)
        {
            egresoActual.egreso = egr.egreso;
            egresoActual.registroEgr=egr.registroEgr;
            egresoActual.conceptoEgr=egr.conceptoEgr;
            
            context.Update(egresoActual);
            context.SaveChanges();
        }
    }

    public void Delete(Guid EgresoID)
    {
        var egresoActual = context.Egresos.Find(EgresoID);
        if(egresoActual != null)
        {
            context.Remove(egresoActual);
            context.SaveChanges();
        }
    }
    
}

public interface IEgresoService
{
    
    IEnumerable<Egresos> Get();
    void Save(Egresos egr);
    void Update(Guid EgresoID, Egresos egr);
    void Delete(Guid EgresoID);
}