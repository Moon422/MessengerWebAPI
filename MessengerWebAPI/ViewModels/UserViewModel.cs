using System;
using MessengerWebAPI.Models;

namespace MessengerWebAPI.ViewModels
{
    public abstract class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class ShowUserViewModel : UserViewModel, IShowModelConvertible<User, ShowUserViewModel>
    {
        public long Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime LastUpdated { get; set; }

        public static ShowUserViewModel FromModel(User user)
        {
            return new ShowUserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreateAt = user.CreatedAt,
                LastUpdated = user.LastUpdated
            };
        }
    }

    public class CreateUserViewModel : UserViewModel
    {
        public User ToModel()
        {
            return new User
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                LastUpdated = DateTime.UtcNow
            };
        }
    }
}
