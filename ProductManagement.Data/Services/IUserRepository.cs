using ProductManagement.Data.Entities;
using System.Collections.Generic;

namespace ProductManagement.Data.Services
{
    public interface IUserRepository
    {
        User Authenticate(User model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
