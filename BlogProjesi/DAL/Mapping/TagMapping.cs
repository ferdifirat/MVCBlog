using DATA.Model_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class TagMapping : EntityTypeConfiguration<Tag>
    {
        public TagMapping()
        {
            ToTable("Etiket");

            HasKey(x => x.TagID);
            Property(x => x.TagName).IsRequired().HasMaxLength(50);
        }
    }
}
