using FluentMigrator;
using System.Reflection;

namespace InkaPhatmacy.Api.Migrations.MySQL
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
