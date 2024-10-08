using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IJWTProvider
    {
        string GenerateToken(User user);
    }
}