using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Data.Configurations
{

    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            // Primary key definition and identity
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
