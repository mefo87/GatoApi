using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Donos;

public class DonoConfiguration : IEntityTypeConfiguration<Dono>
{
    public void Configure(EntityTypeBuilder<Dono> builder)
    { 
        builder.ToTable("Donos");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnType("varchar(300)");
        builder.Property(x => x.Cpf)
            .IsRequired()
            .HasColumnType("varchar(15)");
        builder.Property(x => x.Email)
            .HasColumnType("varchar(255)");
        builder.Property(x => x.Telefone)
            .HasColumnType("varchar(20)");
    }
}
