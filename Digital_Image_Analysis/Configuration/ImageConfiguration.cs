using Digital_Image_Analysis.Data;
using Digital_Image_Analysis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digital_Image_Analysis.Configuration
{
    
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Property(x => x.UploadDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.FileName).HasMaxLength(512);          
        }
    }
}
