using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Gatos.GatoFotos;

public class GatoFotoConfiguration : IEntityTypeConfiguration<GatoFoto>
{
    public void Configure(EntityTypeBuilder<GatoFoto> builder)
    {
        builder.ToTable("GatoFotos");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Url)
            .IsRequired()
            .HasColumnType("varchar(500)");
        
        builder.HasOne(x => x.Gato)
            .WithMany()
            .HasForeignKey(x => x.IdGato);
    }
}