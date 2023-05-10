using EF7.API.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EF7.API.Configuraciones
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(g => g.FechaNacimiento).HasColumnType("date");
            builder.Property(g => g.Fortuna).HasPrecision(18, 2);
        }
    }
}
