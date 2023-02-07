using Microsoft.EntityFrameworkCore;
namespace ApiFinanzas
{
    public class FinanzasContext: DbContext
    {
        public DbSet<Ingresos> Ingresos { get; set; }
        public DbSet<Egresos> Egresos { get; set; }

        public FinanzasContext(DbContextOptions<FinanzasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ingresos
            List<Ingresos> ingresoInit = new List<Ingresos>();
             ingresoInit.Add(new Ingresos { 
                IngresoID = Guid.Parse("e2a2a013-09ce-4446-bfc1-3aacab502763"),
                conceptoIng="Proyecto Api",
                ingreso = 1500.0f,
                registroIng=DateTime.Now,
            });
            ingresoInit.Add(new Ingresos { 
                IngresoID = Guid.Parse("e2a2a013-09ce-4446-bfc1-3aacab502765"),
                conceptoIng="Realziación de EF",
                ingreso = 2000.0f,
                registroIng=DateTime.Now,
            });
            #endregion

            #region egresos
            List<Egresos> egresoInit = new List<Egresos>();
            egresoInit.Add(new Egresos { 
                EgresoID = Guid.Parse("e2a2a013-09ce-4446-bfc1-3aacab502764"),
                conceptoEgr="Pago internet",
                egreso = 1500.0f,
                registroEgr=DateTime.Now,
            });
            #endregion

            modelBuilder.Entity<Ingresos>(ing =>
            {
                ing.ToTable("Ingresos");
                // Clave primaria
                ing.HasKey(p => p.IngresoID);
                ing.Property(p=>p.conceptoIng).IsRequired();
                ing.Property(p=>p.registroIng).IsRequired();

                // Atributos
                ing.Property(p => p.ingreso).IsRequired();

                // Para agregar datos iniciales a la tabla Categoria se usa la funcion HasData
                // recibiendo como parametro una lista de datos de Categorias
                ing.HasData(ingresoInit);
            });

            modelBuilder.Entity<Egresos>(egr =>
            {
                egr.ToTable("Egresos");
                // Clave primaria
                egr.HasKey(p => p.EgresoID);

                // Atributos
                egr.Property(p=>p.conceptoEgr).IsRequired();
                egr.Property(p => p.egreso).IsRequired();
                egr.Property(p=> p.registroEgr).IsRequired();  

                // Para agregar datos iniciales a la tabla Categoria se usa la funcion HasData
                // recibiendo como parametro una lista de datos de Categorias
                egr.HasData(egresoInit);
            });


        }

    }
}