using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.DataAccess.Migrations.MyBlogDb
{
    public partial class updateCategoryTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentCategoryId",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "ParentCategoryId",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
