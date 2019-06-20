using DATA.Model_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class ArticleTagMapping : EntityTypeConfiguration<ArticleTag>
    {
        public ArticleTagMapping()
        {
            ToTable("MakaleEtiket");

            HasRequired(x => x.Article).WithMany(x => x.ArticleTags).HasForeignKey(x => x.ArticleID);
            HasRequired(x => x.Tag).WithMany(x => x.ArticleTags).HasForeignKey(x => x.TagID);

        }

    }
}
