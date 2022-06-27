using Microsoft.EntityFrameworkCore;
using ProjetoFinal1BlueEdTech.Models;

namespace ProjetoFinal1BlueEdTech.Contexts
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options) {}

        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
    }
}