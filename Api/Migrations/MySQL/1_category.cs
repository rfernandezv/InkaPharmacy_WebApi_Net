using FluentMigrator;

namespace InkaPharmacy.Api.Migrations.MySQL
{
    [Migration(1)]
    public class CategoryTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("1_Category.sql");
        }

        public override void Down()
        {
        }
    }
}
