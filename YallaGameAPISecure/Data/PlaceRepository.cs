using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;

namespace YallaGameAPISecure.Data
{
    public class PlaceRepository : IAuthRepository<Place>
    {
        private readonly yallagameContext _context;

        public PlaceRepository(yallagameContext context)
        {
            _context = context;
        }
        public async Task<Place> Login(string email, string password)
        {
            var Place = await _context.Place.FirstOrDefaultAsync(x => x.Email == email);
            if (Place == null)
            {
                return null;
            }
            if (!VerifyPasswordHash(password, Place.PasswordHash, Place.PasswordSalt))
            {
                return null;
            }
            return Place;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {

                var computedhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedhash.Length; i++)
                {
                    if (computedhash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<Place> Register(Place placename, string password)
        {
            byte[] passwordhash, passowrdsalt;
            CreatePasswordHash(password, out passwordhash, out passowrdsalt);
            placename.PasswordHash = passwordhash;
            placename.PasswordSalt = passowrdsalt;

            await _context.Place.AddAsync(placename);
            await _context.SaveChangesAsync();
            return placename;
        }

        private void CreatePasswordHash(string password, out byte[] passwordhash, out byte[] passowrdsalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passowrdsalt = hmac.Key;
                passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string placename)
        {
            if (await _context.Place.AnyAsync(x => x.Name == placename))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> EmailExists(string email)
        {
            if (await _context.Place.AnyAsync(x => x.Email == email))
            {
                return true;
            }
            return false;
        }

        
    }
}
