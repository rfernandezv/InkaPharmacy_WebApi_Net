using FluentMigrator;
using System.Reflection;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(12)]
    public class Purchase_Order_DetailTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("12_Purchase_Order_Detail_Table.sql");
        }

        public override void Down()
        {
        }
    }
}
