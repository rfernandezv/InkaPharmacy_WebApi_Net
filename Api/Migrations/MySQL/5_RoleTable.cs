using FluentMigrator;

namespace InkaPharmacy.Api.Migrations.MySQL
{
    [Migration(5)]
    public class RoleTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("5_RoleTable.sql");
        }

        public override void Down()
        {
        }
    }
}
