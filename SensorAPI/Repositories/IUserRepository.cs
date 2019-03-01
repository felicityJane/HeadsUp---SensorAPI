using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorAPI.Models;

namespace SensorAPI.Repositories
{
    public interface IUserRepository
    {
        //add user
        UserEntity InsertUser(string userId, string name, string info);
        // remove user

        //get user by id
        UserEntity GetUser(string userId, string name);

        //delete users
    }
}
