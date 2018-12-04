using FluentMigrator;

namespace InkaPharmacy.Api.Migrations.MySQL
{
    [Migration(13)]
    public class Sale_OrderTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("13_Sale_Order_Table.sql");
        }

        public override void Down()
        {
        }
    }
}
