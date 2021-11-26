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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // Primary key definition and identity
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();

            
            builder.Property(x => x.Text).IsRequired().HasMaxLength(200);
        }
    }
}
