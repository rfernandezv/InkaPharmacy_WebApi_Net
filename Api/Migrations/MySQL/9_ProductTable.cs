using FluentMigrator;

namespace InkaPharmacy.Api.Migrations.MySQL
{
    [Migration(9)]
    public class ProductTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("9_ProductTable.sql");
        }

        public override void Down()
        {
        }
    }
}
