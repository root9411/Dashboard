using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackcofferAssigment.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "registrations",
                columns: table => new
                {
                    Userid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uemail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pwd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPwd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MartialStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registrations", x => x.Userid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registrations");
        }
    }
}
