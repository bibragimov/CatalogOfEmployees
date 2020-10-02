using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogOfEmployees.Domain.Ef
{
    public static class MigrationExtension
    {
        public static void RunFileScript(this MigrationBuilder migrationBuilder, string sqlName)
        {
            string data = AppDomain.CurrentDomain.GetData("DataDirectory") as string ?? AppContext.BaseDirectory;
            string sqlPath = Path.Combine(data, "Migrations\\Scripts", sqlName);
            migrationBuilder.Sql(File.ReadAllText(sqlPath));
        }
    }
}