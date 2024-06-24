﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using breakevenApi.Infraestructre;

#nullable disable

namespace breakevenApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240621195748_migration1")]
    partial class migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("breakevenApi.Domain.Entities.Agenda.Agenda", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("DiaDaSemana")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("HoraFim")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("HoraInicio")
                        .HasColumnType("time");

                    b.Property<long>("IdMedico")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("breakevenApi.Domain.Entities.Consulta.Consulta", b =>
                {
                    b.Property<long>("IdEspecialidade")
                        .HasColumnType("bigint");

                    b.Property<long>("IdPaciente")
                        .HasColumnType("bigint");

                    b.Property<long>("IdMedico")
                        .HasColumnType("bigint");

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.Property<int?>("FormaPagamento")
                        .HasColumnType("int");

                    b.Property<DateTime>("HoraFimConsulta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraInicioConsulta")
                        .HasColumnType("datetime2");

                    b.Property<long>("IdDiagnostico")
                        .HasColumnType("bigint");

                    b.Property<bool>("Paga")
                        .HasColumnType("bit");

                    b.Property<float?>("ValorPagamento")
                        .HasColumnType("real");

                    b.HasKey("IdEspecialidade", "IdPaciente", "IdMedico", "Data");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("breakevenApi.Domain.Entities.Diagnostica.Diagnostica", b =>
                {
                    b.Property<long>("IdDiagnostico")
                        .HasColumnType("bigint");

                    b.Property<long>("IdDoenca")
                        .HasColumnType("bigint");

                    b.HasKey("IdDiagnostico", "IdDoenca");

                    b.ToTable("Diagnostica");
                });

            modelBuilder.Entity("breakevenApi.Domain.Entities.Diagnostico.Diagnostico", b =>
                {
                    b.Property<long>("DiagnosticoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DiagnosticoId"));

                    b.Property<long>("IdConsulta")
                        .HasColumnType("bigint");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RemediosReceitados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TratamentosRecomendados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiagnosticoId");

                    b.ToTable("Diagnosticos");
                });

            modelBuilder.Entity("breakevenApi.Domain.Entities.Doenca.Doenca", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doencas");
                });

            modelBuilder.Entity("breakevenApi.Domain.Entities.Especialidade.Especialidade", b =>
                {
                    b.Property<long>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Codigo"));

                    b.Property<int>("Indice")
                        .HasColumnType("int");

                    b.Property<string>("NomeEspecialidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("breakevenApi.Domain.Entities.ExerceEsp.ExerceEsp", b =>
                {
                    b.Property<long>("IdEsp")
                        .HasColumnType("bigint");

                    b.Property<long>("IdMedico")
                        .HasColumnType("bigint");

                    b.HasKey("IdEsp", "IdMedico");

                    b.ToTable("ExerceEsp");
                });

            modelBuilder.Entity("breakevenApi.Domain.Entities.Historico.HistoricoPaciente", b =>
                {
                    b.Property<long>("IdPaciente")
                        .HasColumnType("bigint");

                    b.Property<long>("IdConsulta")
                        .HasColumnType("bigint");

                    b.Property<DateOnly>("DataConsulta")
                        .HasColumnType("date");

                    b.Property<string>("Doenca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeMedico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPaciente", "IdConsulta");

                    b.ToTable("HistoricosPacientes");
                });

            modelBuilder.Entity("breakevenApi.Domain.Entities.Medic.Medic", b =>
                {
                    b.Property<long>("MedicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MedicId"));

                    b.Property<long>("Crm")
                        .HasColumnType("bigint");

                    b.Property<string>("NomeMedico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Percentual")
                        .HasColumnType("float");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicId");

                    b.ToTable("Medics");
                });

            modelBuilder.Entity("breakevenApi.Domain.Entities.Paciente.Paciente", b =>
                {
                    b.Property<long>("CodigoPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CodigoPaciente"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("NomePaciente")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CodigoPaciente");

                    b.ToTable("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
