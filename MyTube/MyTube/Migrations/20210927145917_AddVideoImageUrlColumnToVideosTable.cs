namespace MyTube.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddVideoImageUrlColumnToVideosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoImageUrl",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoImageUrl",
                table: "Videos");
        }
    }
}
