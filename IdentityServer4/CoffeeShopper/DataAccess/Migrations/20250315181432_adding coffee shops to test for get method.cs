using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addingcoffeeshopstotestforgetmethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('Starbucks', '6am-10pm', '1234 Main St')");
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('Starbucks', '6am-10pm', 'Belbas')");
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('Starbucks', '5am-12am', 'Butwal')");
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('Starbucks', '24/7', 'Kathmandu')");
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('Starbucks', '5am-12am', 'Pokhara')");
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('Starbucks', '9am-9pm', 'California')");
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('Starbucks', '9am-9pm', 'Miami')");
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('Starbucks', '9am-9pm', 'Alaska')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
