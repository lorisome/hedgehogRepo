using Chat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Web.DataAccess
{
    public interface IUserDAL
    {
        UserModel GetUser(string username, string password);
        UserModel CreateUser(UserModel user);        
    }
}
