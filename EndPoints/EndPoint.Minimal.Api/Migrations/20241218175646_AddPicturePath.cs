using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EndPoint.Minimal.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPicturePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Actors",
                newName: "PictureName");

            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "Actors");

            migrationBuilder.RenameColumn(
                name: "PictureName",
                table: "Actors",
                newName: "Picture");
        }
    }
}
