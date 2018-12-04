using FluentMigrator;

namespace InkaPharmacy.Api.Migrations.MySQL
{
    [Migration(8)]
    public class EmployeeTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("8_EmployeeTable.sql");
        }

        public override void Down()
        {
        }
    }
}
