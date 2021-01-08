using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfoManager.Data.Models;

namespace UserInfoManager.Data.Services
{

    public interface IUserData
    {
        IEnumerable<User> GetAllUsers();
        User GetUserData(int id); // GetData instead of Get so it doesn't conflicts with naming schemes
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
