using FluentMigrator;

namespace InkaPharmacy.Api.Migrations.MySQL
{
    [Migration(11)]
    public class Purchase_OrderTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("11_Purchase_OrderTable.sql");
        }

        public override void Down()
        {
        }
    }
}
