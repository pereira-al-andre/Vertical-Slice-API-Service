using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.API.Entities;

namespace Service.API.Persistence.Mappings
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<GetProdutResponse> e)
        {
            e.ToTable("Products");

            e.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(50)");

            e.Property(x => x.Price)
                .HasColumnName("Price")
                .HasColumnType("numeric(5,2)");
        }
    }
}
