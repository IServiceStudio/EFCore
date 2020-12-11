using EFCore.Core;
using EFCore.Entity.Model;

namespace EFCore.Service
{
    public class UserService : IUserService
    {
        private readonly IDBContextFactory dbContext;

        public UserService(IDBContextFactory dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool AddUser(User user)
        {
            using (var context = dbContext.CreateDbContext(DBOptions.Write))
            {
                context.Add(user);
                return context.SaveChanges() > 0;
            }
        }

        public User Find(int id)
        {
            using (var context = dbContext.CreateDbContext(DBOptions.Read))
            {
                return context.Find<User>(id);
            }
        }
    }
}
