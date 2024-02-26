using Microsoft.EntityFrameworkCore;
using ServiceRequisicaoCEP.Entities;

namespace ServiceRequisicaoCEP.Context
{
    public class RequisicaoCEPContext : DbContext
    {
        public RequisicaoCEPContext(DbContextOptions<RequisicaoCEPContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RequisicaoCepEntity>(new RequisicaoCepConfigure().Configure);
        }
    }
}
