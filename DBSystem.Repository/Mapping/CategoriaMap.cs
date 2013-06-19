using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DBSystem.Entities;

namespace DBSystem.Repository.Mapping
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.descripcion)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.comentario)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Categoria");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.descripcion).HasColumnName("descripcion");
            this.Property(t => t.comentario).HasColumnName("comentario");
        }
    }
}
