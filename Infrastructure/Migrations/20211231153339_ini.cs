using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoCuenta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCuenta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoOperacion",
                columns: table => new
                {
                    TipoOperacionId = table.Column<byte>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoOperacion", x => x.TipoOperacionId);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CasaId = table.Column<long>(type: "INTEGER", nullable: false),
                    Numero = table.Column<long>(type: "INTEGER", nullable: false),
                    TipoCuentaId = table.Column<long>(type: "INTEGER", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstadoId = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuenta_TipoCuenta_TipoCuentaId",
                        column: x => x.TipoCuentaId,
                        principalTable: "TipoCuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Documento = table.Column<long>(type: "INTEGER", nullable: false),
                    Cuil = table.Column<long>(type: "INTEGER", nullable: false),
                    ApNombre = table.Column<string>(type: "TEXT", nullable: true),
                    TipoDocumentoId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_TipoDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operacion",
                columns: table => new
                {
                    OperacionId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    OperadorId = table.Column<byte>(type: "INTEGER", nullable: false),
                    TipoOperacionId = table.Column<byte>(type: "INTEGER", nullable: false),
                    DisponibleOp = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProcesoMes = table.Column<bool>(type: "INTEGER", nullable: false),
                    Automatica = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImprimeCompr = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacion", x => x.OperacionId);
                    table.ForeignKey(
                        name: "FK_Operacion_TipoOperacion_TipoOperacionId",
                        column: x => x.TipoOperacionId,
                        principalTable: "TipoOperacion",
                        principalColumn: "TipoOperacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuentaSaldo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CuentaId = table.Column<long>(type: "INTEGER", nullable: false),
                    FechaUltMov = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InteresAcum = table.Column<double>(type: "REAL", nullable: false),
                    Saldo = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaSaldo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuentaSaldo_Cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuentaPersona",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CuentaId = table.Column<long>(type: "INTEGER", nullable: false),
                    PersonaId = table.Column<long>(type: "INTEGER", nullable: false),
                    Orden = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaPersona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuentaPersona_Cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuentaPersona_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CuentaId = table.Column<long>(type: "INTEGER", nullable: false),
                    SucursalIdMov = table.Column<long>(type: "INTEGER", nullable: false),
                    NumeroOp = table.Column<long>(type: "INTEGER", nullable: false),
                    FechaOp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaGrab = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OperacionId = table.Column<long>(type: "INTEGER", nullable: false),
                    Importe = table.Column<double>(type: "REAL", nullable: false),
                    SaldoOp = table.Column<double>(type: "REAL", nullable: false),
                    SaldoGr = table.Column<double>(type: "REAL", nullable: false),
                    InfAdicional = table.Column<long>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<long>(type: "INTEGER", nullable: false),
                    Anulado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimiento_Cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimiento_Operacion_OperacionId",
                        column: x => x.OperacionId,
                        principalTable: "Operacion",
                        principalColumn: "OperacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoDocumento",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1L, "DNI" });

            migrationBuilder.InsertData(
                table: "TipoOperacion",
                columns: new[] { "TipoOperacionId", "Nombre" },
                values: new object[] { (byte)1, "Comun" });

            migrationBuilder.InsertData(
                table: "Operacion",
                columns: new[] { "OperacionId", "Automatica", "DisponibleOp", "ImprimeCompr", "Nombre", "OperadorId", "ProcesoMes", "TipoOperacionId" },
                values: new object[] { 1L, false, true, false, "Deposito", (byte)1, false, (byte)1 });

            migrationBuilder.InsertData(
                table: "Operacion",
                columns: new[] { "OperacionId", "Automatica", "DisponibleOp", "ImprimeCompr", "Nombre", "OperadorId", "ProcesoMes", "TipoOperacionId" },
                values: new object[] { 2L, false, true, false, "Extraccion", (byte)2, false, (byte)1 });

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_TipoCuentaId",
                table: "Cuenta",
                column: "TipoCuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaPersona_CuentaId",
                table: "CuentaPersona",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaPersona_PersonaId",
                table: "CuentaPersona",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaSaldo_CuentaId",
                table: "CuentaSaldo",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_CuentaId",
                table: "Movimiento",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_OperacionId",
                table: "Movimiento",
                column: "OperacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_TipoOperacionId",
                table: "Operacion",
                column: "TipoOperacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_TipoDocumentoId",
                table: "Persona",
                column: "TipoDocumentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuentaPersona");

            migrationBuilder.DropTable(
                name: "CuentaSaldo");

            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Operacion");

            migrationBuilder.DropTable(
                name: "TipoDocumento");

            migrationBuilder.DropTable(
                name: "TipoCuenta");

            migrationBuilder.DropTable(
                name: "TipoOperacion");
        }
    }
}
