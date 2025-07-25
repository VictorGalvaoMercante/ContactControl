using Microsoft.EntityFrameworkCore;
using ContactControl.Models; 

public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {
    }

    public DbSet<ContactModel> Contacts { get; set; }
    
}