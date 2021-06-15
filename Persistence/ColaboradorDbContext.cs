using CrudSimples.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudSimples.API.Persistence
{
    public class ColaboradorDbContext : DbContext
    {
        public ColaboradorDbContext(DbContextOptions<ColaboradorDbContext> options) : base(options)
        {

        }
        public DbSet<Colaborador> Colaboradores { get; set; }
    }
}
