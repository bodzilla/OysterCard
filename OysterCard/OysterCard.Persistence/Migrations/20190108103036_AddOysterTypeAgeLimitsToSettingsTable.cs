using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OysterCard.Persistence.Migrations
{
    public partial class AddOysterTypeAgeLimitsToSettingsTable : Migration
    {
        private readonly string _lowerAgeLimitJunior;
        private readonly string _upperAgeLimitJunior;
        private readonly string _lowerAgeLimitAdult;
        private readonly string _upperAgeLimitAdult;

        public AddOysterTypeAgeLimitsToSettingsTable()
        {
            _lowerAgeLimitJunior = "LowerAgeLimitJunior";
            _upperAgeLimitJunior = "UpperAgeLimitJunior";
            _lowerAgeLimitAdult = "LowerAgeLimitAdult";
            _upperAgeLimitAdult = "UpperAgeLimitAdult";
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql($"INSERT INTO [dbo].[Settings] ([EntityCreated], [EntityActive], [Key], [Value]) VALUES ('{DateTime.Now}', 1, '{_lowerAgeLimitJunior}', '0');");
            migrationBuilder
                .Sql($"INSERT INTO [dbo].[Settings] ([EntityCreated], [EntityActive], [Key], [Value]) VALUES ('{DateTime.Now}', 1, '{_upperAgeLimitJunior}', '15');");
            migrationBuilder
                .Sql($"INSERT INTO [dbo].[Settings] ([EntityCreated], [EntityActive], [Key], [Value]) VALUES ('{DateTime.Now}', 1, '{_lowerAgeLimitAdult}', '16');");
            migrationBuilder
                .Sql($"INSERT INTO [dbo].[Settings] ([EntityCreated], [EntityActive], [Key], [Value]) VALUES ('{DateTime.Now}', 1, '{_upperAgeLimitAdult}', '74');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql($"DELETE FROM [dbo].[Settings] WHERE [Key] = '{_lowerAgeLimitJunior}';");
            migrationBuilder
                   .Sql($"DELETE FROM [dbo].[Settings] WHERE [Key] = '{_upperAgeLimitJunior}';");
            migrationBuilder
                   .Sql($"DELETE FROM [dbo].[Settings] WHERE [Key] = '{_lowerAgeLimitAdult}';");
            migrationBuilder
                   .Sql($"DELETE FROM [dbo].[Settings] WHERE [Key] = '{_upperAgeLimitAdult}';");
        }
    }
}
