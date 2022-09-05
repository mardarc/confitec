using Confitec.Data.EF.EntityConfiguration;
using Confitec.Dominio;
using Microsoft.EntityFrameworkCore;
using System;

namespace Confitec.Data.EF
{
    public class ConfitecContext : DbContext
    {
        public ConfitecContext(DbContextOptions<ConfitecContext> options) : base(options) { }

        protected void ConfigureDatabaseMappings(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
        }

        #region DBSets
        public DbSet<Usuario> Usuarios { get; set; }
        #endregion
    }
}