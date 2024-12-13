using Data.Donos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Gatos;

public class GatoConfiguration : IEntityTypeConfiguration<Gato>
{
    public void Configure(EntityTypeBuilder<Gato> builder)
    {
        builder.ToTable("Gatos");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnType("varchar(300)");
        builder.Property(x => x.Tipo)
            .IsRequired();
        builder.HasOne(x => x.Dono)
            .WithMany()
            .HasForeignKey(x => x.IdDono);
    }
}