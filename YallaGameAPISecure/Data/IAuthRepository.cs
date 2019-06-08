using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;

namespace YallaGameAPISecure.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User username, string password);

        Task<User> Login(string username, string password);

        Task<bool> UserExists(string username);
        Task<bool> EmailExists(string username);


    }
}
