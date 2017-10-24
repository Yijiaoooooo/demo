using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Domain.User;
using Data.Respository;

namespace BLL.User
{
    public class UserService : IuserService
    {
        private IRepository<User> _userRepo;
        public UserService()
        {
        }
    }
}
