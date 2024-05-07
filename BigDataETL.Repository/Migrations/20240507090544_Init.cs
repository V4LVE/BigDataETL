using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigDataETL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icao24 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Callsign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origin_country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time_position = table.Column<int>(type: "int", nullable: true),
                    Last_contact = table.Column<int>(type: "int", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Baro_altitude = table.Column<double>(type: "float", nullable: true),
                    On_ground = table.Column<bool>(type: "bit", nullable: true),
                    Velocity = table.Column<double>(type: "float", nullable: true),
                    True_track = table.Column<double>(type: "float", nullable: true),
                    Vertical_rate = table.Column<double>(type: "float", nullable: true),
                    Sensors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Geo_altitude = table.Column<double>(type: "float", nullable: true),
                    Squawk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spi = table.Column<bool>(type: "bit", nullable: true),
                    Position_source = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
