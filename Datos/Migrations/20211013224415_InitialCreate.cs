using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medicamentos",
                columns: table => new
                {
                    CodigoMedicamento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instrucciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamentos", x => x.CodigoMedicamento);
                });

            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    Identification = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.Identification);
                });

            migrationBuilder.CreateTable(
                name: "tratamientos",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Recomendacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tratamientos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "pacientes",
                columns: table => new
                {
                    CodigoPaciente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonaIdentification = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pacientes", x => x.CodigoPaciente);
                    table.ForeignKey(
                        name: "FK_pacientes_personas_PersonaIdentification",
                        column: x => x.PersonaIdentification,
                        principalTable: "personas",
                        principalColumn: "Identification",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "psicologos",
                columns: table => new
                {
                    CodigoPsicologo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonaIdentification = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Salario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_psicologos", x => x.CodigoPsicologo);
                    table.ForeignKey(
                        name: "FK_psicologos_personas_PersonaIdentification",
                        column: x => x.PersonaIdentification,
                        principalTable: "personas",
                        principalColumn: "Identification",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "historiales",
                columns: table => new
                {
                    CodigoHistorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteCodigoPaciente = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historiales", x => x.CodigoHistorial);
                    table.ForeignKey(
                        name: "FK_historiales_pacientes_PacienteCodigoPaciente",
                        column: x => x.PacienteCodigoPaciente,
                        principalTable: "pacientes",
                        principalColumn: "CodigoPaciente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "citas",
                columns: table => new
                {
                    CodigoCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacienteCodigoPaciente = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PsicologoCodigoPsicologo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citas", x => x.CodigoCita);
                    table.ForeignKey(
                        name: "FK_citas_pacientes_PacienteCodigoPaciente",
                        column: x => x.PacienteCodigoPaciente,
                        principalTable: "pacientes",
                        principalColumn: "CodigoPaciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_citas_psicologos_PsicologoCodigoPsicologo",
                        column: x => x.PsicologoCodigoPsicologo,
                        principalTable: "psicologos",
                        principalColumn: "CodigoPsicologo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_citas_PacienteCodigoPaciente",
                table: "citas",
                column: "PacienteCodigoPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_citas_PsicologoCodigoPsicologo",
                table: "citas",
                column: "PsicologoCodigoPsicologo");

            migrationBuilder.CreateIndex(
                name: "IX_historiales_PacienteCodigoPaciente",
                table: "historiales",
                column: "PacienteCodigoPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_pacientes_PersonaIdentification",
                table: "pacientes",
                column: "PersonaIdentification");

            migrationBuilder.CreateIndex(
                name: "IX_psicologos_PersonaIdentification",
                table: "psicologos",
                column: "PersonaIdentification");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "citas");

            migrationBuilder.DropTable(
                name: "historiales");

            migrationBuilder.DropTable(
                name: "medicamentos");

            migrationBuilder.DropTable(
                name: "tratamientos");

            migrationBuilder.DropTable(
                name: "psicologos");

            migrationBuilder.DropTable(
                name: "pacientes");

            migrationBuilder.DropTable(
                name: "personas");
        }
    }
}
