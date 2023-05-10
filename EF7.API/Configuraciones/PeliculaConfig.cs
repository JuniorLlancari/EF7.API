using EF7.API.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EF7.API.Configuraciones
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.Property(a => a.Titulo).HasDefaultValue("");

            builder.Property(a => a.FechaEstreno).HasColumnType("date").HasDefaultValue(DateTime.Now);
            builder.Property(a => a.EnCines)
                .IsRequired(true).HasDefaultValue(true);

        }
    }

}
