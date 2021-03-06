using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Services {

    public interface IUserService
    {
        User FindUserById( long id );
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> FindUserByName( string text );
        
        void AddUser( User user );

        User UpdateUser(User oldUser, User newUser);
    }
}