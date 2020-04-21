using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi.Web.Migrations
{
    public partial class EntitiesAddesTripAndTripDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripEntity_Taxis_TaxiEntityId",
                table: "TripEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripEntity",
                table: "TripEntity");

            migrationBuilder.RenameTable(
                name: "TripEntity",
                newName: "Trips");

            migrationBuilder.RenameColumn(
                name: "TaxiEntityId",
                table: "Trips",
                newName: "TaxiId");

            migrationBuilder.RenameIndex(
                name: "IX_TripEntity_TaxiEntityId",
                table: "Trips",
                newName: "IX_Trips_TaxiId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Trips",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Qualification",
                table: "Trips",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Trips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Trips",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SourceLatitude",
                table: "Trips",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SourceLongitude",
                table: "Trips",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Trips",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Target",
                table: "Trips",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TargetLatitude",
                table: "Trips",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TargetLongitude",
                table: "Trips",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trips",
                table: "Trips",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TripDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    TripId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripDetails_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripDetails_TripId",
                table: "TripDetails",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Taxis_TaxiId",
                table: "Trips",
                column: "TaxiId",
                principalTable: "Taxis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Taxis_TaxiId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "TripDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trips",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "SourceLatitude",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "SourceLongitude",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Target",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "TargetLatitude",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "TargetLongitude",
                table: "Trips");

            migrationBuilder.RenameTable(
                name: "Trips",
                newName: "TripEntity");

            migrationBuilder.RenameColumn(
                name: "TaxiId",
                table: "TripEntity",
                newName: "TaxiEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_TaxiId",
                table: "TripEntity",
                newName: "IX_TripEntity_TaxiEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripEntity",
                table: "TripEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TripEntity_Taxis_TaxiEntityId",
                table: "TripEntity",
                column: "TaxiEntityId",
                principalTable: "Taxis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
