using System;
using MessengerWebAPI.Models;
using Bcrypt = BCrypt.Net.BCrypt;

namespace MessengerWebAPI.ViewModels
{
    public class AuthViewModel : ICreateViewModelConvertible<Auth, User>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Auth ToModel(User user)
        {
            var hashedPassword = Bcrypt.HashPassword(this.Password);
            return new Auth
            {
                Username = this.Username,
                Password = hashedPassword,
                User = user
            };
        }
    }
}
