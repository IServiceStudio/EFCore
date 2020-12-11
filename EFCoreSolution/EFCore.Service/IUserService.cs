using EFCore.Entity.Model;
using System.Collections.Generic;

namespace EFCore.Service
{
    public interface IUserService
    {
        bool AddUser(User user);
        User Find(int id);
    }
}
