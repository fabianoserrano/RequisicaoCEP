using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceRequisicaoCEP.Entities;

namespace ServiceRequisicaoCEP.Context
{
    public class RequisicaoCepConfigure : IEntityTypeConfiguration<RequisicaoCepEntity>
    {
        public void Configure(EntityTypeBuilder<RequisicaoCepEntity> builder)
        {
            builder.ToTable("RequisicaoCep");

            builder.HasKey(u => u.Id);
        }
    }
}
