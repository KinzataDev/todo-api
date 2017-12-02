using System.Collections.Generic;
using System;
using System.Linq;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services {

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
        public User FindUserById( long id ) {
            return _userRepository.GetById(id);
        }
        public IEnumerable<User> GetAllUsers() {
            return _userRepository.GetEntities().ToList();
        }
        public IEnumerable<User> FindUserByName( string text ) {
            return _userRepository.GetEntities().Where( user => user.Name.Contains( text ) ).ToList();
        }
        
        public User UpdateUser(User oldUser, User newUser)
        {
            oldUser.Name = newUser.Name;
            _userRepository.Update(oldUser);
            _userRepository.SaveChanges();
            return newUser;
        }
    }
}