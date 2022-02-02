using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedbaseAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionMain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerA = table.Column<bool>(type: "bit", nullable: true),
                    AnswerB = table.Column<bool>(type: "bit", nullable: true),
                    AnswerC = table.Column<bool>(type: "bit", nullable: true),
                    AnswerD = table.Column<bool>(type: "bit", nullable: true),
                    AnswerE = table.Column<bool>(type: "bit", nullable: true),
                    TopicId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TopicId",
                table: "Questions",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
