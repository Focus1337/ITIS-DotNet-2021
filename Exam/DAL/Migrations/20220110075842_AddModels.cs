using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    AttackModifier = table.Column<int>(type: "int", nullable: false),
                    DamageModifier = table.Column<int>(type: "int", nullable: false),
                    DamageDiceCount = table.Column<int>(type: "int", nullable: false),
                    DamageDiceEdges = table.Column<int>(type: "int", nullable: false),
                    ArmourClass = table.Column<int>(type: "int", nullable: false),
                    AttackPerRound = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    AttackModifier = table.Column<int>(type: "int", nullable: false),
                    DamageModifier = table.Column<int>(type: "int", nullable: false),
                    DamageDiceCount = table.Column<int>(type: "int", nullable: false),
                    DamageDiceEdges = table.Column<int>(type: "int", nullable: false),
                    ArmourClass = table.Column<int>(type: "int", nullable: false),
                    AttackPerRound = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Monsters");
        }
    }
}
