

using ContactControl.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactControl.Data
{
    public class BancoContext : DbContext
    {
        public DbSet<ContactModel> Contacts { get; set; }

        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
            
        }
    }
}
