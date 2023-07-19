using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndTaskDb.Migrations
{
    public partial class AddMonsterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttackModifier = table.Column<int>(type: "int", nullable: false),
                    AttackPerRound = table.Column<int>(type: "int", nullable: false),
                    DamageDicesCount = table.Column<int>(type: "int", nullable: false),
                    DamageDiceType = table.Column<int>(type: "int", nullable: false),
                    WeaponModifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Monsters", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Monsters");
        }
    }
}
