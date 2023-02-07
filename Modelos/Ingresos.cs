namespace ApiFinanzas
{
    public class Ingresos
    {
        public Guid IngresoID{get;set;}
        public string conceptoIng{get;set;}
        public float ingreso{get;set;}
        public DateTime registroIng{get;set;}
    }
}