using Microsoft.EntityFrameworkCore;
using webapicurso.Models;

namespace webapicurso.Data;
#pragma warning disable CS1591
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<AutorModel> Autores { get; set; }
    public DbSet<LivroModel> Livros { get; set; }
}
#pragma warning restore CS1591