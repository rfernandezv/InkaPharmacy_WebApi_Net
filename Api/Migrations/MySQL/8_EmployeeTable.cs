using FluentMigrator;
using System.Reflection;

namespace InkaPhatmacy.Api.Migrations.MySQL
{
    [Migration(8)]
    public class EmployeeTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("8_EmployeeTable.sql");
        }

        public override void Down()
        {
        }
    }
}
