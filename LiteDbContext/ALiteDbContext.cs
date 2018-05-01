using LiteDB;
using System;

namespace LiteDbContext
{
    public abstract class ALiteDbContext : IDisposable
    {
        protected LiteDatabase InternalDatabase;

        protected ALiteDbContext(string databasePath)
        {
            InternalDatabase = new LiteDatabase(databasePath);
        }

        public void Dispose()
        {
            InternalDatabase.Dispose();
        }
    }
}
