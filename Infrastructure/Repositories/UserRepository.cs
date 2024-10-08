using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UserRepository(Context context) : BaseRepository<User>(context)
    {

    }
}
