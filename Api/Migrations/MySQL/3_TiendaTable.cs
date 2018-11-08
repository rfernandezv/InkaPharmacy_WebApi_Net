using FluentMigrator;
using System.Reflection;

namespace InkaPharmacy.Api.Migrations.MySQL
{
    [Migration(3)]
    public class TiendaTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("3_TiendaTable.sql");
        }

        public override void Down()
        {
        }
    }
}
