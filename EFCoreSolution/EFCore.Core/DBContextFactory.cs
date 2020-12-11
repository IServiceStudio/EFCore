using EFCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace EFCore.Core
{
    public class DBContextFactory : IDBContextFactory
    {
        private readonly DBConnectionOption dbOptions;
        private static object LOCK = new object();

        public DBContextFactory(IOptionsMonitor<DBConnectionOption> options)
        {
            dbOptions = options.CurrentValue;
        }

        public DbContext CreateDbContext(DBOptions options = DBOptions.Write)
        {
            string connectionString = null;
            switch (options)
            {
                case DBOptions.Write:
                    connectionString = dbOptions.MainConnection;
                    break;
                case DBOptions.Read:
                    connectionString = GetSlaveConnection();
                    break;
                default:
                    break;
            }
            return new EFCoreDBContext(connectionString);
        }

        private string GetSlaveConnection()
        {
            lock (LOCK)
            {
                return dbOptions.SlaveConnections[new Random().Next(0, dbOptions.SlaveConnections.Count - 1)];
            }
        }
    }
}
