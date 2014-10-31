using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity.ModelConfiguration;
using MedTech.Core.Domain.TextResources;

namespace MedTech.Infrastructure.Mapping.TextResources
{
    public class TextResourceMap : EntityTypeConfiguration<TextResource>
    {
        public TextResourceMap()
        {
            this.ToTable("TextResource");
            this.Property(tr => tr.Key).IsRequired().HasMaxLength(128);
            this.Property(tr => tr.Value).IsRequired().HasMaxLength(128);

        }
    }
}
