using FluentMigrator;

namespace InkaPharmacy.Api.Migrations.MySQL
{
    [Migration(10)]
    public class ProviderTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("10_ProviderTable.sql");
        }

        public override void Down()
        {
        }
    }
}
