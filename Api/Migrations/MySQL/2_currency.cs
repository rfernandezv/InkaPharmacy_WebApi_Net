using FluentMigrator;

namespace InkaPharmacy.Api.Migrations.MySQL
{
    [Migration(2)]
    public class CurrencyTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("2_currency.sql");
        }

        public override void Down()
        {
        }
    }
}
