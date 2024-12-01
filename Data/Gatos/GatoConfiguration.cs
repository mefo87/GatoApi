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
        builder.Property(x => x.Nome);
        builder.Property(x => x.Tipo);

        builder.HasOne(x => x.Dono)
            .WithMany()
            .HasForeignKey(x => x.IdDono);
    }
}