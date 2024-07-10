using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace breakevenApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMedico = table.Column<long>(type: "bigint", nullable: false),
                    HoraInicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    HoraFim = table.Column<TimeOnly>(type: "time", nullable: false),
                    DiaDaSemana = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    IdEspecialidade = table.Column<long>(type: "bigint", nullable: false),
                    IdPaciente = table.Column<long>(type: "bigint", nullable: false),
                    IdMedico = table.Column<long>(type: "bigint", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    IdDiagnostico = table.Column<long>(type: "bigint", nullable: false),
                    HoraInicioConsulta = table.Column<TimeOnly>(type: "time", nullable: false),
                    HoraFimConsulta = table.Column<TimeOnly>(type: "time", nullable: false),
                    Paga = table.Column<bool>(type: "bit", nullable: false),
                    FormaPagamento = table.Column<int>(type: "int", nullable: true),
                    ValorPagamento = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => new { x.IdEspecialidade, x.IdPaciente, x.IdMedico, x.Data });
                });

            migrationBuilder.CreateTable(
                name: "Diagnostica",
                columns: table => new
                {
                    IdDiagnostico = table.Column<long>(type: "bigint", nullable: false),
                    IdDoenca = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostica", x => new { x.IdDiagnostico, x.IdDoenca });
                });

            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                columns: table => new
                {
                    DiagnosticoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemediosReceitados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TratamentosRecomendados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdConsulta = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.DiagnosticoId);
                });

            migrationBuilder.CreateTable(
                name: "Doencas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doencas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<long>(type: "bigint", nullable: false),
                    Indice = table.Column<int>(type: "int", nullable: false),
                    NomeEspecialidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerceEsp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEsp = table.Column<long>(type: "bigint", nullable: false),
                    IdMedico = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerceEsp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricosPacientes",
                columns: table => new
                {
                    IdPaciente = table.Column<long>(type: "bigint", nullable: false),
                    IdConsulta = table.Column<long>(type: "bigint", nullable: false),
                    Doenca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataConsulta = table.Column<DateOnly>(type: "date", nullable: false),
                    NomeMedico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricosPacientes", x => new { x.IdPaciente, x.IdConsulta });
                });

            migrationBuilder.CreateTable(
                name: "Medics",
                columns: table => new
                {
                    MedicId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Crm = table.Column<long>(type: "bigint", nullable: false),
                    Percentual = table.Column<double>(type: "float", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeMedico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medics", x => x.MedicId);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    CodigoPaciente = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NomePaciente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.CodigoPaciente);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Diagnostica");

            migrationBuilder.DropTable(
                name: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Doencas");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "ExerceEsp");

            migrationBuilder.DropTable(
                name: "HistoricosPacientes");

            migrationBuilder.DropTable(
                name: "Medics");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
