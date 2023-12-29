using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    id_parkingu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    liczba_miejsc = table.Column<int>(type: "int", nullable: false),
                    liczba_pięter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.id_parkingu);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    id_uzytkownika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    haslo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nr_telefonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    czy_gosc = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.id_uzytkownika);
                });

            migrationBuilder.CreateTable(
                name: "MiejsceParkingowe",
                columns: table => new
                {
                    id_miejsca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_parkingu = table.Column<int>(type: "int", nullable: false),
                    stan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiejsceParkingowe", x => x.id_miejsca);
                    table.ForeignKey(
                        name: "FK_MiejsceParkingowe_Parking_id_parkingu",
                        column: x => x.id_parkingu,
                        principalTable: "Parking",
                        principalColumn: "id_parkingu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pojazd",
                columns: table => new
                {
                    id_pojazdu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numer_rejestracyjny = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    waga = table.Column<int>(type: "int", nullable: false),
                    id_uzytkownika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pojazd", x => x.id_pojazdu);
                    table.ForeignKey(
                        name: "FK_Pojazd_Uzytkownicy_id_uzytkownika",
                        column: x => x.id_uzytkownika,
                        principalTable: "Uzytkownicy",
                        principalColumn: "id_uzytkownika",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Postoj",
                columns: table => new
                {
                    id_postoju = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_miejsca = table.Column<int>(type: "int", nullable: false),
                    data_zakonczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_rozpoczecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_uzytkownika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postoj", x => x.id_postoju);
                    table.ForeignKey(
                        name: "FK_Postoj_Uzytkownicy_id_uzytkownika",
                        column: x => x.id_uzytkownika,
                        principalTable: "Uzytkownicy",
                        principalColumn: "id_uzytkownika",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacja",
                columns: table => new
                {
                    id_rezerwacji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_pojazdu = table.Column<int>(type: "int", nullable: false),
                    id_miejsca = table.Column<int>(type: "int", nullable: false),
                    data_rozpoczęcia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_zakończenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_uzytkownika = table.Column<int>(type: "int", nullable: false),
                    MiejsceParkingoweid_miejsca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacja", x => x.id_rezerwacji);
                    table.ForeignKey(
                        name: "FK_Rezerwacja_MiejsceParkingowe_MiejsceParkingoweid_miejsca",
                        column: x => x.MiejsceParkingoweid_miejsca,
                        principalTable: "MiejsceParkingowe",
                        principalColumn: "id_miejsca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezerwacja_Uzytkownicy_id_uzytkownika",
                        column: x => x.id_uzytkownika,
                        principalTable: "Uzytkownicy",
                        principalColumn: "id_uzytkownika",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiejsceParkingowe_id_parkingu",
                table: "MiejsceParkingowe",
                column: "id_parkingu");

            migrationBuilder.CreateIndex(
                name: "IX_Pojazd_id_uzytkownika",
                table: "Pojazd",
                column: "id_uzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_Postoj_id_uzytkownika",
                table: "Postoj",
                column: "id_uzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacja_id_uzytkownika",
                table: "Rezerwacja",
                column: "id_uzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacja_MiejsceParkingoweid_miejsca",
                table: "Rezerwacja",
                column: "MiejsceParkingoweid_miejsca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pojazd");

            migrationBuilder.DropTable(
                name: "Postoj");

            migrationBuilder.DropTable(
                name: "Rezerwacja");

            migrationBuilder.DropTable(
                name: "MiejsceParkingowe");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Parking");
        }
    }
}
