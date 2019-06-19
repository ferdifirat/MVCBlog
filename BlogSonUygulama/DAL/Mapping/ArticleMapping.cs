using DATA.Model_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class ArticleMapping : EntityTypeConfiguration<Article>
    {
        public ArticleMapping()
        {
            ToTable("Makale");

            HasKey(x => x.ArticleID);

            Property(x => x.CategoryID).IsRequired();
            Property(x => x.MemberID).IsRequired();
            Property(x => x.Title).IsRequired().HasMaxLength(100);
            Property(x => x.Content).IsRequired().HasMaxLength(1000);
            Property(x => x.Picture).IsRequired();
            Property(x => x.CreationDate).HasColumnType("datetime2").IsOptional();
            Property(x => x.Voting).IsRequired();

            HasRequired(x => x.Category).WithMany(x => x.Articles).HasForeignKey(x => x.CategoryID);



        }
    }
}