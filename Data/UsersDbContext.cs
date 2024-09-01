using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AtulaDotNetTest.Domain;

namespace AtulaDotNetTest.Data
{
    public class UsersDbContext:IdentityDbContext<User>
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options): base(options) { }
    }
}
