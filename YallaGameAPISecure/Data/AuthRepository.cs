using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;

namespace YallaGameAPISecure.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly yallagameContext _context;

        public AuthRepository(yallagameContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string password)
        {
            var User = await _context.User.FirstOrDefaultAsync(x => x.Name == username);
            if (User == null)
            {
                return null;
            }
            if(!VerifyPasswordHash(password,User.PasswordHash,User.PasswordSalt))
            {
                return null;
            }
            return User;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                 
                var computedhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedhash.Length; i++)
                {
                    if (computedhash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
        
        public async Task<User> Register(User username, string password)
        {
            byte[] passwordhash, passowrdsalt;
            CreatePasswordHash(password,out passwordhash,out passowrdsalt);
            username.PasswordHash = passwordhash;
            username.PasswordSalt = passowrdsalt;

            await _context.User.AddAsync(username);
            await _context.SaveChangesAsync();
            return username;
        }

        private void CreatePasswordHash(string password, out byte[] passwordhash, out byte[] passowrdsalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passowrdsalt = hmac.Key;
                passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.User.AnyAsync(x => x.Name == username))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> EmailExists(string email)
        {
            if(await _context.User.AnyAsync(x => x.Email == email))
            {
                return true;
            }
            return false;
        }
    }
}
