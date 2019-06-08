using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;

namespace YallaGameAPISecure.Data
{
    public interface IAuthRepository<T>
    {
        Task<T> Register(T username, string password);

        Task<T> Login(string username, string password);

        Task<bool> UserExists(string username);
        Task<bool> EmailExists(string username);


    }
}
