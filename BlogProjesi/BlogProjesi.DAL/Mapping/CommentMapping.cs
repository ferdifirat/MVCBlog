using BlogProje.DATA.Model_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjesi.DAL.Mapping
{
    public class CommentMapping : EntityTypeConfiguration<Comment>
    {
        public CommentMapping()
        {
            ToTable("Yorum");
            HasKey(x => x.CommentID);

            Property(x => x.Content).IsRequired().HasMaxLength(50);
            Property(x => x.MemberID).IsRequired();
            Property(x => x.ArticleID).IsRequired();
            Property(x => x.CommentDate).HasColumnType("datetime2").IsOptional();
            

        }
    }
}
