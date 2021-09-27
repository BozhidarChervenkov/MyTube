namespace MyTube.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddAccountPictureToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountPictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountPictureUrl",
                table: "AspNetUsers");
        }
    }
}
