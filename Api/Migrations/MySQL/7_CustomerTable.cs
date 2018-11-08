using FluentMigrator;
using System.Reflection;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(7)]
    public class CustomerTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("7_CustomerTable.sql");
        }

        public override void Down()
        {
        }
    }
}
