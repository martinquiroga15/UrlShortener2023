using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoRegularizador.Data;
using ProyectoRegularizador.Entities;
using ProyectoRegularizador.Models.Dtos;

namespace ProyectoRegularizador.Services
{
    public class UserService
    {
        private ShortenerContext _context;
        public UserService(ShortenerContext context)
        {
            _context = context;
        }



        public void Create(UserForCreationDto dto)
        {
            User newUser = new User()
            {
                Name = dto.Name,
                Password = dto.Password,

            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }


        public User? ValidateUser(AuthenticationRequestDto authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Name == authRequestBody.Name && p.Password == authRequestBody.Password);
        }


        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int userId)
        {
            return _context.Users.Include(u => u.Name).FirstOrDefault(u => u.Id == userId);
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Single(u => u.Id == id));
            _context.SaveChanges();
        }
    }
}
