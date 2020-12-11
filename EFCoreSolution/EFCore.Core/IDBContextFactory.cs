using Microsoft.EntityFrameworkCore;

namespace EFCore.Core
{
    public interface IDBContextFactory
    {
        DbContext CreateDbContext(DBOptions options = DBOptions.Write);
    }
}
