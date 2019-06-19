using DATA.Model_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {

        public CategoryMapping()
        {
            ToTable("Kategori");
            HasKey(x => x.CategoryID);

            Property(x => x.CategoryName).IsRequired().HasMaxLength(50);
        }
    }
}