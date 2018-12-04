using FluentMigrator;

namespace InkaPharmacy.Api.Migrations.MySQL
{
    [Migration(14)]
    public class Sale_Order_DetailTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("14_Sale_Order_Detail_Table.sql");
        }

        public override void Down()
        {
        }
    }
}
