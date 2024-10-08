using Application.DTO;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService(IRepository<User> repository, IJWTProvider provider)
    {
        private readonly IRepository<User> _repository = repository;
        private readonly IJWTProvider _jwtProvider = provider;
        public async  Task<string> Login(string login, string password)
        {
            var user = await _repository.GetByAsync(x => x.Login == login);
            if (user != null)
            {
                return _jwtProvider.GenerateToken(user);
            }
            return "user is not exist!";
        }



        public async Task<bool> Register(RegisterDTO user)
        {
            await _repository.AddAsync(new User 
            { 
                Name = user.Name, 
                Login = user.Login, 
                Password = user.Password, 
                IsAdmin = user.IsAdmin,
                Gender = user.Gender,
                CreatedOn = DateTime.UtcNow,
            });
            return true;
        }
    }
}
