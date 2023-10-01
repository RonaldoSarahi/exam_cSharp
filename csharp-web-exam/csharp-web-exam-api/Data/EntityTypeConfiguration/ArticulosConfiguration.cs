using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using csharp_api.Models;

namespace csharp_api.Data.EntityTypeConfiguration
{
    public class ArticulosConfiguration : IEntityTypeConfiguration<Articulos>
    {
        public void Configure(EntityTypeBuilder<Articulos> builder)
        {
            builder.HasKey(a => a.Articulo);
        }
    }
}