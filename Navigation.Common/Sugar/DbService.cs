using System;
using SqlSugar;

namespace Navigation.Common.Sugar
{
    public class DbService : IDisposable
    {
        public SqlSugarClient Db;

        // public static string ConnectionString => Utility.Lite.Helper.ConfigHelper.GetAppSettingValue("DbConnectionString");
        public static string ConnectionString =
            @"Data Source=.\sqlexpress;Initial Catalog=Navigation;Persist Security Info=True;User ID=Navigation;Password=Navigation;MultipleActiveResultSets=True";

        public DbService()
        {
            Db = new SqlSugarClient(ConnectionString);
            Db.IsEnableLogEvent = true;
            Db.LogEventStarting = (sql, par) =>
            {
                Console.WriteLine(sql + " " + par + "\r\n");
            };
        }
        public void Dispose()
        {
            Db?.Dispose();
        }

    }
}
