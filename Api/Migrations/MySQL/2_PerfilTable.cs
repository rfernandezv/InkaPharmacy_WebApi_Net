using FluentMigrator;
using System.Reflection;

namespace InkaPhatmacy.Api.Migrations.MySQL
{
    [Migration(2)]
    public class PerfilTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("2_PerfilTable.sql");
        }

        public override void Down()
        {
        }
    }
}
