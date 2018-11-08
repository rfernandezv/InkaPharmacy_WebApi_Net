using FluentMigrator;
using System.Reflection;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(6)]
    public class StoreTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("6_StoreTable.sql");
        }

        public override void Down()
        {
        }
    }
}
