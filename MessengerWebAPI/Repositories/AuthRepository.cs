using System;
using System.Threading.Tasks;
using MessengerWebAPI.Exceptions;
using MessengerWebAPI.Models;
using MessengerWebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MessengerWebAPI.Repositories
{
    public interface IAuthRepository
    {
        Task<Auth> Login(AuthViewModel authViewModel);
        Task<Auth> Register(CreateUserViewModel userViewModel, AuthViewModel authViewModel);
    }

    public class AuthRepository : IAuthRepository
    {
        private readonly MessengerDbContext _dbContext;

        public AuthRepository(MessengerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Auth> Login(AuthViewModel authViewModel)
        {
            try
            {
                var authModel = await this._dbContext.Auths.Include(a => a.User).FirstAsync(a => a.Username == authViewModel.Username);
                return authModel;
            }
            catch (InvalidOperationException ex)
            {
                throw new ModelNotFoundException($"Auth model username with {authViewModel.Username} not found", ex);
            }
        }

        public async Task<Auth> Register(CreateUserViewModel userViewModel, AuthViewModel authViewModel)
        {
            var user = userViewModel.ToModel();
            var auth = authViewModel.ToModel(user);

            await this._dbContext.Users.AddAsync(user);
            await this._dbContext.Auths.AddAsync(auth);
            await this._dbContext.SaveChangesAsync();

            return auth;
        }
    }
}
